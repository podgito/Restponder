using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restponder.Models.MockServices;
using Restponder.Models.Strings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

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
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(mockService.Body)

            };
            SetContentType(response, mockService.Body);
            return response;
        }

        private static void SetContentType(HttpResponseMessage response, string responseContent)
        {
            if (IsValidJson(responseContent))
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception) //some other exception
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }




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