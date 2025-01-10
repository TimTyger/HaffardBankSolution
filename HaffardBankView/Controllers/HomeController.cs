using HaffardBankService.Services;
using HaffardBankView.Models;
using HaffardBankWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HaffardBankView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILookupService _lookUp;

        public HomeController(ILogger<HomeController> logger, ILookupService lookUp)
        {
            _logger = logger;
            _lookUp = lookUp;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDynamicFields(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                ModelState.AddModelError("", "Account number is required.");
                return View("GetAccountForm");
            }
            var fields = await _lookUp.GetFields(accountNumber);
            if (fields == null)
            {
                ViewBag.ErrorMessage = "No fields found for the given account number.";
                return View("Index");
            }
            return View("DynamicForm", fields);
        }

        public IActionResult DynamicForm()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
