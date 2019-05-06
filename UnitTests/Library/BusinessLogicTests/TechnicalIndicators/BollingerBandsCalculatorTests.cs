using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace UnitTests.FinanceWebsite.Library.BusinessLogicTests.TechnicalIndicators
{
    [TestClass]
    public class BollingerBandsCalculatorTests
    {
        [TestMethod]
        public void GetTechnicalIndicatorValue20_2()
        {
            var calculator = new BollingerBandsCalculator(20, 2);

            var result = calculator.CalculateBollingerBands(13);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(12.1);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(13.2);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(13.4);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(13.5);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(13.8);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.2);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.3);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.5);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.7);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.5);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.5);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.4);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.6);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(14.8);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(15);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(15.1);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(15.1);

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);




            result = calculator.CalculateBollingerBands(15.5);

            Assert.AreEqual(15.88, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.21, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.54, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(16);

            Assert.AreEqual(16.11, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.36, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.61, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(17);

            Assert.AreEqual(16.39, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.61, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.82, result.LowerBandValue, 0.05);
        }
    }
}
