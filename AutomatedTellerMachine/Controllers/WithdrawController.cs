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
        // GET: Withdraw
        public ActionResult Index()
        {
            string st = _service.DispensorHelper(70, 10);
            return Content(st.Substring(0, st.LastIndexOf("+")));
        }

    }
}