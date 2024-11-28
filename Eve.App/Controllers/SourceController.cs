using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Services.Interfaces;
using Eve.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Eve.App.Controllers
{
    public class SourceController : Controller
    {
        private readonly ISourceService _service;
        private readonly ICategoryService _categoryService;

        public SourceController(ISourceService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Source> response = _service.GetSourcesWithCategories().Results ?? new();
            return View(response);
        }

        public IActionResult Create()
        {
            List<Category> response = _categoryService.GetAll().Results ?? new();
            if (response.Count > 0)
            {
                ViewBag.SelectListCategories = new SelectList(response, "CategoryId", "Name");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            List<Category> responseC = _categoryService.GetAll().Results ?? new();
            if (responseC.Count > 0)
            {
                ViewBag.SelectListCategories = new SelectList(responseC, "CategoryId", "Name");
            }

            var response = _service.GetSourcesWithCategories().Results.Where(e => e.SourceId == id).First();

            if(response != null)
            {
                var sourceViewModel = new SourceEditViewModel
                {
                    SourceId = response.SourceId,
                    Name = response.Name,
                    Description = response.Description,
                    SourceType = response.SourceType,
                    CategoryId = response.Categories.First().CategoryId
                };
                return View(sourceViewModel);
            }

            return View(new SourceEditViewModel());
        }

        [HttpPost]
        public IActionResult Create(SourceViewModel request)
        {
            List<Category> responseC = _categoryService.GetAll().Results ?? new();
            if (responseC.Count > 0)
            {
                ViewBag.SelectListCategories = new SelectList(responseC, "CategoryId", "Name");
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            Source obj = new()
            {
                Name = request.Name,
                Description = request.Description,
                SourceType = request.SourceType,
                Categories = _categoryService.GetListBy(e => e.CategoryId == request.CategoryId).Results ?? new List<Category>()
            };

            ResultOperation<Source> response = _service.Add(obj);
            if (response.Result != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Fail = true;
                return View(request);
            }
        }

        [HttpPost]
        public IActionResult Edit(SourceEditViewModel request)
        {
            List<Category> responseC = _categoryService.GetAll().Results ?? new();
            if (responseC.Count > 0)
            {
                ViewBag.SelectListCategories = new SelectList(responseC, "CategoryId", "Name");
            }

            Source obj = new()
            {
                SourceId = request.SourceId,
                Name = request.Name,
                Description = request.Description,
                SourceType = request.SourceType,
                Categories = _categoryService.GetListBy(e => e.CategoryId == request.CategoryId).Results ?? new List<Category>()
            };

            ResultOperation<bool> response = _service.Update(obj);
            if (response.StateOperation)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Fail = true;
                return View(request);
            }
        }
    }
}
