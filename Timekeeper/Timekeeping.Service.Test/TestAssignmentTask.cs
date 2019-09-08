using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeping.Service.Test
{
    [TestClass]
    public class TestAssignmentTask
    {
        [TestMethod]
        public void TestGettingAssignmentTaskData()
        {
            TimekeepingService timekeepingService = new TimekeepingService();
            var assignmentModel = timekeepingService.GetAssignmentTimeKeepingModel(1);
            Assert.IsNotNull(assignmentModel);

        }

    }
}
