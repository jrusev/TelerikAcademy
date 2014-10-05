namespace Articles.WebAPI.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Articles.WebAPI.DataModels;
    using Articles.Data;

    [Authorize]
    public class CategoriesController : BaseApiController
    {
        public CategoriesController()
            : base(new ArticlesData())
        {
        }

        // GET api/categories
        [HttpGet]
        public IHttpActionResult Get()
        {
            var categories = this.data.Categories.All().Select(c => c.Name);
            return Ok(categories);
        }

        // GET api/categories/{categorID}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = this.data.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            var articles = this.data.Articles.All()
                .Where(a => a.CategoryId == category.Id)
                .OrderBy(a => a.DateCreated)
                .Select(ArticleViewModel.FromArticle);

            return Ok(articles);
        }
    }
}
