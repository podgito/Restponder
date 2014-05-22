using DummyAPI.Core.Responses;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace DummyAPI.Controllers
{
    public class DummyController : ApiController
    {
        private IResponseRepository responseRepository;

        public DummyController()
        {
            //this.responseRepository = ResponseRepository.Instance;
            this.responseRepository = new ParseResponseRepository();
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
        public HttpResponseMessage oldGet(string id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(responseRepository.GetResponse(id))

            };
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(await GetResponse(id))

            };
        }

        private async Task<string> GetResponse(string key)
        {
            // Build a query
            var query = from post in ParseObject.GetQuery("Response")
                        where post.Get<string>("key") == key
                        orderby post.CreatedAt descending
                        select post;

            // Retrieve the results
            var response = await query.FirstOrDefaultAsync();

            return response["body"].ToString();
        }

        // POST api/<controller>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">http body</param>
        //public object  Post([FromBody]object value)
        //{
        //    var key = responseRepository.SaveResponse(value);


        //    var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = key });


        //    var uri = new Uri(uriString);


        //    var obj = new { url = uri.AbsoluteUri };

        //    return obj;
        //    //return "http://testurl.com";
        //}

        public async System.Threading.Tasks.Task<object> Post()
        {
            
            var input = await Request.Content.ReadAsStringAsync();

            var key = responseRepository.SaveResponse(input);

            var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = key });

           

            var uri = new Uri(uriString);
            return new { url = uri.AbsoluteUri };

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