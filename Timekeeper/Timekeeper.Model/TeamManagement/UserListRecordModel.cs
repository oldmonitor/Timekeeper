using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model.TeamManagement
{
    public class UserListRecordModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
