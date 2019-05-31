using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class AccountController : Controller
    {
        private IAccount _service;
        public AccountController()
        {
            _service = new AccountService();
        }
        public AccountController(IAccount service)
        {
            _service = service;
        }
        public ActionResult MainMenu()
        {
            return View();
        }
        public ActionResult GetAccount()
        {
            return Json(_service.GetAccount(_service.GetSession()), JsonRequestBehavior.AllowGet);
        }
    }
}