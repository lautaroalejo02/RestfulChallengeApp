using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
namespace RestfulChallengeApp.Service
{
    public class ServiceBusqueda
    {
        public static string Paises(string item)
        {
            var client = new RestClient("https://api.mercadolibre.com/sites/MLA/search?q=" + item);
            var request = new RestRequest(Method.GET);
            var content = client.Execute(request).Content;
            return content;
        }
    }
}
