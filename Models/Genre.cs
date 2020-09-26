using System;
using System.Collections.Generic;
using honyaku_api.Data;

namespace honyaku_api.Models
{
    public partial class Genre : IEntity
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
