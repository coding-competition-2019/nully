using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BenefitCard.Models;

namespace BenefitCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		Database database = new Database();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult ListActivities()
		{
			//database.Facilities.Add(new Facility());
			List<string> activities = new List<string>();
			activities.Add("Fotbal");
			activities.Add("Tenis");
			return View(activities);
		}

		[HttpPost]
		public IActionResult ListPlaces(string[] choosenActivities)
		{
			return View();
		}

		public IActionResult ShowDetail(Facility facility)
		{
			
			return View();
		}
        
        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TableActivities()
        {
            //List<Facility> activities = new List<Facility>();
            //Facility fac1 = new Facility("facility1",new Address("ulica1"));
            //Facility fac2 = new Facility("facility2", new Address("ulica2"));
            //activities.Add(fac1);
            //activities.Add(fac2);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


		public IActionResult ShowMap()
		{
			return View();
		}
	}
}
