using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace UnitTests.FinanceWebsite.Library.BusinessLogicTests.TechnicalIndicators
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SimpleMovingAverageTests
    {
        [TestMethod]
        public void TestGetMovingAverage5()
        {
            var sma = new SimpleMovingAverageCalculator(5);

            var average = sma.GetMovingAverage(10);
            Assert.AreEqual(0, average, 0.001);

            average = sma.GetMovingAverage(13);
            Assert.AreEqual(0, average, 0.001);

            average = sma.GetMovingAverage(14);
            Assert.AreEqual(0, average, 0.001);

            average = sma.GetMovingAverage(17);
            Assert.AreEqual(0, average, 0.001);

            average = sma.GetMovingAverage(14);
            Assert.AreEqual(13.6, average, 0.001);

            average = sma.GetMovingAverage(13);
            Assert.AreEqual(14.2, average, 0.001);

            average = sma.GetMovingAverage(9);
            Assert.AreEqual(13.4, average, 0.001);

            average = sma.GetMovingAverage(8);
            Assert.AreEqual(12.2, average, 0.001);

            average = sma.GetMovingAverage(7);
            Assert.AreEqual(10.2, average, 0.001);

            average = sma.GetMovingAverage(11);
            Assert.AreEqual(9.6, average, 0.001);

            average = sma.GetMovingAverage(11);
            Assert.AreEqual(9.2, average, 0.001);
        }
    }
}
