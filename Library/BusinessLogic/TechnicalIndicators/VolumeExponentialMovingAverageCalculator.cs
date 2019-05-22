using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class VolumeExponentialMovingAverageCalculator
    {
        #region Private Fields

        private double[] values;

        private double[] volumes;

        private double[] priceVolumes;

        private int numValuesInserted;

        private double emaNumerator;

        private double emaDenominator;

        private ExponentialMovingAverageCalculator emaNumeratorCalculator;

        private ExponentialMovingAverageCalculator emaDenominatorCalculator;

        #endregion

        #region Constructors

        public VolumeExponentialMovingAverageCalculator(int numRecords)
        {
            this.values = new double[numRecords];
            this.volumes = new double[numRecords];
            this.priceVolumes = new double[numRecords];
            this.numValuesInserted = 0;
            this.emaNumerator = 0;
            this.emaDenominator = 0;
            this.emaNumeratorCalculator = new ExponentialMovingAverageCalculator(numRecords);
            this.emaDenominatorCalculator = new ExponentialMovingAverageCalculator(numRecords);
        }

        #endregion

        #region Public Methods

        public double CalculateMovingAverage(double latestValue, double latestVolume)
        {
            this.emaNumerator = this.emaNumeratorCalculator.CalculateMovingAverage(latestValue * latestVolume);
            this.emaDenominator = this.emaDenominatorCalculator.CalculateMovingAverage(latestVolume);

            if (Math.Abs(this.emaDenominator) > Double.Epsilon)
            {
                return this.emaNumerator / this.emaDenominator;
            }

            return 0;
        }

        #endregion
    }
}
