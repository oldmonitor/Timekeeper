using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model.TeamManagement
{
    public class UserPhotoModel
    {
        public int UserPhotoId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PhotoUrl { get; set; }
    }
}
