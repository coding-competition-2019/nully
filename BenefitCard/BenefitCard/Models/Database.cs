using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BenefitCard.Models
{
	public class Database
	{
		public DbSet<Facility> Facilities { get; set; }
		//Dictionary<string,List<Facility>>
		public DbSet<Tuple<string, List<Facility>>> Activities { get; set; }


		//TODO
		public Database()
		{
			LoadDatabase();
		}

		//TODO
		public void LoadDatabase()
		{
			//- konzultovat s dušanem
		}
	}
}
