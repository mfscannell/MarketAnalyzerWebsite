using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;

using Newtonsoft.Json;

using FinanceWebsite.FinanceClient.YahooClient;
using FinanceWebsite.FinanceClient.YahooClient.Models;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Managers.Stocks;
using FinanceWebsite.Library.BusinessLogic.Responses;

namespace FinanceWebsite.DataService.Controllers
{
    public class StocksDataController : ApiController
    {
        [EnableCors(origins: "http://localhost:58607", headers: "*", methods: "*")]
        [HttpGet]
        [Route("DataApi/stocks/history")]
        public async Task<List<StockSeries>> GetStockHistory(string tickerSymbol, DateTime beginDate, DateTime endDate, string uppers)
        {
            var parsedUppers = JsonConvert.DeserializeObject<List<TechnicalIndicator>>(uppers);

            //var result = await Historical.GetPriceAsync(
            //            tickerSymbol,
            //            beginDate,
            //            endDate);

            //return result;

            var request = new StockChartRequest
            {
                TickerSymbol = tickerSymbol,
                ChartBeginDate = beginDate,
                ChartEndDate = endDate,
                TechnicalAnalysisBeginDate = beginDate,
                TechnicalAnalysisEndDate = endDate.AddDays(1)
            };
            var stockManager = new StockManager();
            var result = await stockManager.GetStockSeries(request);

            return result;
        }
    }
}
