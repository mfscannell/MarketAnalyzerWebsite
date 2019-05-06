using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class StockHistoryDataRequest
    {
        public DateTime ChartBeginDate { get; set; }

        public DateTime ChartEndDate { get; set; }

        public DateTime TechnicalAnalysisBeginDate { get; set; }

        public DateTime TechnicalAnalysisEndDate { get; set; }

        public string TickerSymbol { get; set; }
    }
}
