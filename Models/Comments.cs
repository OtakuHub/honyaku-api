using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int Work { get; set; }
        public int Author { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users AuthorNavigation { get; set; }
        public virtual Works WorkNavigation { get; set; }
    }
}
