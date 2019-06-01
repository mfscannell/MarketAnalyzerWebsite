using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class StockHistoryDataRequest
    {
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TickerSymbol { get; set; }
    }
}
