using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCard.Models
{
	public class Facility
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public Address Address { get; set; }
		public List<string> Activities { get; set; }
	}
}
