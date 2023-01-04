using Microsoft.AspNetCore.Mvc;
using SAASystem.Helper;
using SAASystem.Models.View;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = HomeControllerHelper.GetIndexItemComponentModels();
            return View(indexViewModel);
        }
    }
}