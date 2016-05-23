using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cint.RobotCleaner.Domain;
using Moq;
using Cint.RobotCleaner.Domain.Base;

namespace Cint.RobotCleaner.Test
{
    [TestFixture]
    public class RobotTest
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

        [Test, Description("Create robot with valid inputs")]
        public void CreateRobot_WithValidInputs_IsValid()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 2;
            sut.CurrentPosition = new Point("10 22");

            sut.AddCleanTask("E 2");
            sut.AddCleanTask("N 1");

            Assert.IsTrue(sut.IsValid);
        }

        [Test, Description("Robot isvalid if the task counts and added tasks are equal")]
        public void CreateRobot_With3TasksCount_And3AddedTask_IsNotValid()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 3;
            sut.CurrentPosition = new Point("10 22");

            sut.AddCleanTask("E 2");
            sut.AddCleanTask("N 1");
            sut.AddCleanTask("N 2");

            Assert.IsTrue(sut.IsValid);
        }

        [Test, Description("Robot isvalid if the task counts and added tasks are equal")]
        public void CreateRobot_With5TasksCount_And3AddedTask_IsNotValid()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 5;
            sut.CurrentPosition = new Point("10 22");

            sut.AddCleanTask("E 2");
            sut.AddCleanTask("N 1");
            sut.AddCleanTask("N 2");

            Assert.IsFalse(sut.IsValid);
        }

        [Test, Description("Robot isvalid if the task counts is zero and added tasks are zero")]
        public void CreateRobot_WithZeroTasksCount_ExpectZeroTask()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 0;
            sut.CurrentPosition = new Point("10 22");

            Assert.IsTrue(sut.IsValid);
        }

        [Test, Description("Robot tasks count would set as zero if we pass negetive input")]
        public void CreateRobot_WithNegetiveTasksCount_ExpectZeroTask()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = -1;
            sut.CurrentPosition = new Point("10 22");

            Assert.IsTrue(sut.IsValid);
        }

        [Test, Description("Robot tasks count with 10000 is valid")]
        public void CreateRobot_With10000TasksCount_And10000AddedTaskIsValid()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 10000;
            sut.CurrentPosition = new Point("10 22");

            for (int i = 0; i < 10000; i++)
            {
                sut.AddCleanTask("E 1");
            }

            Assert.IsTrue(sut.IsValid);
        }

        [Test]
        public void CreateRobot_With20000TasksCount_ExpectMaxTaskCount()
        {
            Robot sut = new Robot(new StandardLogger());
            sut.TasksCount = 20000;
            sut.CurrentPosition = new Point("10 22");

            for (int i = 0; i < 10000; i++)
            {
                sut.AddCleanTask("E 1");
            }

            Assert.IsTrue(sut.IsValid);
        }
    }
}
