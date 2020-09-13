using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Works
    {
        public Works()
        {
            Comments = new HashSet<Comments>();
            Genres = new HashSet<Genres>();
        }

        public int WorkId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Translators { get; set; }

        public virtual Users TranslatorsNavigation { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Genres> Genres { get; set; }
    }
}
