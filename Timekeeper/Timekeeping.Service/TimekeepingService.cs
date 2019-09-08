using System;
using System.Collections.Generic;
using System.Text;
using Timekeeper.Model;

namespace Timekeeping.Service
{
    public class TimekeepingService
    {
        /// <summary>
        /// timekeeping cycles are two previous week given date. Cycle starts on Monday
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<TimeKeepingCycle> GetTimeKeepingCycles
            (DateTime selectedDate)
        {
            List<TimeKeepingCycle> cycles = new List<TimeKeepingCycle>();

            DateTime cycleDate;
            TimeKeepingCycle cycle;
            selectedDate = selectedDate.Date;

            //week begins on sunday
            for (int i = 1; i<=2; i++)
            {
                cycleDate = selectedDate.AddDays(-1 * i * 7);
                DateTime cycleStart = cycleDate.AddDays(-(int)cycleDate.DayOfWeek + (int)DayOfWeek.Monday);
                DateTime cycleEnd = cycleStart.AddDays(6);
                cycle = new TimeKeepingCycle()
                {
                    CycleStartDate = cycleStart,
                    CycleEndDate = cycleEnd,
                    TimeKeepingCycleNumber = i
                };
                cycles.Add(cycle);
            }

            return cycles;
        }


        //public AssignmentTimekeepingModel Get
    }
}
