using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCard.Models
{
	public class Facility
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public Address Address { get; set; }
		public List<string> Activities { get; set; }
		public Coordinates Coordinates { get; set; }

        /*public Facility(string name, Address addr)
        {
            this.Name = name;
            this.Address = addr;
        }*/
	}
}
