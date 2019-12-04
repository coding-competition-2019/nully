using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCard.Models.JsonReader
{
    class Place
    {
        string name;
        string url;
        Address adress;
        List<string> activities;
    }

    public class Reader
    {
        public void Read()
        {

            using (TextReader tr = new StreamReader(@"Data/places.json"))
            {
                JsonTextReader reader = new JsonTextReader(tr);
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    }
                    else
                    {
                        Console.WriteLine("Token: {0}", reader.TokenType);
                    }
                }
            }
        }
    }
}