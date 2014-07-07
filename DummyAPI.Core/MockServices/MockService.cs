using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyAPI.Core.MockServices
{
    public class MockService
    {

        public static MockService FromParseObject(ParseObject @object)
        {
            var service =  new MockService();

            service.Key = @object["key"].ToString();
            service.Body = @object["body"].ToString();

            return service;
        }

        public string Key { get; set; }
        public string Body { get; set; }


        private MockService() { }

        public MockService(string key, string body)
        {
            this.Key = key;
            this.Body = body;
        }

    }
}
