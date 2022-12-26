using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {

        [BindProperty]
        public string Host { get; set; }
        public string Join { get; set; }
        public string Code { get; set; }
        [HttpGet]
        public Dictionary<string,string> OnGet()
        {
             var client = new RestClient("https://api.zoom.us/v2/users/me/meetings");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new 
            { topic = "Erp System",
              duration = "45",
              type = "2",
             setting =new {
              join_before_host = "1"
                }
              
              
            });
            request.AddHeader
            ("authorization", String.Format("Bearer {0}", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IjhXTmlldzNpVG02Yl9FUEI0MTRzUWciLCJleHAiOjE2NzcxMDI4NDAsImlhdCI6MTY0NTU2MTUzMX0.fnvkuLNZCD-ONCrlF3fOs3Rd21pOyUECwFFuNCX55Ow"));

            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            var jObject = JObject.Parse(restResponse.Content);
            Host = (string)jObject["start_url"];
            Join = (string)jObject["join_url"];
            Code = Convert.ToString(numericStatusCode);
            var id = (string)jObject["id"];
            var password = (string)jObject["password"];
            var start_url = (string)jObject["start_url"];
            Dictionary<string,string> result = new Dictionary<string, string>();
            result.Add("id", id);
            result.Add("password", password);
            result.Add("start_url", start_url);


            return result;
        }
    }
}
