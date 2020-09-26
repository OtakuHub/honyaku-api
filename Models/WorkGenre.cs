using System;
using System.Collections.Generic;
using honyaku_api.Data;

namespace honyaku_api.Models
{
    public partial class WorkGenre : IEntity
    {
        public int Id { get; set; }
        public int? WorkId { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Work Work { get; set; }
    }
}
