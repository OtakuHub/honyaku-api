using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? WorkId { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual User Author { get; set; }
        public virtual Work Work { get; set; }
    }
}
