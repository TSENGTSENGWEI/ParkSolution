using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkSolution;
using ExpectedObjects;

namespace Tests
{
    [TestClass()]
    public class TestCaseTests
    {
        [TestMethod()]
        public void TestTest()
        {
            ICalcFee UseSolution = new SolutionB();

            var Data = new List<TestData>()
            {
                //--------------------------------同一天
                new TestData()
                {
                    CaseID=1,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 9, 10, 59),
                    ExceptDay=1,
                    ExceptFee=0
                },
                new TestData()
                {
                    CaseID=2,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 9, 11, 59),
                    ExceptDay=1,
                    ExceptFee=7
                },
                new TestData()
                {
                    CaseID=3,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 10, 00, 59),
                    ExceptDay=1,
                    ExceptFee=10
                },
                //---------------------------------跨一天
                new TestData()
                {
                    CaseID=4,
                    Start = new DateTime(2022, 5, 2, 23, 49, 0),
                    End = new DateTime(2022, 5, 3, 00, 10, 59),
                    ExceptDay=2,
                    ExceptFee=0
                },
                new TestData()
                {
                    CaseID=5,
                    Start = new DateTime(2022, 5, 2, 23, 48, 0),
                    End = new DateTime(2022, 5, 3, 0, 0, 0),
                    ExceptDay=2,
                    ExceptFee=7
                },
                new TestData()
                {
                    CaseID=6,
                    Start = new DateTime(2022, 5, 2, 23, 48, 0),
                    End = new DateTime(2022, 5, 3, 0, 11, 59),
                    ExceptDay=2,
                    ExceptFee=14
                },
                //---------------------------------跨一天
                new TestData()
                {
                    CaseID=7,
                    Start = new DateTime(2022, 5, 2, 0, 0, 0),
                    End = new DateTime(2022, 5, 3, 00, 11, 59),
                    ExceptDay=2,
                    ExceptFee=57
                },
                new TestData()
                {
                    CaseID=8,
                    Start = new DateTime(2022, 5, 2, 23, 49, 0),
                    End = new DateTime(2022, 5, 4, 0, 11, 59),
                    ExceptDay=3,
                    ExceptFee=57
                },
                new TestData()
                {
                    CaseID=9,
                    Start = new DateTime(2022, 5, 2, 22, 59, 0),
                    End = new DateTime(2022, 5, 4, 0, 11, 59),
                    ExceptDay=3,
                    ExceptFee=67
                },
                new TestData()
                {
                    CaseID=10,
                    Start = new DateTime(2022, 5, 2, 0, 0, 0),
                    End = new DateTime(2022, 5, 4, 0, 11, 59),
                    ExceptDay=3,
                    ExceptFee=107
                },
                //---------------------------------假日
                new TestData()
                {
                    CaseID=11,
                    Start = new DateTime(2022, 5, 7, 9, 0, 0),
                    End = new DateTime(2022, 5, 7, 9, 1, 59),
                    ExceptDay=1,
                    ExceptFee=15
                },
                new TestData()
                {
                    CaseID=12,
                    Start = new DateTime(2022, 5, 7, 9, 0, 0),
                    End = new DateTime(2022, 5, 7, 10, 0, 59),
                    ExceptDay=1,
                    ExceptFee=15
                },
                new TestData()
                {
                    CaseID=13,
                    Start = new DateTime(2022, 5, 7, 9, 0, 0),
                    End = new DateTime(2022, 5, 7, 9, 0 , 59),
                    ExceptDay=1,
                    ExceptFee=0
                },
                //------------------------------------------------
                new TestData()
                {
                    CaseID=14,
                    Start = new DateTime(2022, 5, 7, 23, 58, 0),
                    End = new DateTime(2022, 5, 8, 0, 1, 0),
                    ExceptDay=2,
                    ExceptFee=30
                },
                new TestData()
                {
                    CaseID=15,
                    Start = new DateTime(2022, 5, 7, 0, 0, 0),
                    End = new DateTime(2022, 5, 8, 0, 11, 59),
                    ExceptDay=2,
                    ExceptFee=265
                },
            };

            foreach (var item in Data)
            {
                var expected = new ParkingFee(item.Start, item.End, UseSolution)
                {
                    TotalDays = item.ExceptDay,
                    TotalFee = item.ExceptFee,
                }.ToExpectedObject();

                var actual = new TestCase().Test(item.Start, item.End, UseSolution);
                Console.WriteLine($"執行測試{item.CaseID}");
                expected.ShouldEqual(actual);
                //Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void TestTest1()
        {
            ICalcFee UseSolution = new SolutionC();
            var Data = new List<TestData>()
            {
                //--------------------------------平日
                new TestData()
                {
                    CaseID=1,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 10, 0, 59),
                    ExceptDay=1,
                    ExceptFee=20
                },
                new TestData()
                {
                    CaseID=2,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 10, 1, 0),
                    ExceptDay=1,
                    ExceptFee=50
                },
                new TestData()
                {
                    CaseID=3,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 11, 1, 0),
                    ExceptDay=1,
                    ExceptFee=80
                },
                new TestData()
                {
                    CaseID=4,
                    Start = new DateTime(2022, 5, 2, 9, 0, 0),
                    End = new DateTime(2022, 5, 2, 12, 1, 0),
                    ExceptDay=1,
                    ExceptFee=110
                },
                new TestData()
                {
                    CaseID=5,
                    Start = new DateTime(2022, 5, 2, 23, 48, 0),
                    End = new DateTime(2022, 5, 3, 0, 0, 0),
                    ExceptDay=2,
                    ExceptFee=20
                },
                new TestData()
                {
                    CaseID=6,
                    Start = new DateTime(2022, 5, 2, 23, 48, 0),
                    End = new DateTime(2022, 5, 3, 0, 11, 59),
                    ExceptDay=2,
                    ExceptFee=40
                },
                new TestData()
                {
                    CaseID=7,
                    Start = new DateTime(2022, 5, 2, 0, 0, 0),
                    End = new DateTime(2022, 5, 3, 1, 1, 0),
                    ExceptDay=2,
                    ExceptFee=350
                },
                new TestData()
                {
                    CaseID=8,
                    Start = new DateTime(2022, 5, 2, 23, 49, 0),
                    End = new DateTime(2022, 5, 4, 0, 11, 59),
                    ExceptDay=3,
                    ExceptFee=340
                },
                //---------------------------------假日
                new TestData()
                {
                    CaseID=9,
                    Start = new DateTime(2022, 5, 7, 0, 0, 0),
                    End = new DateTime(2022, 5, 7, 23, 59, 59),
                    ExceptDay=1,
                    ExceptFee=0
                },
                new TestData()
                {
                    CaseID=10,
                    Start = new DateTime(2022, 5, 7, 0, 0, 0),
                    End = new DateTime(2022, 5, 8, 23, 59, 59),
                    ExceptDay=2,
                    ExceptFee=0
                },
            };

            foreach (var item in Data)
            {
                var expected = new ParkingFee(item.Start, item.End, UseSolution)
                {
                    TotalDays = item.ExceptDay,
                    TotalFee = item.ExceptFee,
                }.ToExpectedObject();

                var actual = new TestCase().Test(item.Start, item.End, UseSolution);
                Console.WriteLine($"執行測試{item.CaseID}");
                expected.ShouldEqual(actual);
                //Assert.AreEqual(expected, actual);
            }
        }
    }
}