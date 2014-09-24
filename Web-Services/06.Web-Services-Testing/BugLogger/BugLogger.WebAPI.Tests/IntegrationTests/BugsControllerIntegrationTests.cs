namespace BugLogger.RestApi.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    using BugLogger.Data;
    using BugLogger.Models;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void GetAll_WhenBugsInDb_ShouldReturnStatus200AndNonEmptyContent()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();
            Bug[] bugs = { new Bug(), new Bug(), new Bug() };

            Mock.Arrange(() => data.Bugs.All()).Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);

            var response = server.Get("/api/bugs");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsValid_ShouldReturn201AndLocationHeader()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = GetValidBug();

            Mock.Arrange(() => data.Bugs.Add(Arg.IsAny<Bug>()));

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);

            var response = server.Post("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsEmpty_ShouldReturn400()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = new Bug() { Text = "" };

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);

            var response = server.Post("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsNull_ShouldReturn400()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = new Bug() { Text = null };

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);

            var response = server.Post("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Bug GetValidBug()
        {
            return new Bug()
            {
                Id = rand.Next(1000, 2000),
                Text = "New Bug #" + rand.Next(1000, 2000)
            };
        }
    }
}