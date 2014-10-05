namespace Articles.WebAPI.Models
{
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    public class ArticleDetailsViewModel
    {
        public ArticleDetailsViewModel(Article article)
        {
            this.Id = article.Id;
            this.Title = article.Title;
            this.Content = article.Content;
            this.Category = article.Category != null ? article.Category.Name : "";
            this.DateCreated = article.DateCreated;
            this.Tags = article.Tags.Select(t => t.Name).ToArray();            
            this.Likes = article.Likes.AsQueryable().Select(LikeViewModel.FromLike).ToArray();
            this.Comments = article.Comments.AsQueryable()
                .OrderBy(c => c.DateCreated)
                .Take(10)
                .Select(CommentViewModel.FromComment)
                .ToArray();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<LikeViewModel> Likes { get; set; }
    }
}