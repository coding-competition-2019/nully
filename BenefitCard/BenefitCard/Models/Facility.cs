using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


        public Coordinates GetCoordinates(Facility f)
        {
            Coordinates c = new Coordinates();
            decimal lat;
            decimal lng;

            var client = new WebClient();
            using (var stream = client.OpenRead(GetLocationAPI(f.Address)))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("lat"))
                        {
                            c.Latitude = GetNumber(line);
                        }
                        else if (line.Contains("lng"))
                        {
                            c.Longtitude = GetNumber(line);

                        }
                    }
                    return c;
                }
            }
        }


        static string GetLocationAPI(Address ad)
        {
            string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
            url += ad.Street.Replace(' ', '+');
            url += ",";
            url += ad.City.Replace(' ', '+');
            url += @"&key=AIzaSyCHQFxLKLWMvOQR5cCjKxkWED2YH98V2G8";
            return url;
        }

        static decimal GetNumber(string s)
        {
            decimal num = 0;
            long counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 48 && s[i] <= 57)
                {
                    while (s[i] >= 48 && s[i] <= 57)
                    {
                        num += s[i] - 48;
                        num *= 10;
                        i++;
                    }

                    while (++i < s.Length && s[i] >= 48 && s[i] <= 57)
                    {
                        num += s[i] - 48;
                        num *= 10;

                        counter++;
                    }

                    for (int j = -1; j < counter; j++)
                    {
                        num /= 10;
                    }
                }
            }

            return num;
        }

    }
}
