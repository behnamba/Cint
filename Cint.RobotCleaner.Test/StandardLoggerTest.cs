using Cint.RobotCleaner.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Test
{
    [TestFixture]
    public class StandardLoggerTest
    {
        [Test, Description("Addlog method will add the point to visited places")]
        public void AddLog_WithValidPoint_AddPointToVisitedPlace() 
        {
            var sut = new StandardLogger();

            sut.AddLog(new Point(1, 1));

            Assert.AreEqual(1, sut.VisitedPoint.Count);
        }

        [Test, Description("Addlog method will add the point even if already exsists")]
        public void AddLog_WithPointWhichAlreadyExsits_AddPointToVisitedPlace()
        {
            var sut = new StandardLogger();

            sut.AddLog(new Point(1, 1));
            sut.AddLog(new Point(1, 1));

            Assert.AreEqual(2, sut.VisitedPoint.Count);
        }

        [Test, Description("When No Visited Points Are Equal, ReadLog will Return Counts Of VisitedPoints")]
        public void ReadLog_WhenNoVisitedPointsAreEqual_ReturnCountsOfVisitedPoints()
        {
            var sut = new StandardLogger();

            sut.AddLog(new Point(1, 1));
            sut.AddLog(new Point(2, 2));

            Assert.IsTrue(sut.ReadLog().EndsWith("2"));
        }

        [Test, Description("ReadLog will return the number of eunique VisitedPoints ")]
        public void ReadLog_WillReturnTheNumberOfEuniqueVisitedPoints()
        {
            var sut = new StandardLogger();

            sut.AddLog(new Point(1, 1));
            sut.AddLog(new Point(2, 2));
            sut.AddLog(new Point(2, 2));

            Assert.IsTrue(sut.ReadLog().EndsWith("2"));
        }
    }
}
