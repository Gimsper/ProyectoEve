using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Services.Interfaces;
using Eve.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Eve.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Category> response = _service.GetAll().Results ?? new();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Category response = _service.GetBy(e => e.CategoryId == id).Result ?? new();
            return View(response);
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            Category obj = new()
            {
                Name = request.Name
            };

            ResultOperation<Category> response = _service.Add(obj);
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
        public IActionResult Edit(Category request)
        {
            ResultOperation<bool> response = _service.Update(request);
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
