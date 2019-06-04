using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;

namespace FinanceWebsite.Library.BusinessLogic.Managers
{
    public interface IStockManager : IManager
    {
        Task<IEnumerable<ChartSeries>> GetStockChartSeries(StockChartRequest request);
    }
}
