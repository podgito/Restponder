using System;
namespace DummyAPI.Core.Responses
{
    public interface IResponseRepository
    {
        /// <summary>
        /// Retrieves the response with the identifier inputted
        /// </summary>
        /// <param name="responseId">The alphanumeric identifier</param>
        /// <returns></returns>
        object GetResponse(string responseId);

        string SaveResponse(object response);
    }
}
