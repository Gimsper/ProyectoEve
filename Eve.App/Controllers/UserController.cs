using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Services.Interfaces;
using Eve.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Eve.Core.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDataViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ResultOperation<bool> response = _service.CheckCredentials(request);
            if (response.Result)
            {
                HttpContext.Session.SetString("UserLogin", JsonSerializer.Serialize(request));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = true;
                return View(request);
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ResultOperation<UserLogin> response = _service.Register(request);
            if (response.Result != null)
            {
                HttpContext.Session.SetString("UserLogin", JsonSerializer.Serialize(response.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.RegisterFail = true;
                return View(request);
            }
        }
    }
}
