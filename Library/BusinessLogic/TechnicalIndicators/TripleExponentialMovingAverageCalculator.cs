using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public  class TripleExponentialMovingAverageCalculator
    {
        #region Private Fields

        private double[] values;

        private double[] emas;

        private double[] doubleEmas;

        private int indexOfOldestValue;

        private int numValuesInserted;

        private double ema1;

        private double ema2;

        private double ema3;

        private double multiplier;

        private ExponentialMovingAverageCalculator ema1Calculator;

        private ExponentialMovingAverageCalculator ema2Calculator;

        private ExponentialMovingAverageCalculator ema3Calculator;

        #endregion

        #region Constructors

        public TripleExponentialMovingAverageCalculator(int numRecords)
        {
            this.values = new double[numRecords];
            this.emas = new double[numRecords];
            this.doubleEmas = new double[numRecords];
            this.indexOfOldestValue = 0;
            this.numValuesInserted = 0;
            this.ema1 = 0;
            this.ema2 = 0;
            this.ema3 = 0;
            this.multiplier = 2.0 / (numRecords + 1);

            this.ema1Calculator = new ExponentialMovingAverageCalculator(numRecords);
            this.ema2Calculator = new ExponentialMovingAverageCalculator(numRecords);
            this.ema3Calculator = new ExponentialMovingAverageCalculator(numRecords);
        }

        #endregion

        #region Public Methods

        public double CalculateMovingAverage(double latestValue)
        {
            double tema = 0;

            if (this.numValuesInserted < 3 * this.values.Length - 1)
            {
                this.numValuesInserted++;
            }

            this.ema1 = this.ema1Calculator.CalculateMovingAverage(latestValue);

            if (this.numValuesInserted >= this.values.Length)
            {
                this.ema2 = this.ema2Calculator.CalculateMovingAverage(this.ema1);

                if (this.numValuesInserted >= this.values.Length * 2 - 1)
                {
                    this.ema3 = this.ema3Calculator.CalculateMovingAverage(this.ema2);

                    if (this.numValuesInserted >= this.values.Length * 3 - 2)
                    {
                        tema = 3 * this.ema1 - 3 * this.ema2 + this.ema3;
                    }
                }
            }

            return tema;
        }

        #endregion
    }
}
