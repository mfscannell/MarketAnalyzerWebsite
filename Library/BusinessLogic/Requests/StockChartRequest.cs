using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class StockChartRequest
    {
        #region Constructors and Destructors

        public StockChartRequest()
        {
            this.Lowers = new List<TechnicalIndicator>();
            this.Uppers = new List<TechnicalIndicator>();
        }

        #endregion

        #region Public Properties

        public DateTime ChartBeginDate { get; set; }

        public DateTime ChartEndDate { get; set; }

        public DateTime TechnicalAnalysisBeginDate { get; set; }

        public DateTime TechnicalAnalysisEndDate { get; set; }

        public string TickerSymbol { get; set; }

        public List<TechnicalIndicator> Uppers { get; set; }

        public List<TechnicalIndicator> Lowers { get; set; }

        #endregion
    }
}
