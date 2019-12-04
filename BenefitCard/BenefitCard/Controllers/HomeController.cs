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
			List<string> activitiesToShow = new List<string>();
			foreach (var activity in database.Activities)
			{
				activitiesToShow.Add(activity.Item1);
			}

			return View(activitiesToShow);

		}

		[HttpPost]
		public IActionResult ListPlaces(string[] choosenActivities)
		{
			//V tomhle jsou ty facility
			List<Facility> facilities = new List<Facility>();
			foreach (string activity in choosenActivities)
			{
				if (database != null)
				{
					var TupleOfActivity = database.Activities.Find(activity);

					foreach (var facility in TupleOfActivity.Item2)
					{
						facilities.Add(facility);
					}
				}
			}
			return View("TableActivities",facilities);
		}		
        
		[HttpPost]
		public IActionResult ShowDetail(int id)
		{
			Facility foundFacility;
			//FUJ
			foreach(var facility in database.Facilities)
			{
				if (facility.Id == id)
				{
					foundFacility = facility;
					break;
				}
			}



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
