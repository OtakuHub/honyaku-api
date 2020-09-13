using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Genres
    {
        public int GenreId { get; set; }
        public int WorkTitle { get; set; }
        public string Genre { get; set; }

        public virtual Works WorkTitleNavigation { get; set; }
    }
}
