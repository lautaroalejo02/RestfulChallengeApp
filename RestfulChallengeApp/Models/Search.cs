using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Newtonsoft.Json.Converters;
namespace RestfulChallengeApp.Models
{
    public class Search
    {
        public Search(string json)
        {
            JObject jObject = JObject.Parse(json);
            site_id = (string)jObject["site_id"];
            query = (string)jObject["query"];
            JToken ResultadosP = jObject["paging"];
            paging = JsonConvert.DeserializeObject<dynamic>(ResultadosP.ToString());
            JToken Resultados2 = jObject["results"];
            Resultados = JsonConvert.DeserializeObject<List<Result>>(Resultados2.ToString());
        }
        [JsonProperty("site_id")]
        public string site_id { get; set; }
        [JsonProperty("query")]
        public string query { get; set; }
        [JsonProperty("paging")]

        public dynamic paging { get; set; }
        [JsonProperty("results")]
        public List<Result> Resultados { get; set; }

    }
    public partial class Paging
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("primary_results")]
        public long PrimaryResults { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }
    }
}
