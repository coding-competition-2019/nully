using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BenefitCard.Models.JsonReader;

namespace BenefitCard.Models
{
	public class Database : DbContext
	{
		public DbSet<Facility> Facilities { get; set; }
		//Dictionary<string,List<Facility>>
		public DbSet<Tuple<string, List<Facility>>> Activities { get; set; }


        public Database()
        {
            LoadDatabase();

        }

        public void LoadDatabase()
        {
            int counter = 1;
            //- konzultovat s dušanem
            Reader reader = new Reader();
            reader.Read();

            foreach (Facility f in reader.facilities)
            {
                f.Id = counter++;
                Facilities.Add(f);

                foreach (string activity in f.Activities)
                {
                    AddActivity(activity, f);
                }
            }
        }

        void AddActivity(string activity, Facility f)
        {
            bool found = false;
            foreach (Tuple<string, List<Facility>> t in Activities)
            {
                if (t.Item1 == activity)
                {
                    found = true;
                    t.Item2.Add(f);
                }
            }

            if (found == false)
            {
                List<Facility> l = new List<Facility>();
                l.Add(f);

                Activities.Add(new Tuple<string, List<Facility>>(activity, l));
            }
        }
    }
}
