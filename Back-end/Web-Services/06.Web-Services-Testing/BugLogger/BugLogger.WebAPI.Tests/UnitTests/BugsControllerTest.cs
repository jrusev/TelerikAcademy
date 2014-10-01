namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using BugLogger.Data;
    using BugLogger.Models;
    using BugLogger.WebAPI.Controllers;
    using BugLogger.WebAPI.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;
    using System.Web.Http.Results;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnAllBugs()
        {
            Bug[] bugs =
            {
                new Bug() { Text = "First bug" },
                new Bug() { Text = "Second bug" }
            };

            var controller = SetupController(bugs);

            var actionResult = controller.Get();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = bugs.AsQueryable().Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetById_WhenValid_ShouldReturnTheObjectWithCorrectId()
        {
            int testId = 5;
            Bug[] bugs =
            {
                new Bug()
                {
                    Id = testId,
                    Text = "First bug"
                }
            };

            var controller = SetupController(bugs);

            var actionResult = controller.Get(testId);
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var bugModel = response.Content.ReadAsAsync<BugModel>().Result;

            var actual = bugModel.Id;
            var expected = testId;

            Assert.AreEqual(testId, actual);
        }

        // Action returns 200 (OK) with a response body
        [TestMethod]
        public void GetById_ReturnsBugWithSameId()
        {
            // Arrange
            int testId = 5;
            var data = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => data.Bugs.Find(testId)).Returns(new Bug() { Id = testId });
            var controller = new BugsController(data);

            // Act
            IHttpActionResult actionResult = controller.Get(testId);
            var contentResult = actionResult as OkNegotiatedContentResult<BugModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(testId, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetByStatus_WhenValid_ShouldReturnAllWithThisStatus()
        {
            Bug[] bugs =
            {
                new Bug()
                {
                    Text = "First bug",
                    Status = BugStatus.Assigned
                },
                new Bug()
                {
                    Text = "Second bug",
                    Status = BugStatus.Pending
                }
            };

            var controller = SetupController(bugs);

            var actionResult = controller.GetByStatus("Pending");
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = bugs.AsQueryable().Where(b => b.Status == BugStatus.Pending).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetByDate_WhenValid_ShouldReturnCollectionMemberWithCorrespondingStatus()
        {
            var now = DateTime.Now;
            Bug[] bugs =
            {
                new Bug()
                {
                    Text = "First bug",
                    LogDate = now.AddDays(-1)
                },
                new Bug()
                {
                    Text = "Second bug",
                    LogDate = now.AddDays(1)
                }
            };

            var controller = SetupController(bugs);

            var actionResult = controller.GetByDate(now.ToString());
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(b => b.LogDate).ToList();
            var expected = bugs.AsQueryable().Where(b => b.LogDate >= now).Select(b => b.LogDate).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            var bugs = new List<Bug>();

            var bug = new Bug()
            {
                Text = "NEW TEST BUG"
            };

            var data = Mock.Create<IBugLoggerData>();

            Mock.Arrange(() => data.Bugs.All()).Returns(() => bugs.AsQueryable());

            Mock.Arrange(() => data.Bugs.Add(Arg.IsAny<Bug>())).DoInstead((Bug b) => bugs.Add(b));

            bool saveChangesIsCalled = false;
            Mock.Arrange(() => data.SaveChanges()).DoInstead(() => { saveChangesIsCalled = true; });

            var controller = new BugsController(data);
            this.ConfigureController(controller);

            //act
            controller.Post(bug);

            //assert
            Assert.AreEqual(data.Bugs.All().Count(), 1);
            var bugInDb = data.Bugs.All().FirstOrDefault();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(BugStatus.Pending, bugInDb.Status);
            Assert.IsTrue(saveChangesIsCalled);
        }

        private BugsController SetupController(IEnumerable<Bug> bugs)
        {
            var data = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => data.Bugs.All()).Returns(() => bugs.AsQueryable());

            Mock.Arrange(
                () => data.Bugs.Find(Arg.IsAny<int>()))
                .Returns((int id) => bugs.FirstOrDefault(b => b.Id == id));

            var controller = new BugsController(data);
            this.ConfigureController(controller);
            return controller;
        }

        private void ConfigureController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}