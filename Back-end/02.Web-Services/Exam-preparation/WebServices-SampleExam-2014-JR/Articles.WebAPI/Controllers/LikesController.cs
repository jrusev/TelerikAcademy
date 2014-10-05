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
    public class LikesController : BaseApiController
    {
        public LikesController()
            : base(new ArticlesData())
        {
        }

        // POST api/articles/like/{articleID}
        [HttpPost]
        [Route("api/articles/like/{id}")]
        public IHttpActionResult Post(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return BadRequest("Article with such id does not exist!");
            }

            var userID = this.User.Identity.GetUserId();

            var like = this.data.Likes.All().FirstOrDefault(x => x.ArticleId == id && x.AuthorId == userID);
            if (like != null)
            {
                return BadRequest("This user has already liked this article!");
            }

            like = new Like
            {
                ArticleId = article.Id,
                AuthorId = userID,
            };

            this.data.Likes.Add(like);
            this.data.SaveChanges();

            return Ok();
        }

        // POST api/articles/like/{articleID}
        [HttpPut]
        [Route("api/articles/like/{id}")]
        public IHttpActionResult Put(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return BadRequest("Article with such id does not exist!");
            }

            var userID = this.User.Identity.GetUserId();

            var likes = this.data.Likes.All().Where(x => x.ArticleId == id && x.AuthorId == userID);

            foreach (var like in likes)
            {
                this.data.Likes.Delete(like);
            }
            
            this.data.SaveChanges();
            return Ok();
        }
    }
}
