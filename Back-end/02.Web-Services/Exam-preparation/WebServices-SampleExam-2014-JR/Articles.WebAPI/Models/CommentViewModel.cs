using Articles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WebAPI.Models
{
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return c => new CommentViewModel
                {
                    AuthorName = c.Author.UserName,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    Id = c.Id
                };
            }
        }

        public int Id { get; set; }
        
        public string AuthorName { get; set; }

        public DateTime DateCreated { get; set; }
        
        public string Content { get; set; }
        //[Required]
        //public int ArticleID { get; set; }
    }
}
