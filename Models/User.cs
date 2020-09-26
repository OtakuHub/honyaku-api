using System;
using System.Collections.Generic;
using honyaku_api.Data;

namespace honyaku_api.Models
{
    public partial class User : IEntity
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Token = new HashSet<Token>();
            WorkTranslator = new HashSet<WorkTranslator>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsTranslator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Token> Token { get; set; }
        public virtual ICollection<WorkTranslator> WorkTranslator { get; set; }
    }
}
