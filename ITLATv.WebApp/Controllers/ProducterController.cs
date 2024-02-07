using ITLATv.Application.Services;
using ITLATv.Application.ViewModels.Producter;
using ITLATv.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLATv.WebApp.Controllers
{
    public class ProducterController : Controller
    {
        private readonly ProducterService _producterService;

        public ProducterController(ProducterService producterService)
        {
            _producterService = producterService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _producterService.GetAll());
        }

        public IActionResult Add() 
        {
            return View(new ProducterSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProducterSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _producterService.Add(vm);
            return RedirectToRoute(new {controller="Producter", action="Index"});
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _producterService.GetById(id);
            return View("Add", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProducterSaveViewModel vm)
        {
            if (!ModelState.IsValid) 
            {
                return View("Add",vm);
            }
            await _producterService.Update(vm);
            return RedirectToRoute(new { controller = "Producter", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _producterService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _producterService.Delete(id);
            return RedirectToRoute(new { controller = "Producter", action = "Index" });
        }
    }
}
