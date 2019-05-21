using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace UnitTests.FinanceWebsite.Library.BusinessLogicTests.TechnicalIndicators
{
    [TestClass]
    public class ExponentialMovingAverageCalculatorTests
    {
        [TestMethod]
        public void CalculateMovingAverage5()
        {
            var ema = new ExponentialMovingAverageCalculator(10);

            var average = ema.CalculateMovingAverage(22.27);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.19);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.08);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.17);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.18);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.13);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.23);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.43);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.24);
            Assert.AreEqual(0, average, 0.001);

            average = ema.CalculateMovingAverage(22.29);
            Assert.AreEqual(22.22, average, 0.005);

            average = ema.CalculateMovingAverage(22.15);
            Assert.AreEqual(22.21, average, 0.005);

            average = ema.CalculateMovingAverage(22.39);
            Assert.AreEqual(22.24, average, 0.005);

            average = ema.CalculateMovingAverage(22.38);
            Assert.AreEqual(22.27, average, 0.005);

            average = ema.CalculateMovingAverage(22.61);
            Assert.AreEqual(22.33, average, 0.005);

            average = ema.CalculateMovingAverage(23.36);
            Assert.AreEqual(22.52, average, 0.005);

            average = ema.CalculateMovingAverage(24.05);
            Assert.AreEqual(22.80, average, 0.005);

            average = ema.CalculateMovingAverage(23.75);
            Assert.AreEqual(22.97, average, 0.005);

            average = ema.CalculateMovingAverage(23.83);
            Assert.AreEqual(23.13, average, 0.005);

            average = ema.CalculateMovingAverage(23.95);
            Assert.AreEqual(23.28, average, 0.005);
        }
    }
}
