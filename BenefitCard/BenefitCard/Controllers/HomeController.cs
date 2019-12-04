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

		public IActionResult ListActivities(string chosenActivity, List<string> PickedActivities)
		{
			if (!PickedActivities.Contains(chosenActivity))
			{
				PickedActivities.Add(chosenActivity);
			}

			return View(PickedActivities);
		}

		[HttpPost]
		public IActionResult ListPlaces(string[] choosenActivities)
		{
			//V tomhle jsou ty facility
			List<Facility> facilities = new List<Facility>();

			foreach (string UserActivity in choosenActivities)
			{
				if (database != null) //mělo by se vyřešit kdy je databaze null - dodělat pak
				{

					foreach(var activity in database.Activities.Keys)
					{
						//chceks for activities that suits user defined activity
						if (CheckSubstring(UserActivity, activity))
						{
							//adds all the facilities providing chosen activity
							foreach (var facility in database.Activities[activity])
							{
								facilities.Add(facility);
							}
						}
					}

				}
			}
			return View("TableActivities", facilities);
		}		


		/// <summary>
		/// HelperFunction - finding substrings
		/// </summary>
		private bool CheckSubstring(string subString, string mainString)
		{
			int M = subString.Length;
			int N = mainString.Length;

			for (int i = 0; i <= N - M; i++)
			{
				int j;

				for (j = 0; j < M; j++)
					if (mainString[i + j] != subString[j])
						break;

				if (j == M)
					return true;
			}
			return false;
		}
        
		public IActionResult ShowDetail(int id = 0)
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
