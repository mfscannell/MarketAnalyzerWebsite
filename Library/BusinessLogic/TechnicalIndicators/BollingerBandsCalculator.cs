using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators
{
    public class BollingerBandsCalculator : ITechnicalIndicatorCalculator
    {
        public BollingerBandsCalculator(int days, int numStandardDeviations)
        {

        }

        public double[] GetTechnicalIndicatorValue(double latestValue)
        {
            return new double[3] { 0, 0, 0 };
        }
    }
}
