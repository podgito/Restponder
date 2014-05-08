using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Strings;

namespace DummyAPI.Core.Responses
{
    public sealed class ResponseRepository : DummyAPI.Core.Responses.IResponseRepository
    {
        private static volatile ResponseRepository instance;

        private static object syncRoot = new Object();

        private Dictionary<string, string> responses;

        private ResponseRepository() { }

        public static ResponseRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResponseRepository();
                    }
                }
                return instance;
            }
        }

        public string GetResponse(string responseId)
        {
            return responses[responseId];
        }


        public string SaveResponse(string response)
        {
            //Create identifier
            var identifier = RandomStringGenerator.AlphaNumericString(10);

            while(!responses.ContainsKey(identifier))
            {
                identifier = RandomStringGenerator.AlphaNumericString(10);
            }

            responses.Add(identifier, response);

            return identifier;
        }
    }

//    using System;

//public sealed class Singleton
//{
//   private static volatile Singleton instance;
//   private static object syncRoot = new Object();

//   private Singleton() {}

//   public static Singleton Instance
//   {
//      get 
//      {
//         if (instance == null) 
//         {
//            lock (syncRoot) 
//            {
//               if (instance == null) 
//                  instance = new Singleton();
//            }
//         }

//         return instance;
//      }
//   }
//}
}
