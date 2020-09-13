using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Works = new HashSet<Works>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public DateTime? CreationDate { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string PictureName { get; set; }
        public bool IsTranslator { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Works> Works { get; set; }
    }
}
