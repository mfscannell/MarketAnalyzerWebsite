using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class RelativeStrengthIndexCalculator
    {
        #region Private Fields

        //private double[] values;

        //private double[] changes;

        //private double[] gains;

        //private double[] losses;

        //private double[] averageGains;

        //private double[] averageLosses;

        private Queue<double> values;

        private Queue<double> changes;

        private Queue<double> gains;

        private Queue<double> losses;

        private Queue<double> averageGains;

        private Queue<double> averageLosses;

        /// <summary>
        /// The number of values inserted so far.
        /// </summary>
        private int numberOfValuesInserted;

        private readonly int numberOfRecordsForCalculation;

        #endregion

        #region Constructors

        public RelativeStrengthIndexCalculator(int numberOfRecordsForCalculation)
        {
            this.numberOfRecordsForCalculation = numberOfRecordsForCalculation;

            this.values = new Queue<double>();
            this.changes = new Queue<double>();
            this.gains = new Queue<double>();
            this.losses = new Queue<double>();
            this.averageGains = new Queue<double>();
            this.averageLosses = new Queue<double>();

            this.numberOfValuesInserted = 0;
        }

        #endregion

        #region Public Methods

        public double CalculateRelativeStrengthIndex(double latestValue)
        {
            if (this.values.Count == this.numberOfRecordsForCalculation)
            {
                this.values.Dequeue();
                this.changes.Dequeue();
                this.gains.Dequeue();
                this.losses.Dequeue();
                this.averageGains.Dequeue();
                this.averageLosses.Dequeue();
            }

            var change = this.numberOfValuesInserted == 0 ? 0 : latestValue - this.values.Last();
            var gain = Math.Max(0, change);
            var loss = Math.Abs(Math.Min(change, 0));
            var avgGain = 0.0;
            var avgLoss = 0.0;

            if (this.numberOfValuesInserted == this.numberOfRecordsForCalculation)
            {
                avgGain = (this.gains.Sum() + gain) / this.numberOfRecordsForCalculation;
                avgLoss = (this.losses.Sum() + loss) / this.numberOfRecordsForCalculation;
            } else if (this.numberOfValuesInserted == this.numberOfRecordsForCalculation + 1)
            {
                //about to insert the 16th+ record
                avgGain = ((this.numberOfRecordsForCalculation - 1) * this.averageGains.Last() + 1 * gain) / 
                    this.numberOfRecordsForCalculation;
                avgLoss = ((this.numberOfRecordsForCalculation - 1) * this.averageLosses.Last() + 1 * loss) /
                    this.numberOfRecordsForCalculation;
            }

            this.values.Enqueue(latestValue);
            this.changes.Enqueue(change);
            this.gains.Enqueue(gain);
            this.losses.Enqueue(loss);
            this.averageGains.Enqueue(avgGain);
            this.averageLosses.Enqueue(avgLoss);



            // UPDATE NUMBER OF RECORDS INSERTED
            if (this.numberOfValuesInserted < this.numberOfRecordsForCalculation + 1)
            {
                this.numberOfValuesInserted++;
            }




            if (this.numberOfValuesInserted <= this.numberOfRecordsForCalculation)
            {
                return 0;
            }
            else if (Double.Equals(avgLoss, 0))
            {
                return 100;
            }
            else
            {
                var relativeStrength = avgGain / avgLoss;

                return 100 - 100 / (1 + relativeStrength);
            }
        }

        #endregion
    }
}
