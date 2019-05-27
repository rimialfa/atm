using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private IAuthentication _service;
        private List<string> _cardAttempts = new List<string>();
        // GET /home/index 
        public HomeController()
        {
            _service = new AuthenticationService();
        }
        public HomeController(IAuthentication service)
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
            Auth auth = _service.Login(form.CardNumner, Convert.ToInt32(form.Pin));

            if (!auth.Status)
            {
                ViewBag.Message = auth.Message;
            }
            return View();

        }

    }
}