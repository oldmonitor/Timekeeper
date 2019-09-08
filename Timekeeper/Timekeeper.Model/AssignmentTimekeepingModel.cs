using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model
{
    /// <summary>
    /// each assignment has multiple task activities. Activity hour needs to be tracked
    /// </summary>
    public class AssignmentTimekeepingModel
    {
        public int AssignmentId { get; set; }

        public DateTime AssignmentStartDate { get; set; }

        public DateTime AssignmentEndDate { get; set; }
       
        public int? RequireHoursPerWeek { get; set; }

        public List<TimeKeepingCycle> TimeKeepingCycles
        {
            get;set;
        }

        public List<TimekeepingRecord> TimekeepingRecords
        {
            get;set;
        }

        public AssignmentTimekeepingModel()
        {
            this.TimeKeepingCycles = new List<TimeKeepingCycle>();
            this.TimekeepingRecords = new List<TimekeepingRecord>();
        }

    }
}
