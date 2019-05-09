using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.TechnicalIndicators.Models
{
    public class BollingerBandsValue
    {
        #region Public Properties

        public DateTime Date { get; set; }

        public double UpperBandValue { get; set; }

        public double LowerBandValue { get; set; }

        public double MovingAverageValue { get; set; }

        #endregion
    }
}
