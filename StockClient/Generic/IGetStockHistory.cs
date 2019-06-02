using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Common.Domain;

namespace FinanceWebsite.StockClient.Generic
{
    public interface IGetStockHistory
    {
        Task<List<HistoryPrice>> GetPriceAsync(string symbol, DateTime start, DateTime end);
    }
}
