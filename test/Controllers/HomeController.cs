using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<newmodel> userlist = new List<newmodel>();

        public IActionResult Index()
        {
            if (TempData["myData"] != null)
            {

                userlist = JsonConvert.DeserializeObject<List<newmodel>>((String)TempData["myData"]);
            }
            return View(userlist);
        }
        [HttpPost]
        public IActionResult adduser(newmodel m1)
        {
            string username =m1.Username;
            string password =m1.Password;

            return View("View");
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
