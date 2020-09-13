using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Genre
    {
        public Genre()
        {
            WorkGenre = new HashSet<WorkGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkGenre> WorkGenre { get; set; }
    }
}
