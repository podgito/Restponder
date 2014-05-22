using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyAPI.Core.Responses
{
    public abstract class ResponseRepositoryBase: IResponseRepository
    {
        public string GetResponse(string responseId)
        {
            throw new NotImplementedException();
        }

        public string SaveResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}
