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
        public List<TimeKeepingCycle> TimeKeepingCycles
        {
            get;set;
        }

        public List<TimekeepingRecord> TimekeepingRecords
        {
            get;set;
        }

    }
}
