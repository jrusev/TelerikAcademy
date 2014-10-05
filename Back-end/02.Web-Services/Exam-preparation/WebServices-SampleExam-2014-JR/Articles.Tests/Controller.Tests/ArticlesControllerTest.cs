using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Routing;
using Telerik.JustMock;

using Articles.Data;
using Articles.Models;
using Articles.WebAPI.Controllers;
using Articles.WebAPI.DataModels;
using Articles.WebAPI.Models;
using System.Web.Http.Results;

namespace Acticles.Test
{
    [TestClass]
    public class ArticlesControllerTest
    {
        [TestMethod]
        public void GetAll_WhenArticlesInDb_ShouldReturnArticles()
        {
            Article[] articles = this.GenerateValidTestArticles(1);

            var data = Mock.Create<IArticlesData>();
            Mock.Arrange(() => data.Articles.All()).Returns(() => articles.AsQueryable());

            var controller = new ArticlesController(data);
            this.SetupController(controller);

            IHttpActionResult actionResult = controller.Get();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleViewModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAll_When16ArticlesInDb_ShouldReturn10Articles()
        {
            Article[] articles = this.GenerateValidTestArticles(16);

            var data = Mock.Create<IArticlesData>();
            Mock.Arrange(() => data.Articles.All()).Returns(() => articles.AsQueryable());

            var controller = new ArticlesController(data);
            this.SetupController(controller);

            var actionResult = controller.Get();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleViewModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable()
                .OrderByDescending(a => a.DateCreated)
                .Take(10)
                .Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        // Action returns 200 (OK) with a response body
        [TestMethod]
        public void GetById_ReturnsArticleWithCorrectId()
        {
            // Arrange
            int testId = 5;
            var data = Mock.Create<IArticlesData>();
            Mock.Arrange(() => data.Articles.Find(testId)).Returns(new Article() { Id = testId });
            var controller = new ArticlesController(data);

            // Act
            IHttpActionResult actionResult = controller.GetById(testId);
            var contentResult = actionResult as OkNegotiatedContentResult<ArticleDetailsViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(testId, contentResult.Content.Id);
        }

        #region Helpers
        private Article[] GenerateValidTestArticles(int count)
        {
            Article[] articles = new Article[count];
            var category = new Category() { Id = 1, Name = "Test Category" };

            var tags = new Tag[] { new Tag() { Id = 1, Name = "tag" } };

            for (int i = 0; i < count; i++)
            {
                var article = new Article
                {
                    Id = i,
                    Title = " Title #" + i,
                    Content = "The Content #" + i,
                    Category = category,
                    DateCreated = DateTime.Now,
                    Tags = tags,
                    Author = new User()
                };
                articles[i] = article;
            }

            return articles;
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.ControllerContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "articles" }
                    });
        }

        #endregion

    }
}
