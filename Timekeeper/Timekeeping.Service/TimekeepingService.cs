using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// timekeeping is for the last two weeks
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        public AssignmentTimekeepingModel GetAssignmentTimeKeepingModel(int assignmentId)
        {
            AssignmentTimekeepingModel assignmentTimekeepingModel = new AssignmentTimekeepingModel();
            this.GetAssignmentData(assignmentTimekeepingModel);

            //get weekly cycles for data entry
            assignmentTimekeepingModel.TimeKeepingCycles = this.GetTimeKeepingCycles(DateTime.Now.Date);

            //get tasks of given assignment
            List<AssignmentTask> tasks = this.GetAssignmentTasks(assignmentId);

            //get current timekeeping records in storage
            List<TimekeepingRecord> timekeepingRecords = this.GetTimeKeepingRecords
                (assignmentTimekeepingModel.AssignmentStartDate, assignmentTimekeepingModel.AssignmentEndDate);

            foreach(var task in tasks)
            {
                foreach(var cycle in assignmentTimekeepingModel.TimeKeepingCycles)
                {
                    DateTime recordDate = cycle.CycleStartDate.Date;
                    while(recordDate <= cycle.CycleEndDate.Date)
                    {
                        TimekeepingRecord record = timekeepingRecords.FirstOrDefault(x => x.AssignmentTaskId == task.AssignmentTaskId
                        && x.DateWorked.Date == recordDate.Date);
                        if(record != null)
                        {
                            record.TimeKeepingCycleNumber = cycle.TimeKeepingCycleNumber;
                        }
                        else
                        {
                            record = new TimekeepingRecord();
                            record.TimeKeepingCycleNumber = cycle.TimeKeepingCycleNumber;
                            record.AssignmentTaskId = task.AssignmentTaskId;
                            record.DateWorked = recordDate;
                            timekeepingRecords.Add(record);
                        }
                        recordDate = recordDate.AddDays(1);
                    }                    
                }
            }

            assignmentTimekeepingModel.TimekeepingRecords = timekeepingRecords;
            return assignmentTimekeepingModel;
        }

        /// <summary>
        /// Get timekeeping records (possibly from database)
        /// </summary>
        /// <returns></returns>
        public List<TimekeepingRecord> GetTimeKeepingRecords(DateTime periodBegin, DateTime periodEnd)
        {
            List<TimekeepingRecord> records = new List<TimekeepingRecord>();
            TimekeepingRecord testRecord = new TimekeepingRecord();
            testRecord.AssignmentTaskId = 1;
            testRecord.DateWorked = DateTime.Now.Date.AddDays(-7);
            testRecord.HoursWorked = 10;

            TimekeepingRecord testRecord2 = new TimekeepingRecord();
            testRecord2.AssignmentTaskId = 1;
            testRecord2.DateWorked = DateTime.Now.Date.AddDays(-8);
            testRecord2.HoursWorked = 20;

            records.Add(testRecord);
            records.Add(testRecord2);

            return records;
        }

        /// <summary>
        /// Get list of assignment task for given assignment(possibly from database)
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        public List<AssignmentTask> GetAssignmentTasks(int assignmentId)
        {
            List<AssignmentTask> tasks = new List<AssignmentTask>();
            //generate test data
            for (int i = 1; i<= 10; i++)
            {
                AssignmentTask task = new AssignmentTask();
                task.AssignmentTaskLookupName = "task" + i.ToString();
                task.AssignmentTaskId = assignmentId;
                task.DisplayOrder = i;
                task.AssignmentTaskLookupId = i;

                tasks.Add(task);
            }

            return tasks;
        }

        /// <summary>
        /// Get assignment data from database
        /// </summary>
        /// <param name="assignmentTimekeepingModel"></param>
        public void GetAssignmentData(AssignmentTimekeepingModel assignmentTimekeepingModel)
        {
            //set testing data
            assignmentTimekeepingModel.RequireHoursPerWeek = 25;
            assignmentTimekeepingModel.AssignmentStartDate = DateTime.Now.Date.AddDays(-25);
            assignmentTimekeepingModel.AssignmentEndDate = DateTime.Now.Date.AddDays(10);
        }
    }
}
