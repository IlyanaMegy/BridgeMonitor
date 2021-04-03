using BridgeMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace BridgeMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SoonClosing()
        {
            var hours = GetClosingHoursListFromApi();
            return View(hours);
        }

        public IActionResult AllClosing()
        {
            var hours = GetClosingHoursListFromApi();
            return View(hours);
        }

        public IActionResult ClosingDetails()
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
        private static readonly HttpClient client = new HttpClient();
        private static List<Hours> GetClosingHoursListFromApi()
        {
            var stringTask = client.GetStringAsync("https://api.alexandredubois.com/pont-chaban/api.php");
            var MyJsonRes = stringTask.Result;
            var result = JsonConvert.DeserializeObject<List<Hours>>(MyJsonRes);
            List<Hours> SortedList = result.OrderBy(o => o.ClosingDate).ToList();
            return SortedList;
        }
    }
}
