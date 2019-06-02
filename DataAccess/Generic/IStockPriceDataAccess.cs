using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Common.Domain;

namespace FinanceWebsite.DataAccess.Generic
{
    public interface IStockPriceDataAccess
    {
        List<HistoryPrice> GetStockPriceHistory(string tickerSymbol, DateTime beginDate, DateTime endDate);
    }
}
