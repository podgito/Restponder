using Moq;
using NUnit.Framework;
using Restponder.Controllers;
using Restponder.Models.MockServices;
using System;
using System.Net.Http;
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
        public void Post_Returns_Name_And_Key()
        {

        }

        [Test]
        public void CreateService_Requires_Name()
        {

        }

        [Test]
        public void CreateService_Does_Not_Require_Body()
        {

        }


        [Test]
        public void PostingABodyReturnsAValidAbsoluteURL()
        {
            //Arrange
            var key = "abcdef1234";
            var testData = "Test data";
            var serviceName = "service name";

            var mockService = new MockService(key, serviceName, testData);

            var responseRepository = new Mock<IMockServiceStore>();

            var controller = new DummyController(responseRepository.Object)
            {
                Request = request
            };

            responseRepository.Setup(x => x.CreateAsync(mockService));

            //dynamic service = new { name = "Unit test name" };

            //Act
            var returnedString = controller.Post(mockService);

            //Assert
            var url = new Uri(returnedString.ToString());

            Assert.IsTrue(url.IsAbsoluteUri);
        }

        [Test]
        public async Task PostReturnsUrlContainingResponseKey()
        {
            //Arrange
            var key = "abcdef1234";
            var testData = "Test data";

            var mockResponseRepository = new Mock<IMockServiceStore>();

            var mockService = new MockService("key", "name", "body");

            var controller = new DummyController(mockResponseRepository.Object)
            {
                Request = request
            };

            mockResponseRepository.Setup(r => r.CreateAsync(mockService));

            //Act
            var returnedString = await controller.Post(mockService);

            //Assert
            StringAssert.Contains(key, returnedString.ToString());
        }
    }
}