using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class WorkGenre
    {
        public int WorkId { get; set; }
        public int GenreId { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual Works Work { get; set; }
    }
}
