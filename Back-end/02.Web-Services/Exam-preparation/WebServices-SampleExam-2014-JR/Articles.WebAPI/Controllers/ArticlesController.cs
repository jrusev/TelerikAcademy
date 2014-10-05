namespace Articles.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

    using Articles.WebAPI.DataModels;
    using Articles.Data;
    using Articles.Models;
    using Articles.WebAPI.Models;

    [Authorize]
    public class ArticlesController : BaseApiController
    {
        const int defaultPageSize = 10;

        public ArticlesController()
            : base(new ArticlesData())
        {
        }

        public ArticlesController(IArticlesData data)
            : base(data)
        {
        }

        // GET api/articles
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(category: null, page: 0);
        }

        // GET api/articles?page=P
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            return Get(null, page);
        }

        // GET api/articles?category=[categoryName]
        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            return Get(category, 0);
        }

        // GET api/articles?category=[categoryName]&page=P
        [HttpGet]
        public IHttpActionResult Get(string category, int page)
        {
            var articles = GetAllSortedByDate()
                .Where(a => category != null ? a.Category == category : true)
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);

            return Ok(articles);
        }

        // GET api/articles/{articleID}
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new ArticleDetailsViewModel(article);
            return Ok(articleModel);
        }

        // POST api/articles
        [HttpPost]
        public IHttpActionResult Create(ArticleViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                return this.BadRequest("Article title cannot be null or empty!");
            }

            var userID = this.User.Identity.GetUserId();
            var tags = GetTags(model);
            var category = GetOrCreateCategory(model.Category);

            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                DateCreated = DateTime.Now,
                CategoryId = category.Id,
                AuthorId = userID,
                Tags = tags,
            };
            this.data.Articles.Add(article);
            this.data.SaveChanges();

            model.Id = article.Id;
            model.DateCreated = article.DateCreated;
            model.Tags = article.Tags.Select(t => t.Name);

            return this.CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // api/articles/{articleID}/comments
        [HttpPost]
        public IHttpActionResult Comment(int id, CommentViewModel model)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return BadRequest("Article with such id does not exist!");
            }

            var userID = this.User.Identity.GetUserId();
            var comment = new Comment
            {
                Article = article,
                AuthorId = userID,
                Content = model.Content,
                DateCreated = DateTime.Now
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            return Ok();
        }

        #region Helpers

        private ICollection<Tag> GetTags(ArticleViewModel article)
        {
            if (string.IsNullOrWhiteSpace(article.Title))
            {
                throw new ArgumentNullException("Article title cannot be null or empty!");
            }

            var titleTags = article.Title.Split(' ');
            var allTags = new HashSet<string>(titleTags);

            // Check if .Tags is not null
            foreach (var tag in article.Tags)
            {
                allTags.Add(tag);
            }

            var articleTags = new HashSet<Tag>();
            foreach (var tagName in allTags)
            {
                var tag = this.data.Tags.All().FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.data.Tags.Add(tag);
                }

                articleTags.Add(tag);
            }

            return articleTags;
        }

        private Category GetOrCreateCategory(string modelCategory)
        {
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == modelCategory);
            if (category == null)
            {
                category = new Category { Name = modelCategory };
                this.data.Categories.Add(category);
            }

            return category;
        }

        private IEnumerable<ArticleViewModel> GetAllSortedByDate()
        {
            return this.data.Articles.All()
                .OrderByDescending(a => a.DateCreated)
                .Select(ArticleViewModel.FromArticle);
        }
        #endregion
    }
}
