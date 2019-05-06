using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators.Models;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class BollingerBandsCalculator
    {
        #region Private Fields

        private SimpleMovingAverageCalculator smaCalculator;

        private int numStandardDeviations;

        #endregion

        #region Constructors

        public BollingerBandsCalculator(int days, int numStandardDeviations)
        {
            this.smaCalculator = new SimpleMovingAverageCalculator(days);
            this.numStandardDeviations = numStandardDeviations;
        }

        #endregion

        #region Public Methods

        public BollingerBands CalculateBollingerBands(double latestValue)
        {
            var avg = this.smaCalculator.CalculateMovingAverage(latestValue);
            var stdDev = this.smaCalculator.GetStandardDeviation();

            return new BollingerBands
            {
                MovingAverageValue = avg,
                UpperBandValue = avg + this.numStandardDeviations * stdDev,
                LowerBandValue = avg - this.numStandardDeviations * stdDev
            };
        }

        #endregion
    }
}
