using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BenefitCard.Models
{
	public class Database : DbContext
	{
		public DbSet<Facility> Facilities { get; set; }
		//Dictionary<string,List<Facility>>
		public DbSet<Tuple<string, List<Facility>>> Activities { get; set; }


		//TODO
		public Database()
		{
			//this.Activities.
			LoadDatabase();
		}

		//TODO
		public void LoadDatabase()
		{
			//- konzultovat s dušanem
		}
	}
}
