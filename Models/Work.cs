using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Work
    {
        public Work()
        {
            Comment = new HashSet<Comment>();
            WorkGenre = new HashSet<WorkGenre>();
            WorkTranslator = new HashSet<WorkTranslator>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<WorkGenre> WorkGenre { get; set; }
        public virtual ICollection<WorkTranslator> WorkTranslator { get; set; }
    }
}
