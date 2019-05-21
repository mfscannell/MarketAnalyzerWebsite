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
    public class TripleExponentialMovingAverageCalculatorTests
    {
        [TestMethod]
        public void CalculateMovingAverage5()
        {
            var temaCalculator = new TripleExponentialMovingAverageCalculator(10);

            var result = temaCalculator.CalculateMovingAverage(22.27);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.19);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.08);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.17);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.18);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.13);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.23);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.43);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.24);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.29);
            Assert.AreEqual(0, result, 0.005);



            result = temaCalculator.CalculateMovingAverage(22.15);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.39);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.38);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.61);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.36);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(24.05);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.75);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.83);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.95);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.63);
            Assert.AreEqual(0, result, 0.005);


            result = temaCalculator.CalculateMovingAverage(23.82);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.87);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.65);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.19);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.10);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.33);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.68);
            Assert.AreEqual(0, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(23.10);
            Assert.AreEqual(23.02, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.40);
            Assert.AreEqual(22.68, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(22.17);
            Assert.AreEqual(22.36, result, 0.005);


            result = temaCalculator.CalculateMovingAverage(22);
            Assert.AreEqual(22.08, result, 0.005);

            result = temaCalculator.CalculateMovingAverage(21.8);
            Assert.AreEqual(21.82, result, 0.005);
        }
    }
}
