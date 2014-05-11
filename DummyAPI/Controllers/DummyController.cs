using DummyAPI.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DummyAPI.Controllers
{
    public class DummyController : ApiController
    {
        private IResponseRepository responseRepository;

        public DummyController()
        {
            this.responseRepository = ResponseRepository.Instance;
        }

        public DummyController(IResponseRepository responseRepository)
        {
            this.responseRepository = responseRepository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public object Get(string id)
        {
            return responseRepository.GetResponse(id);
        }

        // POST api/<controller>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">http body</param>
        public object  Post([FromBody]object value)
        {
            var key = responseRepository.SaveResponse(value);


            var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = key });


            var uri = new Uri(uriString);


            var obj = new { url = uri.AbsoluteUri };

            return obj;
            //return "http://testurl.com";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}