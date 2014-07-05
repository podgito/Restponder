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


        public async Task<HttpResponseMessage> Get(string id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(await GetResponse(id))

            };
        }

        //public async void Put(string id)
        //{
        //    var input = await Request.Content.ReadAsStringAsync();

        //    responseRepository.UpdateResponse(id, input);
        //}

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


        public async System.Threading.Tasks.Task<object> Post()
        {
            
            var input = await Request.Content.ReadAsStringAsync();

            var key = responseRepository.SaveResponse(input);

            var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = key });

           

            var uri = new Uri(uriString);
            return new { url = uri.AbsoluteUri };

        }

        // PUT api/<controller>/5
        public async void Put(string id)
        {
            var input = await Request.Content.ReadAsStringAsync();

            var query = from post in ParseObject.GetQuery("Response")
                        where post.Get<string>("key") == id
                        //orderby post.CreatedAt descending
                        select post;

            // Retrieve the results
            var response = await query.FirstAsync().ConfigureAwait(false);


            response["body"] = input;

            await response.SaveAsync();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}