using AvaliacaoMVCValnei.App.Service.Interfaces;
using AvaliacaoMVCValnei.App.Utils.Http.Models;
using AvaliacaoMVCValnei.App.Utils.Converters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvaliacaoMVCValnei.App.ViewModels;
using AvaliacaoMVCValnei.Data.Entities;
using AvaliacaoMVCValnei.App.Service;
using Microsoft.EntityFrameworkCore;
using AvaliacaoMVCValnei.App.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace AvaliacaoMVCValnei.App.Controllers
{
    public class ProcessController : Controller
    {
        private readonly IProcessService _processService;

        private static IList<Localidade>? Locations;

        private static IEnumerable<SelectListItem>? LocationsSelect;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        // GET: Process
        //public async Task<IActionResult> Index()
        //{
        //    var processModelList = new List<ProcessModel>();

        //    var list = await _processService.ListAsync();

        //    foreach (var item in list)
        //    {
        //        processModelList.Add(ProcessConverter.EntityToViewModel(item).ProcessModel!);
        //    }

        //    return View(processModelList);
        //}

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var pageSize = 10;

            var rawList = _processService.Query(x => x.ProcessId > 0);

            var viewModelList = ProcessConverter.EntityListToProcessModelList(rawList.ToList());

            var pagedList = viewModelList.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var processEntity = await _processService.FindAsync(m => m.ProcessId == id);

            if (processEntity == null)
            {
                return NotFound();
            }

            var processModel = ProcessConverter.EntityToViewModel(processEntity).ProcessModel;

            return View(processModel);
        }

        public IActionResult Create()
        {
            LoadLocations();

            if (LocationsSelect == null)
            {
                RedirectToAction("Index");
            }

            var model = new ProcessViewModel();

            model.Locations = LocationsSelect!;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessViewModel processViewModel)
        {
            /*
             * O campo FederativeUnitIdSelected é o que contém o código da seleção de Município e UF
             * então na próxima etapa eu vou buscar por este código e salvá-los 
             * separadamente em seus respctivos campos.
            */

            if (processViewModel.ProcessModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var selected = Locations
                   .Where(x => x.ImmediateRegionId == Convert.ToInt32(processViewModel.ProcessModel!.FederativeUnitIdSelected))
                   .FirstOrDefault();

            if (selected == null)
            {
                return RedirectToAction(nameof(Index));
            }

            processViewModel.ProcessModel!.Municipality = selected.ImmediateRegionName;

            /*
             * Os 2 foreach abaixo são um exemplo, que no mundo real, o primeiro ficaria esperando o segundo e 
             * em um processo mais complexo poderia impactar no desempenho da aplicação, mas com o uso 
             * do Parallel elas trabalham juntas.
             */

            Parallel.ForEach(ModelState, item =>
            {
                if (item.Key == "ProcessModel.Municipality")
                {
                    item.Value!.Errors.Clear();
                    item.Value.ValidationState = ModelValidationState.Valid;
                }
            });

            Parallel.ForEach(ModelState, item =>
            {
                if (item.Key == "ProcessModel.FederativeUnit")
                {
                    item.Value!.Errors.Clear();
                    item.Value.ValidationState = ModelValidationState.Valid;
                }
            });

            processViewModel.ProcessModel!.FederativeUnit = selected.FederativeUnitAcronym;

            if (ModelState.IsValid)
            {
                processViewModel.ProcessModel.NPU = processViewModel.ProcessModel.NPU!.Replace("-", "");

                _processService.Add(ProcessConverter.ViewModelToEntity(processViewModel));

                await _processService.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

           

            return View(processViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var processEntity = await _processService.FindAsync(x => x.ProcessId == id);

            if (processEntity == null)
            {
                return NotFound();
            }

            var processModel = ProcessConverter.EntityToProcessModel(processEntity);

            return View(processModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcessModel model)
        {
            if (id != model.ProcessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _processService.Update(ProcessConverter.ViewModelToEntity(new ProcessViewModel { ProcessModel = model }));

                    await _processService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessEntityExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var processEntity = await _processService.FindAsync(m => m.ProcessId == id);

            if (processEntity == null)
            {
                return NotFound();
            }

            var process = ProcessConverter.EntityToProcessModel(processEntity);

            return View(process);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processEntity = await _processService.FindAsync(x => x.ProcessId == id);

            if (processEntity != null)
            {
                try
                {
                    _processService.Delete(processEntity);

                    await _processService.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProcessEntityExists(int? id)
        {
            if (id == null || id <= 0)
            {
                return false;
            }

            var result = _processService.FindAsync(e => e.ProcessId == id);

            return result == null;
        }

        private void LoadLocations()
        {
            var ibgeList = HttpService.GetIBGEAsync().Result;

            Locations = ibgeList;

            var locationsSelect = ibgeList.Select(x => new SelectListItem
            {
                Value = x!.ImmediateRegionId.ToString(),
                Text = x.Exibition!.ToString()
            });

            LocationsSelect = locationsSelect;
        }
    }
}
