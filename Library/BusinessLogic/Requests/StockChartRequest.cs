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
        }

        #endregion

        #region Public Properties

        public List<StockChartSeriesRequest> StockChartSeriesRequest { get; set; }

        public StockHistoryDataRequest StockHistoryDataRequest { get; set; }

        #endregion
    }
}
