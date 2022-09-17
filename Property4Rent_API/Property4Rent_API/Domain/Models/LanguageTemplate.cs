using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Models
{
    public class LanguageTemplate
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public JObject Content { get;set;}
    }
}
