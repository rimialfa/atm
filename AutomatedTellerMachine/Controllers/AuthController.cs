﻿using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class AuthController : Controller
    {
        private IAuthentication _service;
        public AuthController()
        {

            _service = new AuthenticationService();
        }
        public AuthController(IAuthentication service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel form)
        {
            Response auth = _service.Login(form.Number, form.Pin);

            return Json(auth, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Logout()
        {
            return View();
        }

    }
}