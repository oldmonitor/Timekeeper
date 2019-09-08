using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model
{
    public class AssignmentTask
    {
        public int AssignmentTaskId { get; set; }

        //task lookup id value
        public int AssignmentTaskLookupId { get; set; }

        //task lookup name
        public string AssignmentTaskLookupName { get; set; }

        public int DisplayOrder { get; set; }

        /// <summary>
        /// timekeeping records for current task
        /// </summary>
        public List<TimekeepingRecord> TimekeepingRecords { get; set; }

        public AssignmentTask()
        {
            this.TimekeepingRecords = new List<TimekeepingRecord>();
        }
    }
}
