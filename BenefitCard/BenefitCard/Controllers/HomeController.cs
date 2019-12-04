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
				activitiesToShow.Add(activity.Key);
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
				if (database != null) //mělo by se vyřešit kdy je databaze null - dodělat pak
				{
					foreach (var facility in database.Activities[activity])
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

			if (!database.Facilities.ContainsKey(id))
			{
				// return ERROR VIEW
				return Error();
			}
			else
			{
				var facility = database.Facilities[id];


				return View(facility);
			}
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
