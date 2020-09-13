﻿using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class WorkGenre
    {
        public int Id { get; set; }
        public int? WorkId { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Work Work { get; set; }
    }
}
