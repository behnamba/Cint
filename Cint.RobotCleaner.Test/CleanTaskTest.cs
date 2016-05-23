using Cint.RobotCleaner.Common.Exceptions;
using Cint.RobotCleaner.Domain;
using Cint.RobotCleaner.Domain.Base;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Test
{
    [TestFixture]
    public class CleanTaskTest
    {
        Mock<ILogger> _Logger;

        [SetUp]
        public void Init()
        {
            _Logger = new Mock<ILogger>();
            _Logger.Setup(x => x.AddLog(new Point(0, 0)));
            _Logger.Setup(x => x.ReadLog()).Returns("");
        }

        [TearDown]
        public void Dispose()
        {
        }

        [Test, Description("Create CleanTask object with valid input and properties set as expected")]
        public void CreateCleanTask_WithValidInput_PropertiesSetCorrectly()
        {
            CleanTask sut = new CleanTask("E 12");

            int actualSteps = sut.Steps;
            Assert.AreEqual(12, actualSteps);

            Direction direction = sut.Direction;
            Assert.AreEqual(direction, Direction.E);
        }

        [Test, Description("Create CleanTask object with negetive steps cause to set steps as minimum defined ")]
        public void CreateCleanTask_WithNegetiveSteps_StepsSetAsMinimumDefinedSteps()
        {
            CleanTask sut = new CleanTask("E -1");

            int actualSteps = sut.Steps;
            Assert.AreEqual(CleanTask.MinSteps, actualSteps);
        }

        [Test, Description("Create CleanTask object with invalid direcection will throw exception")]
        public void CreateCleanTask_WithInvalidDirection_ThrowException()
        {
            Assert.Throws<InvalidEnumTypeInception>(() => { CleanTask sut = new CleanTask("X 12"); });
        }

        [Test, Description("Create CleanTask object with command without space will throw exception")]
        public void CreateCleanTask_WithInvalidCommandWithoutSpace_ThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => { CleanTask sut = new CleanTask("N12"); });
        }

        [Test, Description("Create CleanTask object with command which contains too many space will throw exception")]
        public void CreateCleanTask_WithTooManySpace_ThrowException()
        {
            Assert.Throws<FormatException>(() => { CleanTask sut = new CleanTask("N    12"); });
        }

        [Test, Description("Do clean will increase Y of point with move to up command")]
        public void DoClean_WithOneMoveToUPCommand_ChangeThePositionToUP()
        {
            CleanTask sut = new CleanTask("N 1");
            Point point = new Point(1, 1);

            point = sut.DoClean(point, _Logger.Object);

            Assert.AreEqual(2, point.Y);
        }

        [Test, Description("Do clean will increase Y of point with move to up command")]
        public void DoClean_WithTwoMoveToUPCommand_ChangeThePositionToUP()
        {
            CleanTask sut = new CleanTask("N 2");
            Point point = new Point(1, 1);

            point = sut.DoClean(point, _Logger.Object);

            Assert.AreEqual(3, point.Y);
        }

        [Test, Description("Do clean will decrease Y of point with move to down command")]
        public void DoClean_WithOneMoveToDownCommand_ChangeThePositionToUP()
        {
            CleanTask sut = new CleanTask("S 1");
            Point point = new Point(1, 2);

            point = sut.DoClean(point, _Logger.Object);

            Assert.AreEqual(1, point.Y);
        }

        [Test, Description("Do clean will increase x of point with move to east command")]
        public void DoClean_WithOneMoveToEastCommand_ChangeThePositionToUP()
        {
            CleanTask sut = new CleanTask("E 1");
            Point point = new Point(1, 1);

            point = sut.DoClean(point, _Logger.Object);

            Assert.AreEqual(2, point.X);
        }

        [Test, Description("Do clean will increase x of point with move to west command")]
        public void DoClean_WithOneMoveToWestCommand_ChangeThePositionToUP()
        {
            CleanTask sut = new CleanTask("W 1");
            Point point = new Point(2, 2);

            point = sut.DoClean(point, _Logger.Object);

            Assert.AreEqual(1, point.X);
        }
    }
}
