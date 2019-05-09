using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;
using FinanceWebsite.FinanceClient.YahooClient.Models;

namespace UnitTests.FinanceWebsite.Library.BusinessLogicTests.TechnicalIndicators
{
    [TestClass]
    public class BollingerBandsCalculatorTests
    {
        [TestMethod]
        public void TestParseNumDays()
        {
            var result = BollingerBandsCalculator.ParseNumDays("20,3");

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestParseNumStandardDeviations()
        {
            var result = BollingerBandsCalculator.ParseNumStandardDeviations("20,3");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetTechnicalIndicatorValue20_2()
        {
            var calculator = new BollingerBandsCalculator(20, 2);

            var result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 13
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 12.1
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 13.2
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 13.4
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 13.5
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 13.8
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.2
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.3
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.5
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.7
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.5
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.5
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.4
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.6
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 14.8
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 15
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 15.1
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 15.1
                });

            Assert.AreEqual(0, result.UpperBandValue, 0.05);
            Assert.AreEqual(0, result.MovingAverageValue, 0.05);
            Assert.AreEqual(0, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 15.5
                });

            Assert.AreEqual(15.88, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.21, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.54, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 16
                });

            Assert.AreEqual(16.11, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.36, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.61, result.LowerBandValue, 0.05);

            result = calculator.CalculateBollingerBands(
                new HistoryPrice
                {
                    Date = DateTime.Now,
                    AdjClose = 17
                });

            Assert.AreEqual(16.39, result.UpperBandValue, 0.05);
            Assert.AreEqual(14.61, result.MovingAverageValue, 0.05);
            Assert.AreEqual(12.82, result.LowerBandValue, 0.05);
        }
    }
}
