using System;
using System.Collections.Generic;

namespace Timekeeping.Entity.Entities
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CaseNumber { get; set; }
        public string Comment { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
