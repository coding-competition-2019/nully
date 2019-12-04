using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCard.Models.JsonReader
{
    public class Reader
    {
        string json = JsonConvert.SerializeObject(account, Formatting.Indented);
    }
}
