using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Articles.Models;

namespace Articles.WebAPI.DataModels
{
    public class ArticleViewModel
    {
        public static Expression<Func<Article, ArticleViewModel>> FromArticle
        {
            get
            {
                return a => new ArticleViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category != null ? a.Category.Name : "",
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.Select(t => t.Name)
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}