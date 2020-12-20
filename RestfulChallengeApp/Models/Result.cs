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
    public class Result
    {
        public Result(string json)
        {
        }
        public string Id { get; set; }
        public string Site_Id { get; set; }
        public string Title { get; set; }
        public Seller Seller { get; set; }
        public long Price { get; set; }
        public Uri Permalink { get; set; }


    }
    public class Seller
    {
        public long Id { get; set; }

    }
}

