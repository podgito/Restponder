using Parse;
using Restponder.Models.Strings;
using System.Linq;
using System.Threading.Tasks;

namespace Restponder.Models.Responses
{
    public class ParseResponseRepository : IResponseRepository
    {
        static ParseResponseRepository()
        {
            ParseClient.Initialize("acWBnpz71jAHtUTit5CmDfXHz4zplEMFYYxJMiiV", "S2O2cUX4dOeniERKUkHhORqTwnwWD1T8zaSMW0Az");
        }

        public async Task<string> GetResponse(string key)
        {
            // Build a query
            var query = from post in ParseObject.GetQuery("Response")
                        where post.Get<string>("key") == key
                        //orderby post.CreatedAt descending
                        select post;

            // Retrieve the results
            var response = await query.FirstAsync().ConfigureAwait(false);

            return response["body"].ToString();
        }

        public string SaveResponse(string response)
        {
            //Create identifier
            var key = RandomStringGenerator.AlphaNumericString(10);

            //Check if this identifier has been created already ???? Necessary???
            var testObject = new ParseObject("Response");
            testObject["key"] = key;
            testObject["body"] = response;
            testObject.SaveAsync();

            return key;
        }

        string IResponseRepository.GetResponse(string responseId)
        {
            var key = GetResponse(responseId);
            //key.RunSynchronously();

            return key.Result;
        }

        public async void UpdateResponse(string key, string newResponseData)
        {
            var query = from post in ParseObject.GetQuery("Response")
                        where post.Get<string>("key") == key
                        //orderby post.CreatedAt descending
                        select post;

            // Retrieve the results
            var response = await query.FirstAsync().ConfigureAwait(false);

            response["body"] = newResponseData;

            await response.SaveAsync();
        }
    }
}