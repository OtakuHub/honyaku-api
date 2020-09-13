using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int ForTitle { get; set; }
        public int Author { get; set; }
        public string Comment { get; set; }

        public virtual Users AuthorNavigation { get; set; }
        public virtual Works ForTitleNavigation { get; set; }
    }
}
