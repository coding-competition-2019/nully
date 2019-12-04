using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCard.Models.JsonReader
{
    class Reader
    {
        public List<Facility> facilities = new List<Facility>();
        public void Read()
        {
               using (TextReader tr = new StreamReader(Environment.CurrentDirectory + @"\Models\Data\places.json"))
           // using (TextReader tr = new StreamReader("places.json"))
            {
                JsonTextReader reader = new JsonTextReader(tr);
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName && (reader.Value.ToString() == "places"))
                        {
                            reader.Read(); // startarray
                            reader.Read(); // startobject
                            while (reader.TokenType == JsonToken.StartObject)
                            {
                                facilities.Add(ReadFacility(reader));
                                reader.Read();
                            }
                        }
                    }
                }
            }
        }

        Facility ReadFacility(JsonTextReader tr)
        {
            Facility f = new Facility();

            tr.Read(); // name
            tr.Read();
            f.Name = tr.Value.ToString();

            tr.Read(); // url
            tr.Read();
            f.Url = tr.Value.ToString();

            tr.Read(); // address
            f.Address = ReadAdress(tr);
            f.Activities = ReadActivities(tr);
            return f;
        }

        Address ReadAdress(JsonTextReader tr)
        {
            Address a = new Address();

            tr.Read(); // startObject

            tr.Read(); //street
            tr.Read();
            a.Street = tr.Value.ToString();

            tr.Read(); // zipcode
            tr.Read();
            a.ZipCode = Int32.Parse(tr.Value.ToString());

            tr.Read(); // city
            tr.Read();
            a.City = tr.Value.ToString();

            tr.Read(); // EndObject

            return a;
        }

        List<string> ReadActivities(JsonTextReader tr)
        {
            List<string> a = new List<string>();

            tr.Read(); // activities
            tr.Read(); // startarray

            tr.Read();
            while (tr.TokenType != JsonToken.EndArray)
            {
                a.Add(tr.Value.ToString());
                tr.Read();
            }

            tr.Read(); // endobject

            return a;
        }
    }
}