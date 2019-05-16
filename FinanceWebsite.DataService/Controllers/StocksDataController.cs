using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;

using Newtonsoft.Json;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Managers;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.StockClient.Generic;

namespace FinanceWebsite.DataService.Controllers
{
    public class StocksDataController : ApiController
    {
        #region Private Fields

        private readonly StockManager stockManager;

        #endregion

        #region Constructors

        public StocksDataController(IGetStockHistory stockHistoryClient)
        {
            this.stockManager = new StockManager(stockHistoryClient);
        }

        #endregion

        #region Public APIs

        [EnableCors(origins: "http://localhost:58607", headers: "*", methods: "*")]
        [HttpGet]
        [Route("DataApi/stocks/history")]
        public async Task<IEnumerable<ChartSeries>> GetStockHistory(string tickerSymbol, DateTime beginDate, DateTime endDate, string uppers, string lowers)
        {
            var parsedUppers = JsonConvert.DeserializeObject<List<StockChartSeriesRequest>>(uppers);
            var parsedLowers = JsonConvert.DeserializeObject<List<StockChartSeriesRequest>>(lowers);

            var smallestUpper = parsedUppers.Count == 0 
                ? 0 
                : parsedUppers.Select(upper => upper.GetNumPreviousCalendarDays()).Min();
            var smallestLower = parsedLowers.Count == 0 
                ? 0 
                : parsedLowers.Select(lower => lower.GetNumPreviousCalendarDays()).Min();

            var request = new StockChartRequest
            {
                StockHistoryDataRequest = new StockHistoryDataRequest
                {
                    ChartBeginDate = beginDate,
                    ChartEndDate = endDate,
                    DataBeginDate = beginDate.AddDays(Math.Min(smallestLower, smallestUpper)),
                    DataEndDate = endDate.AddDays(1),
                    TickerSymbol = tickerSymbol
                },
                StockChartSeriesRequest = new List<StockChartSeriesRequest>
                {
                    new StockChartSeriesRequest
                    {
                        Type = StockChartSeriesNameEnum.Price,
                        Params = string.Empty
                    },
                    new StockChartSeriesRequest
                    {
                        Type = StockChartSeriesNameEnum.Volume,
                        Params = string.Empty
                    }
                }
            };

            request.StockChartSeriesRequest.AddRange(parsedUppers);
            //TODO
            request.StockChartSeriesRequest.AddRange(parsedLowers);
            var result = await this.stockManager.GetStockChartSeries(request);

            return result;
        }

        #endregion
    }
}
