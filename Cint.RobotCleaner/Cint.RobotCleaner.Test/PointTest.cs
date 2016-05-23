using Cint.RobotCleaner.Domain;
using Cint.RobotCleaner.Domain.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Cint.RobotCleaner.Test
{
    [TestFixture]
    public class PointTest
    {
        [Test, Description("Create two points with same value should be equal")]
        public void CreateTwoPoints_WithSamevalue_ShouldBeEqual()
        {
            Point sut1 = new Point("10 22");
            Point sut2 = new Point("10 22");

            var actual = sut1.Equals(sut2);

            Assert.IsTrue(actual);
        }

        [Test, Description("Create point object with valid input and X and Y set correctly")]
        public void CreatePoint_WithValidStringInputCommand_PropertiesSetCorreclty()
        {
            Point sut = new Point("10 22");

            var actualX = sut.X;
            var actualY = sut.Y;

            Assert.AreEqual(10, actualX);
            Assert.AreEqual(22, actualY);
        }

        [Test, Description("Create point object with integer inputs and X and Y set correctly")]
        public void CreatePoint_WithValidIntInputCommand_PropertiesSetCorreclty()
        {
            Point sut = new Point(10, 22);

            var actualX = sut.X;
            var actualY = sut.Y;

            Assert.AreEqual(10, actualX);
            Assert.AreEqual(22, actualY);
        }

        [Test, Description("If inputs are too big, x and y will have biggest possible value which defined in Point class")]
        public void CreatePoint_WithTooBigInput_XandY_WillBeMaxPossibleValue()
        {
            Point sut = new Point("200000 200000");

            var actualX = sut.X;
            var actualY = sut.Y;

            Assert.AreEqual(Point.MaxPoint, actualX);
            Assert.AreEqual(Point.MaxPoint, actualY);
        }

        [Test, Description("If inputs are too small, x and y will have minimum possible value which defined in Point class")]
        public void CreatePoint_WithTooBigInput_XandY_WillBeMinPossibleValue()
        {
            Point sut = new Point("-200000 -200000");

            var actualX = sut.X;
            var actualY = sut.Y;

            Assert.AreEqual(Point.MinPoint, actualX);
            Assert.AreEqual(Point.MinPoint, actualY);
        }

        [Test, Description("If input command has no space, it will throw exception")]
        public void CreatePoint_CommandWithoutSpace_WillThrowExceptiopn()
        {
            Assert.Throws<IndexOutOfRangeException>(() => { Point sut = new Point("1011"); });
        }

        [Test, Description("If input command with too many spaces, it will throw exception")]
        public void CreatePoint_With_TooManySpace_Would_Fail()
        {
            Assert.Throws<FormatException>(() => { Point sut = new Point("10    11"); });
        }
    }
}
