using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    /// <summary>
    /// This class is used to determine the Simple Moving Average for a series of numbers.
    /// </summary>
    public class SimpleMovingAverageCalculator
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
        /// The summation of all items in values.
        /// </summary>
        private double summation;

        #endregion

        #region Constructors

        public SimpleMovingAverageCalculator(int numRecords)
        {
            this.values = new double[numRecords];
            this.indexOfOldestValue = 0;
            this.numValuesInserted = 0;
            this.summation = 0;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the Simple Moving Average based upon the latest value in a series of values.
        /// </summary>
        /// <param name="latestValue">
        /// The latest value in the series of values.
        /// </param>
        /// <returns>
        /// The Simple Moving Average in the series.
        /// </returns>
        public double CalculateMovingAverage(double latestValue)
        {
            this.summation = this.summation - this.values[this.indexOfOldestValue] + latestValue;

            if (this.numValuesInserted < this.values.Length)
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
                return this.summation / this.values.Length;
            }

            return 0;
        }

        public double GetStandardDeviation()
        {
            if (this.numValuesInserted < this.values.Length)
            {
                return 0;
            }

            var average = this.values.Average();

            double sum = 0;

            foreach (var value in this.values)
            {
                sum = sum + Math.Pow(value - average, 2);
            }

            return Math.Pow(sum / this.values.Length, 0.5);
        }

        #endregion
    }
}
