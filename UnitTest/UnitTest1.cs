using NUnit.Framework;
using System;
using ParkSolution;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2022/5/2 09:00:00", "2022/5/2 09:10:59", 0, 1)] // 同一天
        [TestCase("2022/5/2 09:00:00", "2022/5/2 09:11:59", 7, 1)] // 同一天
        [TestCase("2022/5/2 09:00:00", "2022/5/2 10:00:59", 10, 1)] // 同一天
        [TestCase("2022/5/2 23:49:00", "2022/5/3 00:10:59", 0, 2)] // 跨一天,免費
        [TestCase("2022/5/2 23:48:00", "2022/5/3 00:00:00", 7, 2)] // 跨一天,收費
        [TestCase("2022/5/2 23:48:00", "2022/5/3 00:11:59", 14, 2)] // 跨一天,收費
        [TestCase("2022/5/2 00:00:00", "2022/5/3 00:11:59", 57, 2)] // 跨一天,收費
        [TestCase("2022/5/2 23:49:00", "2022/5/4 00:11:59", 57, 3)] // 跨2天,收費
        [TestCase("2022/5/2 22:59:00", "2022/5/4 00:11:59", 67, 3)] // 跨2天,收費
        [TestCase("2022/5/2 00:00:00", "2022/5/4 00:11:59", 107, 3)] //
        [TestCase("2022/5/7 09:00:00", "2022/5/7 09:01:59", 15, 1)] //
        [TestCase("2022/5/7 09:00:00", "2022/5/7 10:00:59", 15, 1)]
        [TestCase("2022/5/7 09:00:00", "2022/5/7 09:00:59", 0, 1)]
        [TestCase("2022/5/7 09:00:00", "2022/5/7 10:01:59", 30, 1)]
        [TestCase("2022/5/7 23:58:00", "2022/5/8 00:01:00", 30, 2)]
        [TestCase("2022/5/7 00:00:00", "2022/5/8 00:11:59", 265, 2)]
        [Test]
        public void Test1(string startValue, string endValue, int expectedFee, int expectedDays)
        {
            ICalcFee UseSolution = new SolutionB();
            DateTime start = DateTime.Parse(startValue);
            DateTime end = DateTime.Parse(endValue);

            var actual = new TestCase().Test(start, end, UseSolution);

            Assert.AreEqual(expectedFee, actual.TotalFee);
            Assert.AreEqual(expectedDays, actual.TotalDays);
        }

        [TestCase("2022/5/2 09:00:00", "2022/5/2 10:00:59", 20, 1)]
        [TestCase("2022/5/2 09:00:00", "2022/5/2 10:01:00", 50, 1)]
        [TestCase("2022/5/2 09:00:00", "2022/5/2 11:01:00", 80, 1)]
        [TestCase("2022/5/2 09:00:00", "2022/5/2 12:01:00", 110, 1)]
        [TestCase("2022/5/2 23:48:00", "2022/5/3 00:00:00", 20, 2)]
        [TestCase("2022/5/2 23:48:00", "2022/5/3 00:11:59", 40, 2)]
        [TestCase("2022/5/2 00:00:00", "2022/5/3 01:01:00", 350, 2)]
        [TestCase("2022/5/2 23:49:00", "2022/5/4 00:11:59", 340, 3)]
        [TestCase("2022/5/7 00:00:00", "2022/5/7 23:59:59", 0, 1)]
        [TestCase("2022/5/7 00:00:00", "2022/5/8 23:59:59", 0, 2)]
        [Test]
        public void Test2(string startValue, string endValue, int expectedFee, int expectedDays)
        {
            ICalcFee UseSolution = new SolutionC();
            DateTime start = DateTime.Parse(startValue);
            DateTime end = DateTime.Parse(endValue);

            var actual = new TestCase().Test(start, end, UseSolution);

            Assert.AreEqual(expectedFee, actual.TotalFee);
            Assert.AreEqual(expectedDays, actual.TotalDays);
        }
    }
}