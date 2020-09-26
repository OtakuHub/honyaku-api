using System;
using System.Collections.Generic;
using honyaku_api.Data;

namespace honyaku_api.Models
{
    public partial class Token : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
