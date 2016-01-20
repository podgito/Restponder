using Parse;

namespace Restponder.Models.MockServices
{
    public class MockService
    {
        public static MockService FromParseObject(ParseObject @object)
        {
            var service = new MockService();

            service.Key = @object["key"].ToString();
            service.Body = @object["body"].ToString();

            return service;
        }

        public string Key { get; set; } //Should the key be a property of this object?
        public string Body { get; set; }

        public string Name { get; set; }

        private MockService()
        {
        }

        public MockService(string key, string name, string body)
        {
            this.Key = key;
            this.Name = name;
            this.Body = body;
        }
    }
}