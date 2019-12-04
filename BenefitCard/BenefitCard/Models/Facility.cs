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

        /*/public Facility(string name, Address addr,string url, List<string> activities)
        {
            this.Name = name;
            this.Address = addr;
            this.Activities = activities;
            this.Url = url;
        }/**/


        static string GetLocationAPI(Address ad)
        {
            string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
            url += ad.Street.Replace(' ', '+');
            url += ",";
            url += ad.City.Replace(' ', '+');
            url += @"&key=AIzaSyCHQFxLKLWMvOQR5cCjKxkWED2YH98V2G8";    
            return url;
        }
	}
}
