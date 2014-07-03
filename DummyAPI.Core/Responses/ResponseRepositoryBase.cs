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

        string IResponseRepository.GetResponse(string responseId)
        {
            throw new NotImplementedException();
        }

        string IResponseRepository.SaveResponse(string response)
        {
            throw new NotImplementedException();
        }

        void IResponseRepository.UpdateResponse(string responseId, string response)
        {
            throw new NotImplementedException();
        }
    }
}
