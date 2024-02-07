using ITLATv.Application.Services;
using ITLATv.Application.ViewModels.Serie;
using ITLATv.WebApp.Middleware;
using ITLATv.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLATv.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _serieService;
        private readonly GenderService _genderService;
        private readonly ProducterService _producterService;

        public HomeController(SerieService serieService, GenderService genderService, ProducterService producterService)
        {
            _serieService = serieService;
            _genderService = genderService;
            _producterService = producterService;
        }

        public async Task<IActionResult> Index(FilterSeriesViewModel vm, string? name)
        {
            ViewBag.Genders = await _genderService.GetAll();
            ViewBag.Producters = await _producterService.GetAll();
            List<SerieViewModel> svm = await _serieService.GetAll();

            if (vm.ProducterId != null || vm.GenderId != null)
            {
                svm = await _serieService.GetAllWithFilters(vm);
            }
            
            else if(name != null)
            {
                svm = await _serieService.GetByName(name);
            }
            
            

            return View(svm);
        }

        public async Task<IActionResult> Watch(int id)
        {
            var vm = await _serieService.GetById(id);
            ViewBag.Genders = await _genderService.GetAll();
            return View(vm);
        }

    }
}
