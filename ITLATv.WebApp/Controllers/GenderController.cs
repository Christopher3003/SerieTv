using ITLATv.Application.Services;
using ITLATv.Application.ViewModels.Gender;
using ITLATv.Application.ViewModels.Producter;
using ITLATv.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLATv.WebApp.Controllers
{
    public class GenderController : Controller
    {
        private readonly GenderService _genderService;

        public GenderController(GenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAll());
        }

        public IActionResult Add() 
        {
            
            return View(new GenderSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(GenderSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _genderService.Add(vm);
            return RedirectToRoute(new {controller="Gender", action="Index"});
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _genderService.GetById(id);
            return View("Add", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(GenderSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {

                return View("Add", vm);
            }
            await _genderService.Update(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _genderService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _genderService.Delete(id);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }
    }
}
