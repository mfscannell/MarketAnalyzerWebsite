﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators.Models;

using FinanceWebsite.Common.Domain;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class BollingerBandsCalculator
    {
        #region Private Fields

        private const int INDEX_OF_NUM_DAYS = 0;

        private const int INDEX_OF_NUM_STANDARD_DEVIATIONS = 1;

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

        #region Public Static Methods

        public static int ParseNumDays(string parameters)
        {
            return parameters.Split(',').Select(int.Parse).ToArray()[INDEX_OF_NUM_DAYS];
        }

        public static int ParseNumStandardDeviations(string parameters)
        {
            return parameters.Split(',').Select(int.Parse).ToArray()[INDEX_OF_NUM_STANDARD_DEVIATIONS];
        }

        #endregion

        #region Public Methods

        public BollingerBandsValue CalculateBollingerBands(HistoryPrice tradingDay)
        {
            var avg = this.smaCalculator.CalculateMovingAverage(tradingDay.AdjClose);
            var stdDev = this.smaCalculator.GetStandardDeviation();

            return new BollingerBandsValue
            {
                Date = tradingDay.Date,
                MovingAverageValue = avg,
                UpperBandValue = avg + this.numStandardDeviations * stdDev,
                LowerBandValue = avg - this.numStandardDeviations * stdDev
            };
        }

        #endregion
    }
}
