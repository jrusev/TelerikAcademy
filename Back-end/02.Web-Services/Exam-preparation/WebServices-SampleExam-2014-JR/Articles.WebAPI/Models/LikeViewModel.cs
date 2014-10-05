namespace Articles.WebAPI.Models
{
    using Articles.Models;
    using System;
    using System.Linq.Expressions;

    public class LikeViewModel
    {
        public static Expression<Func<Like, LikeViewModel>> FromLike
        {
            get
            {
                return like => new LikeViewModel { User = like.Author.UserName, };
            }
        }

        public string User { get; set; }
    }
}
