using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vertafore.Common.HttpClient;
using Newtonsoft.Json;

namespace DemoOrchestration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public object Get()
        {
            var url = "http://localhost:55542/api/hello";
            
            var response = HttpClientHelper.CallRestApiForObjectReponse<IEnumerable<string>>(url, HttpVerb.Get, null, null);

            var append = JsonConvert.DeserializeObject<IEnumerable<string>>(response.Result.ToString());

            var lastword = append.Last();

            return append.First() + lastword + " From Orchestration";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
