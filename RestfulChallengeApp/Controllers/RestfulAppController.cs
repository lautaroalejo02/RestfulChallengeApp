using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulChallengeApp.Models;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace RestfulChallengeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestfulAppController : Controller
    {
        //Busqueda por paises.
        //En caso de que el pais sea CO o BR devolver el codigo 401 unauthorized access.
        //Se accede localhost:port/api/RestfulApp/paises/CodigoPais.
        [SwaggerOperation(Summary = "Devuelve informacion del pais especificado", Description = "Devuelve informacion del pais del pais especificado con el ID del pais. En caso de ser CO o BR devuelve un 401 unauthorized")]
        [SwaggerResponse(200, "Pais")]
        [HttpGet("[action]/{country}")]
        public IActionResult Paises(string country)
        {
            if (country == "CO")
            {
                return StatusCode(401);
            }
            else if (country == "BR")
            {
                return StatusCode(401);
            }
            else
            {
                var client = new RestClient("https://api.mercadolibre.com/classified_locations/countries/" + country);
                var request = new RestRequest(Method.GET);
                var content = client.Execute(request).Content;
                return Ok(content);
            }

        }
        //Busqueda de objetos.
        //Devuelve un json en el cual tenemos un array de results en el cual esta la informacion relevante para lo solicitado.
        //Se accede localhost:port/api/RestfulApp/paises/CodigoPais.
        [SwaggerOperation(Summary = "Busqueda de articulos.", Description = "Devuelve un json en el cual tenemos un array de results en el cual esta la informacion relevante para lo solicitado.")]

        [HttpGet("[action]/{item}")]
        public IActionResult Busqueda(string item)
        {
            var client = new RestClient("https://api.mercadolibre.com/sites/MLA/search?q=" + item);
            var request = new RestRequest(Method.GET);
            var content = client.Execute(request).Content;
            Search oSearch = new Search(content);
            return Ok(oSearch);
        }
       
    }
}
