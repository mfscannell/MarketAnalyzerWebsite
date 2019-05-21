using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class ExponentialMovingAverageCalculator
    {
        #region Private Fields

        /// <summary>
        /// All the values used for calculating the moving average.
        /// </summary>
        private double[] values;

        /// <summary>
        /// The index in values where the oldest value was inserted.
        /// </summary>
        private int indexOfOldestValue;

        /// <summary>
        /// The number of values inserted so far.
        /// </summary>
        private int numValuesInserted;

        /// <summary>
        /// The previous moving average.
        /// </summary>
        private double movingAverage;

        #endregion

        #region Constructors

        public ExponentialMovingAverageCalculator(int numRecords)
        {
            this.values = new double[numRecords];
            this.indexOfOldestValue = 0;
            this.numValuesInserted = 0;
            this.movingAverage = 0;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the Exponential Moving Average based upon the latest value in a series of values.
        /// </summary>
        /// <param name="latestValue">
        /// The latest value in the series of values.
        /// </param>
        /// <returns>
        /// The Simple Moving Average in the series.
        /// </returns>
        public double CalculateMovingAverage(double latestValue)
        {
            if (this.numValuesInserted < this.values.Length + 1)
            {
                this.numValuesInserted++;
            }

            this.values[this.indexOfOldestValue] = latestValue;
            this.indexOfOldestValue++;

            if (this.indexOfOldestValue == this.values.Length)
            {
                this.indexOfOldestValue = 0;
            }

            if (this.numValuesInserted == this.values.Length)
            {
                this.movingAverage = this.values.Average();

                return this.movingAverage;
            }
            else if (this.numValuesInserted > this.values.Length)
            {
                this.movingAverage = 
                    this.movingAverage + (latestValue - this.movingAverage) * 2.0 / (this.values.Length + 1);

                return this.movingAverage;
            }

            return 0;
        }

        #endregion
    }
}
