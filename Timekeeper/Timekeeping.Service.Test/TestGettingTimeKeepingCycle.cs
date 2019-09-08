using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Timekeeping.Service.Test
{
    [TestClass]
    public class TestGettingTimeKeepingCycle
    {
        [TestMethod]
        public void TestGettingCyclesUsingMondayAsSelectedDate()
        {
            DateTime dt = DateTime.Parse("9/9/2019");
            TimekeepingService timekeepingService = new TimekeepingService();
            var cycles = timekeepingService.GetTimeKeepingCycles(dt);

            Assert.AreEqual(2, cycles.Count());

            Assert.AreEqual(2, cycles[0].CycleStartDate.Day);
            Assert.AreEqual(9, cycles[0].CycleStartDate.Month);

            Assert.AreEqual(26, cycles[1].CycleStartDate.Day);
            Assert.AreEqual(8, cycles[1].CycleStartDate.Month);

            Assert.AreEqual(DayOfWeek.Monday, cycles[0].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[0].CycleEndDate.DayOfWeek);

            Assert.AreEqual(DayOfWeek.Monday, cycles[1].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[1].CycleEndDate.DayOfWeek);

        }


        [TestMethod]
        public void TestGettingCyclesUsingWednesdayAsSelectedDate()
        {
            DateTime dt = DateTime.Parse("9/11/2019");
            TimekeepingService timekeepingService = new TimekeepingService();
            var cycles = timekeepingService.GetTimeKeepingCycles(dt);

            Assert.AreEqual(2, cycles.Count());

            Assert.AreEqual(2, cycles[0].CycleStartDate.Day);
            Assert.AreEqual(9, cycles[0].CycleStartDate.Month);

            Assert.AreEqual(26, cycles[1].CycleStartDate.Day);
            Assert.AreEqual(8, cycles[1].CycleStartDate.Month);

            Assert.AreEqual(DayOfWeek.Monday, cycles[0].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[0].CycleEndDate.DayOfWeek);

            Assert.AreEqual(DayOfWeek.Monday, cycles[1].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[1].CycleEndDate.DayOfWeek);

        }

        [TestMethod]
        public void TestGettingCyclesUsingSundayAsSelectedDate()
        {
            DateTime dt = DateTime.Parse("9/8/2019");
            TimekeepingService timekeepingService = new TimekeepingService();
            var cycles = timekeepingService.GetTimeKeepingCycles(dt);

            Assert.AreEqual(2, cycles.Count());

            Assert.AreEqual(2, cycles[0].CycleStartDate.Day);
            Assert.AreEqual(9, cycles[0].CycleStartDate.Month);

            Assert.AreEqual(26, cycles[1].CycleStartDate.Day);
            Assert.AreEqual(8, cycles[1].CycleStartDate.Month);

            Assert.AreEqual(DayOfWeek.Monday, cycles[0].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[0].CycleEndDate.DayOfWeek);

            Assert.AreEqual(DayOfWeek.Monday, cycles[1].CycleStartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, cycles[1].CycleEndDate.DayOfWeek);

        }

    }
}
