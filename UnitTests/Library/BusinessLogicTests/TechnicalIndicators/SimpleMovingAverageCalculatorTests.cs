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
    public class SimpleMovingAverageCalculatorTests
    {
        [TestMethod]
        public void CalculateMovingAverage5()
        {
            var sma = new SimpleMovingAverageCalculator(5);

            var average = sma.CalculateMovingAverage(10);
            Assert.AreEqual(0, average, 0.001);

            average = sma.CalculateMovingAverage(13);
            Assert.AreEqual(0, average, 0.001);

            average = sma.CalculateMovingAverage(14);
            Assert.AreEqual(0, average, 0.001);

            average = sma.CalculateMovingAverage(17);
            Assert.AreEqual(0, average, 0.001);

            average = sma.CalculateMovingAverage(14);
            Assert.AreEqual(13.6, average, 0.001);

            average = sma.CalculateMovingAverage(13);
            Assert.AreEqual(14.2, average, 0.001);

            average = sma.CalculateMovingAverage(9);
            Assert.AreEqual(13.4, average, 0.001);

            average = sma.CalculateMovingAverage(8);
            Assert.AreEqual(12.2, average, 0.001);

            average = sma.CalculateMovingAverage(7);
            Assert.AreEqual(10.2, average, 0.001);

            average = sma.CalculateMovingAverage(11);
            Assert.AreEqual(9.6, average, 0.001);

            average = sma.CalculateMovingAverage(11);
            Assert.AreEqual(9.2, average, 0.001);
        }

        [TestMethod]
        public void TestGetStandardDeviation5()
        {
            var sma = new SimpleMovingAverageCalculator(5);

            var average = sma.CalculateMovingAverage(10);
            var stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(0, stdDev, 0.005);

            average = sma.CalculateMovingAverage(13);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(0, stdDev, 0.005);

            average = sma.CalculateMovingAverage(14);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(0, stdDev, 0.005);

            average = sma.CalculateMovingAverage(17);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(0, stdDev, 0.005);

            average = sma.CalculateMovingAverage(14);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(2.24, stdDev, 0.005);

            average = sma.CalculateMovingAverage(13);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(1.47, stdDev, 0.005);

            average = sma.CalculateMovingAverage(9);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(2.58, stdDev, 0.005);

            average = sma.CalculateMovingAverage(8);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(3.31, stdDev, 0.005);

            average = sma.CalculateMovingAverage(7);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(2.79, stdDev, 0.005);

            average = sma.CalculateMovingAverage(11);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(2.15, stdDev, 0.005);

            average = sma.CalculateMovingAverage(11);
            stdDev = sma.GetStandardDeviation();
            Assert.AreEqual(1.6, stdDev, 0.005);
        }
    }
}
