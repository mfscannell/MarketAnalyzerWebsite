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
    public class RelativeStrengthIndexCalculatorTests
    {
        [TestMethod]
        public void TestCalculateRelativeStrengthIndex()
        {
            var rsiCalculator = new RelativeStrengthIndexCalculator(14);

            var rsi = rsiCalculator.CalculateRelativeStrengthIndex(44.34);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(44.09);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(44.15);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(43.61);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(44.33);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(44.83);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.10);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.42);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.84);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.08);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.89);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.03);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.61);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.28);
            Assert.AreEqual(0, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.28);
            Assert.AreEqual(70.46, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46);
            Assert.AreEqual(66.25, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.03);
            Assert.AreEqual(66.48, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.41);
            Assert.AreEqual(69.35, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(46.22);
            Assert.AreEqual(66.29, rsi, 0.005);

            rsi = rsiCalculator.CalculateRelativeStrengthIndex(45.64);
            Assert.AreEqual(57.92, rsi, 0.005);
        }
    }
}
