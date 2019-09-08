using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Model
{
    public class TimekeepingRecord
    {
        public int TimeKeepingCycleNumber
        {
            get;set;
        }

        public DateTime DateWorked { get; set; }

        public int? HoursWorked { get; set; }
    }
}
