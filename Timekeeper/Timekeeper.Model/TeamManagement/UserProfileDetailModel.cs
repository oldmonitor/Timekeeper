using System;
using System.Collections.Generic;
using System.Text;
using Timekeeping.Entity.Entities;

namespace Timekeeper.Model.TeamManagement
{
    public class UserProfileDetailModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhotoUrl { get; set; }

        public virtual ICollection<UserPhotoModel> UserPhotoes { get; set; }
    }
}
