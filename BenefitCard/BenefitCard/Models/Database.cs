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
		public DbSet<Tuple<string, Facility>> Activities { get; set; }
	}
}
