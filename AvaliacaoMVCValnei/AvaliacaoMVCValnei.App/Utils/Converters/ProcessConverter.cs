using AvaliacaoMVCValnei.App.ViewModels;
using AvaliacaoMVCValnei.Data.Entities;
using AvaliacaoMVCValnei.App.Models;
using System.Threading.Tasks;

namespace AvaliacaoMVCValnei.App.Utils.Converters
{
    public static class ProcessConverter
    {
        public static ProcessEntity ViewModelToEntity(ProcessViewModel viewModel) 
        {
            var entity = new ProcessEntity
            {
                ProcessId = viewModel.ProcessModel!.ProcessId,
                Name = viewModel.ProcessModel.Name,
                NPU = viewModel.ProcessModel.NPU,
                CreateAt = viewModel.ProcessModel.CreateAt!,
                ViewedAt = viewModel.ProcessModel.ViewedAt,
                FederativeUnit = viewModel.ProcessModel.FederativeUnit,
                Municipality = viewModel.ProcessModel.Municipality
            };

            return entity;
        }

        public static ProcessViewModel EntityToViewModel(ProcessEntity entity)
        {
            var model = new ProcessModel
            {
                ProcessId = entity.ProcessId,
                Name = entity.Name,
                NPU = entity.NPU,
                CreateAt = entity.CreateAt,
                ViewedAt = entity.ViewedAt,
                FederativeUnit = entity.FederativeUnit,
                Municipality = entity.Municipality
            };

            var viewModel = new ProcessViewModel
            {
                ProcessModel = model,
            };

            return viewModel;
        }

        public static ProcessModel EntityToProcessModel(ProcessEntity entity)
        {
            var model = new ProcessModel
            {
                ProcessId = entity.ProcessId,
                Name = entity.Name,
                NPU = entity.NPU,
                CreateAt = entity.CreateAt,
                ViewedAt = entity.ViewedAt,
                FederativeUnit = entity.FederativeUnit,
                Municipality = entity.Municipality
            };

            return model;
        }

        //public static List<ProcessEntity> ViewModelListToEntityList(List<ProcessViewModel> viewModelList)
        //{
        //    List<ProcessEntity> newList = [];

        //    foreach (var item in viewModelList)
        //    {
        //        var entity = new ProcessEntity
        //        {
        //            ProcessId = item.ProcessModel!.ProcessId,
        //            Name = item.ProcessModel.Name,
        //            NPU = item.ProcessModel.NPU,
        //            CreateAt = item.ProcessModel.CreateAt!,
        //            ViewedAt = item.ProcessModel.ViewedAt,
        //            FederativeUnit = item.ProcessModel.FederativeUnit,
        //            Municipality = item.ProcessModel.Municipality
        //        };

        //        newList.Add(entity);
        //    }

        //    return newList;
        //}

        public static List<ProcessModel> EntityListToProcessModelList(List<ProcessEntity> entityList)
        {
            List<ProcessModel> newList = [];

            foreach (var item in entityList)
            {
                var processModel = new ProcessModel
                {
                    ProcessId = item.ProcessId,
                    Name = item.Name,
                    NPU = item.NPU,
                    CreateAt = item.CreateAt!,
                    ViewedAt = item.ViewedAt,
                    FederativeUnit = item.FederativeUnit,
                    Municipality = item.Municipality
                };

                newList.Add(processModel);
            }

            return newList;
        }
    }
}
