using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class WorkTranslator
    {
        public int Id { get; set; }
        public int? WorkId { get; set; }
        public int? TranslatorId { get; set; }

        public virtual User Translator { get; set; }
        public virtual Work Work { get; set; }
    }
}
