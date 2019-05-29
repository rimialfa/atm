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
        // GET: Withdraw/Index/{amount}
        public ActionResult Index(int id)
        {
            Response response = _service.Dispensor(id);
            return Content(response.Message);
        }


    }
}