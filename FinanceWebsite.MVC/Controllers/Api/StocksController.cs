using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Managers;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.StockClient.YahooClient;

namespace FinanceWebsite.MVC.Controllers.Api
{
    public class StocksController : ApiController
    {
        #region Private Fields

        private readonly IStockManager stockManager;

        #endregion

        #region Constructors

        public StocksController(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }

        #endregion

        #region Public APIs

        [HttpGet]
        [Route("Api/stocks/history")]
        public async Task<IEnumerable<ChartSeries>> GetStockHistory(string tickerSymbol, DateTime beginDate, DateTime endDate, string uppers, string lowers)
        {
            var parsedUppers = JsonConvert.DeserializeObject<List<StockChartSeriesRequest>>(uppers);
            var parsedLowers = JsonConvert.DeserializeObject<List<StockChartSeriesRequest>>(lowers);

            var request = new StockChartRequest
            {
                StockHistoryDataRequest = new StockHistoryDataRequest
                {
                    BeginDate = beginDate,
                    EndDate = endDate,
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
            request.StockChartSeriesRequest.AddRange(parsedLowers);
            var result = await this.stockManager.GetStockChartSeries(request);
            this.stockManager.Dispose();

            return result;
        }

        #endregion
    }
}
