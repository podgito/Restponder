using DummyAPI.Controllers;
using DummyAPI.Core.Responses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace DummyAPI.Tests.Controllers
{
    [TestFixture]
    public class DummyControllerTests
    {
        private HttpConfiguration config;
        private HttpRequestMessage request;

        [SetUp]
        public void Setup()
        {
            //Context
            config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, "http://api.dummyapi.com");
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = config;
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpRouteDataKey] = new System.Web.Http.Routing.HttpRouteData(new System.Web.Http.Routing.HttpRoute());

        }

        [Test]
        public void PostingABodyReturnsAValidAbsoluteURL()
        {
            //Arrange
            var key = "abcdef1234";
            var testData = "Test data";

            var responseRepository = new Mock<IResponseRepository>();

            var controller = new DummyController(responseRepository.Object)
            {
                Request = request
            };

            responseRepository.Setup(x => x.SaveResponse(testData)).Returns(key);

            //Act
            var returnedString = controller.Post(testData);

            //Assert
            var url = new Uri(returnedString);

            Assert.IsTrue(url.IsAbsoluteUri);
        }

        [Test]
        public void PostReturnsUrlContainingResponseKey()
        {
            
            //Arrange
            var key = "abcdef1234";
            var testData = "Test data";

            var responseRepository = new Mock<IResponseRepository>();


            var controller = new DummyController(responseRepository.Object)
                {
                    Request = request
                };

            responseRepository.Setup(r => r.SaveResponse(testData)).Returns(key);

            //Act
            var returnedString = controller.Post(testData);


            //Assert
            StringAssert.Contains(key, returnedString);
 
        }



    }
}
