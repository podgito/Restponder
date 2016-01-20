using Moq;
using NUnit.Framework;
using Restponder.Controllers;
using Restponder.Models.MockServices;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DummyAPI.Tests.Controllers
{
    [TestFixture]
    public class ServiceControllerTests
    {
        private Mock<IMockServiceStore> mockServiceStore;
        private ServiceController serviceController;
        private MockService existingMockService;
        private MockService newMockService;

        private const string randomServiceID = "blaSomeRandomKey";
        private const string someJson = @"{""age"": 28 }";

        [SetUp]
        public void Setup()
        {
            const string existingServiceID = "hasf0saf9sdf";
            const string existingServiceName = "My Service Name";
            const string existingServiceBody = someJson;
            mockServiceStore = new Mock<IMockServiceStore>();

            existingMockService = new MockService(existingServiceID, existingServiceName, existingServiceBody);

            newMockService = new MockService(null, "newName", "[]");

            mockServiceStore.Setup(s => s.FindByIDAsync(randomServiceID)).Throws(new KeyNotFoundException());
            mockServiceStore.Setup(s => s.FindByIDAsync(existingMockService.Key)).ReturnsAsync(existingMockService);
            mockServiceStore.Setup(s => s.DeleteAsync(randomServiceID)).Throws(new KeyNotFoundException());
            serviceController = new ServiceController(mockServiceStore.Object);
        }

        [Test]
        public async Task GetService_Returns_Service()
        {
            //Act
            var service = await serviceController.GetService(existingMockService.Key);

            //Assert
            Assert.AreEqual(existingMockService, service);
        }

        [Test]
        public async Task GetServiceBody_Returns_Body_Of_Service()
        {
            //Act
            var response = await serviceController.GetServiceBody(existingMockService.Key);

            //Assert
            Assert.AreEqual(existingMockService.Body, await response.Content.ReadAsStringAsync());
        }

        [Test]
        [TestCase(someJson, "application/json")]
        [TestCase("bla", "text/plain")]
        public async Task GetServiceBody_Returns_ContentType_Matching_The_Body_Type(string body, string contentType)
        {
            //Arrange
            const string testMockID = "someID";
            var testMock = new MockService(testMockID, "name", body);

            mockServiceStore.Setup(s => s.FindByIDAsync(testMockID)).ReturnsAsync(testMock);

            //Act
            var response = await serviceController.GetServiceBody(testMockID);

            response.Content.Headers.ContentType.MediaType.ShouldBe(contentType);
        }

        [Test]
        public void GetService_With_Invalid_ID_Returns_404()
        {
            //Act
            var exception = Assert.Throws<HttpResponseException>(() => serviceController.GetService(randomServiceID));

            //Assert
            exception.Response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Test] //need to fix this (NUnit bug???)
        public void GetServiceBody_With_Invalid_ID_Returns_404()
        {
            //Act
            var exception = Assert.Throws<HttpResponseException>(() => serviceController.GetServiceBody(randomServiceID));

            //Assert
            exception.Response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Test]
        public void CreateService_Requires_Name()
        {
            var serviceWithNoName = new MockService(null, null, "someBody");

            var exception = Assert.Throws<HttpResponseException>(() => serviceController.CreateService(serviceWithNoName));

            exception.Response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void CreateService_Does_Not_Require_Body()
        {
            var serviceWithNoBody = new MockService(null, "MyService", null);

            serviceController.CreateService(serviceWithNoBody);
        }

        [Test]
        public void CreateService_Returns_Service_ID()
        {
            Assert.Fail("TODO"); //how to return the service ID????
        }

        [Test]
        public void UpdateService_Updates_Service_In_Repository()
        {
            serviceController.UpdateService(existingMockService);

            mockServiceStore.Verify(s => s.UpdateAsync(existingMockService), Times.Once);
        }

        [Test]
        public void DeleteService_Deletes_Service()
        {
            //Act
            serviceController.DeleteService(existingMockService.Key);

            //Assert
            mockServiceStore.Verify(s => s.DeleteAsync(existingMockService.Key), Times.Once);
        }

        [Test]
        public void DeleteService_With_Invalid_ID_Returns_404()
        {
            var exception = Assert.Throws<HttpResponseException>(() => serviceController.DeleteService(randomServiceID));

            exception.Response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}