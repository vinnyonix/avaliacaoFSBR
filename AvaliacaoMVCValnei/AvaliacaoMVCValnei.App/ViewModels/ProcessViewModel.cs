using Microsoft.AspNetCore.Mvc.Rendering;
using AvaliacaoMVCValnei.App.Models;

namespace AvaliacaoMVCValnei.App.ViewModels
{
    public class ProcessViewModel
    {
        public ProcessViewModel()
        {
            ProcessModel = new ProcessModel();
            Locations = new List<SelectListItem>();
        }
        public ProcessModel? ProcessModel { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}
