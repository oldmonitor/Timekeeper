using System;
using System.Collections.Generic;

namespace Timekeeping.Entity.Entities
{
    public partial class UserPhoto
    {
        public int UserPhotoId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PhotoUrl { get; set; }

        public virtual User User { get; set; }
    }
}
