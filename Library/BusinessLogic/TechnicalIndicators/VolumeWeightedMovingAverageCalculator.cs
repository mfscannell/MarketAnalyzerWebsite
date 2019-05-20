using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class VolumeWeightedMovingAverageCalculator
    {
        #region Private Fields

        /// <summary>
        /// All the values used for calculating the moving average.
        /// </summary>
        private double[] values;

        private double[] volumes;

        private double[] priceVolumes;

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

        /// <summary>
        /// The summation of the volume.
        /// </summary>
        private double summationVolume;

        #endregion

        #region Constructors

        public VolumeWeightedMovingAverageCalculator(int numRecords)
        {
            this.values = new double[numRecords];
            this.volumes = new double[numRecords];
            this.priceVolumes = new double[numRecords];
            this.indexOfOldestValue = 0;
            this.numValuesInserted = 0;
            this.summation = 0;
            this.summationVolume = 0;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the Volume Weighted Simple Moving Average based upon the latest value in a series of values.
        /// </summary>
        /// <param name="latestValue">
        /// The latest value in the series of values.
        /// </param>
        /// <returns>
        /// The Simple Moving Average in the series.
        /// </returns>
        public double CalculateMovingAverage(double latestValue, double latestVolume)
        {
            var latestPriceVolume = latestValue * latestVolume;
            this.summation = this.summation - this.priceVolumes[this.indexOfOldestValue] + latestPriceVolume;
            this.summationVolume = this.summationVolume - this.volumes[this.indexOfOldestValue] + latestVolume;

            if (this.numValuesInserted < this.values.Length)
            {
                this.numValuesInserted++;
            }

            this.values[this.indexOfOldestValue] = latestValue;
            this.volumes[this.indexOfOldestValue] = latestVolume;
            this.priceVolumes[this.indexOfOldestValue] = latestPriceVolume;
            this.indexOfOldestValue++;

            if (this.indexOfOldestValue == this.values.Length)
            {
                this.indexOfOldestValue = 0;
            }

            if (this.numValuesInserted == this.values.Length)
            {
                return this.summation / this.summationVolume;
            }

            return 0;
        }

        #endregion
    }
}
