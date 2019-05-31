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
        // POST: Withdraw/Index/{amount}
        [HttpPost]
        public ActionResult Index(int id)
        {
            return Json(_service.Dispensor(id));
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select()
        {
            return View();
        }
        public ActionResult Other()
        {
            return View();
        }
    }
}