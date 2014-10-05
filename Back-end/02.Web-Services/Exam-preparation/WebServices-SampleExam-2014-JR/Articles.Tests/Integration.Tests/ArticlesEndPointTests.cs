namespace BugLogger.RestApi.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    using Articles.Data;
    using Articles.Models;

    [TestClass]
    public class ArticlesEndPointTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void GetAll_WhenArticlesInDb_ShouldReturnStatus200AndNonEmptyContent()
        {
            IArticlesData data = Mock.Create<IArticlesData>();
            Article[] articles = { new Article() { DateCreated = DateTime.Now } };
            Mock.Arrange(() => data.Articles.All()).Returns(() => articles.AsQueryable());

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);
            var response = server.Get("/api/articles");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostArticle_WhenValid_ShouldReturn201AndLocationHeader()
        {
            IArticlesData data = Mock.Create<IArticlesData>();

            Article article = new Article() { Title = "Test", DateCreated = DateTime.Now };
            Mock.Arrange(() => data.Articles.Add(Arg.IsAny<Article>()));

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);
            var response = server.Post("/api/articles", article);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostArticle_WhenTitleIsEmpty_ShouldReturn400()
        {
            IArticlesData data = Mock.Create<IArticlesData>();

            Article article = new Article() { DateCreated = DateTime.Now };
            Mock.Arrange(() => data.Articles.Add(Arg.IsAny<Article>()));

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);
            var response = server.Post("/api/articles", article);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}