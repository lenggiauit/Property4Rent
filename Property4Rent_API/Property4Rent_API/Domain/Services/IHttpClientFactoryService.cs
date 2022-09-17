using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services
{
    public interface IHttpClientFactoryService
    {
        Task<JObject> GetAsync(string url); 
    }
}
