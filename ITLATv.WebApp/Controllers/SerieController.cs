using ITLATv.Application.Services;
using ITLATv.Application.ViewModels.Serie;
using ITLATv.WebApp.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace ITLATv.WebApp.Controllers
{
    public class SerieController : Controller
    {
        private readonly SerieService _serieService;
        private readonly GenderService _genderService;
        private readonly ProducterService _producterService;
        private readonly ConvertToEmbedYTVideo _convert;


        public SerieController(SerieService serieService, GenderService genderService, ProducterService producterService, ConvertToEmbedYTVideo convert)
        {
            _serieService = serieService;
            _genderService = genderService;
            _producterService = producterService;
            _convert = convert;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAll());
        }

        public async Task<IActionResult> Add() 
        {
            SerieSaveViewModel vm = new();
            vm.Producters = await _producterService.GetAll();
            vm.Genders = await _genderService.GetAll();
            

           
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SerieSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Producters = await _producterService.GetAll();
                vm.Genders = await _genderService.GetAll();
                return View(vm);
            }

            vm.VideoURL =  _convert.ConverterToEmbed(vm.VideoURL);
            await _serieService.Add(vm);
            return RedirectToRoute(new {controller= "Serie", action="Index"});
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _serieService.GetById(id);
            vm.Genders = await _genderService.GetAll();
            vm.Producters = await _producterService.GetAll();

            
            return View("Add", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SerieSaveViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Genders = await _genderService.GetAll();
                vm.Producters = await _producterService.GetAll();
                return View("Add", vm);
            }
            vm.VideoURL = _convert.ConverterToEmbed(vm.VideoURL);
            await _serieService.Update(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _serieService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
