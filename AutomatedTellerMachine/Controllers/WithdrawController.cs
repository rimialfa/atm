using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class WithdrawController : Controller
    {
        private IWithdrawal _service;
        public WithdrawController()
        {
            _service = new WithdrawalService();
        }
        [HttpPost]
        public ActionResult Index(int amount)
        {
            return Json(_service.Denominator(amount));
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuickCash()
        {
            return View();
        }
        public ActionResult CustomCash()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dispense(int amount)
        {
            return Json(_service.Dispensor(amount));
        }

    }
}
