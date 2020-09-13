using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Genres
    {
        public Genres()
        {
            WorkGenre = new HashSet<WorkGenre>();
        }

        public int Id { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<WorkGenre> WorkGenre { get; set; }
    }
}
