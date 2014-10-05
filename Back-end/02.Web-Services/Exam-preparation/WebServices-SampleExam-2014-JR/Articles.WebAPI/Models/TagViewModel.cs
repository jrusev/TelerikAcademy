using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WebAPI.Models
{
    public class TagViewModel
    {
        public static Expression<Func<Tag, TagViewModel>> FromTag
        {
            get
            {
                return t => new TagViewModel
                {
                    ID = t.Id,
                    Name = t.Name
                };
            }
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}
