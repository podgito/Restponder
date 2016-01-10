using Parse;
using System.Linq;
using System.Threading.Tasks;

namespace Restponder.Models.MockServices
{
    public class ParseServiceStore : IMockServiceStore
    {
        static ParseServiceStore()
        {
            ParseClient.Initialize("acWBnpz71jAHtUTit5CmDfXHz4zplEMFYYxJMiiV", "S2O2cUX4dOeniERKUkHhORqTwnwWD1T8zaSMW0Az");
        }

        public async Task<MockService> FindByKeyAsync(string key)
        {
            var dbServiceObject = await FindbyKey(key);

            return MockService.FromParseObject(dbServiceObject);
        }

        private Task<ParseObject> FindbyKey(string key)
        {
            var query = from post in ParseObject.GetQuery("MockService")
                        where post.Get<string>("key") == key
                        select post;

            return query.FirstAsync();
        }

        public async Task UpdateAsync(MockService mockResponse)
        {
            var service = await FindbyKey(mockResponse.Key);

            service["body"] = mockResponse.Body;
            await service.SaveAsync();
        }

        public Task CreateAsync(MockService mockResponse)
        {
            var dbMockResponse = new ParseObject("MockService");
            dbMockResponse["key"] = mockResponse.Key;
            dbMockResponse["body"] = mockResponse.Body;
            dbMockResponse["name"] = mockResponse.Name;
            return dbMockResponse.SaveAsync();
        }
    }
}