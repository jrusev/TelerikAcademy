namespace Articles.WebAPI.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Articles.WebAPI.DataModels;
    using Articles.Data;
    using Articles.WebAPI.Models;

    [Authorize]
    public class TagsController : BaseApiController
    {
        public TagsController()
            : base(new ArticlesData())
        {
        }

        // GET api/tags
        [HttpGet]
        public IHttpActionResult Get()
        {
            var tags = this.data.Tags.All().Select(c => c.Name);
            return Ok(tags);
        }

        // GET api/tags/{tagID}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tag = this.data.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            var articles = tag.Articles.OrderBy(a => a.DateCreated).Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                Category = a.Category.Name,
                DateCreated = a.DateCreated,
                Tags = a.Tags.Select(t => t.Name)
            });

            return Ok(articles);
        }
    }
}
