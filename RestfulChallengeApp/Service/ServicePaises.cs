using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulChallengeApp.Models;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
namespace RestfulChallengeApp.Service
{
    public class ServicePaises
    {
        public static string Paises(string country)
        {
            var client = new RestClient("https://api.mercadolibre.com/classified_locations/countries/" + country.ToUpper());
            var request = new RestRequest(Method.GET);
            var content = client.Execute(request).Content;
            return content;
        }
    }
}
