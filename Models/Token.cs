﻿using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Token
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Value { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

        public virtual Users User { get; set; }
    }
}