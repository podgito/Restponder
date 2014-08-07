using DummyAPI.Core.MockServices;
using DummyAPI.Core.Responses;
using DummyAPI.Models.CustomBindings;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UtilityLibrary.Strings;


namespace DummyAPI.Controllers
{
    public class DummyController : ApiController
    {
        private IMockServiceStore mockServiceStore;

        public DummyController()
        {
            this.mockServiceStore = new ParseServiceStore();
        }

        public DummyController(IMockServiceStore mockServiceRepository)
        {
            this.mockServiceStore = mockServiceRepository;
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            var mockService = await mockServiceStore.FindByKeyAsync(id);
            return new HttpResponseMessage()
            {
                Content = new StringContent(mockService.Body)
            };
        }


        //public async System.Threading.Tasks.Task<object> Post(string name, [NakedBody]string rawBody)
        //{
            
        //    //var body = await Request.Content.ReadAsStringAsync();
        //    var key = RandomStringGenerator.AlphaNumericString(10);

        //    var mockService = new MockService(key, rawBody);

        //    var createServiceTask =  mockServiceStore.CreateAsync(mockService);


        //    var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = key });
        //    var editUrl = Url.Link("EditApi", new { controller = "Edit", id = key });

        //    var uri = new Uri(uriString);

        //    await createServiceTask;

        //    return new { url = uri.AbsoluteUri, key = key, editUrl = editUrl };

        //}

        public async System.Threading.Tasks.Task<object> Post(MockService mockService)
        {

            mockService.Key = RandomStringGenerator.AlphaNumericString(10);

            var createServiceTask = mockServiceStore.CreateAsync(mockService);

            var uriString = Url.Link("DefaultApi", new { controller = "Dummy", id = mockService.Key });
            var editUrl = Url.Link("EditApi", new { controller = "Edit", id = mockService.Key });

            var uri = new Uri(uriString);

            await createServiceTask;

            return new { url = uri.AbsoluteUri, key = mockService.Key, editUrl = editUrl, name = mockService.Name };

        }

        // PUT api/<controller>/5
        public async Task Put(string id)
        {
            var body = await Request.Content.ReadAsStringAsync();

            var mockService = new MockService(id, "", body);

            await mockServiceStore.UpdateAsync(mockService);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}