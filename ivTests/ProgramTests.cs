using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void OverFlowHandling()
        {

            List<int> x = new List<int> { 8, 9, 8, 8 };
            List<int> y = new List<int> { 9, 9, 7, 9 };

            List<int> expected = new List<int> { 1, 8, 9, 6, 7 };
            List<int> actual = Program.Func(x, y);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LongerFirstParam()
        {

            List<int> x = new List<int> { 4, 5, 6, 7, 8, 4, 2, 0, 1 };
            List<int> y = new List<int> { 2, 2, 3, 4 };

            List<int> expected = new List<int> { 4, 5, 6, 7, 8, 6, 4, 3, 5 };
            List<int> actual = Program.Func(x, y);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void LongerSecondParam()
        {

            List<int> x = new List<int> { 2, 7 };
            List<int> y = new List<int> { 5, 7, 9, 2, 9, 9, 9 };

            List<int> expected = new List<int> { 5, 7, 9, 3, 0, 2, 6 };
            List<int> actual = Program.Func(x, y);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OutOfRangeValueFirstParam()
        {

            List<int> x = new List<int> { 2, 7, 11 };
            List<int> y = new List<int> { 5, 7, 9, 2, 3, 9, 9 };

            try
            {
                Program.Func(x, y);
                Assert.Fail("Should have thrown exception.");
            }
            catch (Exception e)
            {
                Assert.AreEqual("List items must be between 0 and 9", e.Message);
            }
        }

        [TestMethod()]
        public void OutOfRangeValueSecondParam()
        {

            List<int> x = new List<int> { 2, 7 };
            List<int> y = new List<int> { 5, 7, 9, 2, 11, 9, 9 };

            try
            {
                Program.Func(x, y);
                Assert.Fail("Should have thrown exception.");
            }
            catch (Exception e)
            {
                Assert.AreEqual("List items must be between 0 and 9", e.Message);
            }
        }

        [TestMethod()]
        public void PassEmptyParam()
        {

            List<int> y = new List<int> { 2, 7 };
            List<int> x = new List<int>();

            List<int> expected = new List<int> { 2, 7 } ;
            List<int> actual = Program.Func(x, y);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void PassEmptyParams()
        {

            List<int> y = new List<int>();
            List<int> x = new List<int>();

            List<int> expected = new List<int>();
            List<int> actual = Program.Func(x, y);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}