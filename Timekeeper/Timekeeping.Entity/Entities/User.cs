using System;
using System.Collections.Generic;

namespace Timekeeping.Entity.Entities
{
    public partial class User
    {
        public User()
        {
            UserPhotoes = new HashSet<UserPhoto>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<UserPhoto> UserPhotoes { get; set; }
    }
}
