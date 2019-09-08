using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model
{
    public class TimekeepingRecord
    {
        //id of the record
        public int TimekeepingId { get; set; }
        public int TimeKeepingCycleNumber { get;set; }

        //associated AssignmentTaskId (ID in database) (parent id. one to many relation.)
        public int AssignmentTaskId { get; set; }

        public DateTime DateWorked { get; set; }

        public int? HoursWorked { get; set; }
    }
}
