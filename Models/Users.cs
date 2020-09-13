using System;
using System.Collections.Generic;

namespace honyaku_api.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Token = new HashSet<Token>();
            Works = new HashSet<Works>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsTranslator { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Token> Token { get; set; }
        public virtual ICollection<Works> Works { get; set; }
    }
}
