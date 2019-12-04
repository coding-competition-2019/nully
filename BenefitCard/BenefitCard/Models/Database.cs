using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BenefitCard.Models.JsonReader;

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
            Reader reader = new Reader();
            reader.Read();

            foreach (Facility f in reader.facilities)
            {
                Facilities.Add(f);

                foreach (string activity in f.Activities)
                {
                    bool found = false;
                    foreach (Tuple<string, Facility> t in Activities)
                    {
                        if (t.Item1 == activity)
                        {
                            found = true;

                        }
                    }
                }
            }
        }
    }
}
