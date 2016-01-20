using EnsureThat;
using Restponder.Models.MockServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restponder.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IMockServiceStore mockServiceStore;

        public ServiceController(IMockServiceStore mockServiceStore)
        {
            this.mockServiceStore = mockServiceStore;
        }

        public Task<MockService> GetService(string serviceID)
        {
            try
            {
                return mockServiceStore.FindByIDAsync(serviceID);
            }
            catch (KeyNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);              
            }
        }

        public async Task<HttpResponseMessage> GetServiceBody(string serviceID)
        {
            var service = await GetService(serviceID);

            return new HttpResponseMessage()
            {
                Content = new StringContent(service.Body)
                
                //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            };
        }

        public void CreateService(MockService service)
        {
            try
            {
                Ensure.That(service.Name, nameof(service.Name)).IsNotNullOrEmpty();
            }
            catch (ArgumentException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public void UpdateService(MockService service)
        {
            mockServiceStore.UpdateAsync(service);
        }

        public void DeleteService(string serviceID)
        {
            Go(() => mockServiceStore.DeleteAsync(serviceID));
        }

        private T Go<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (KeyNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (ArgumentException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        private void Go(Action action)
        {
            try
            {
                action();
            }
            catch (KeyNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (ArgumentException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

    }

    
}
