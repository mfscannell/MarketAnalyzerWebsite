using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Factories;
using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;

using FinanceWebsite.StockClient.Generic;
using FinanceWebsite.StockClient.YahooClient;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FinanceWebsite.Library.BusinessLogic.Managers
{
    public class StockManager
    {
        #region Private Fields

        private IGetStockHistory stockHistoryClient;

        #endregion

        #region Constructors and Destructors

        public StockManager(IGetStockHistory stockHistoryClient)
        {
            this.stockHistoryClient = stockHistoryClient;
        }

        #endregion

        #region Public Static Methods

        public static IEnumerable<string> AvailableUpperTechnicalIndicators
        {
            get
            {
                return new List<string>
                {
                    StockChartSeriesName.BOLLINGER_BANDS,
                    StockChartSeriesName.SMA
                };
            }
        }

        public static IEnumerable<string> AvailableLowerTechnicalIndicators
        {
            get
            {
                return new List<string>
                {
                    StockChartSeriesName.RSI
                };
            }
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<ChartSeries>> GetStockChartSeries(StockChartRequest request)
        {
            var stockHistory = await this.stockHistoryClient.GetPriceAsync(
                request.StockHistoryDataRequest.TickerSymbol, 
                request.StockHistoryDataRequest.DataBeginDate,
                request.StockHistoryDataRequest.DataEndDate);
            
            var chartSeriesFactory = new StockChartSeriesFactory();

            var stockChartSeries = request.StockChartSeriesRequest.SelectMany(
                chartSeriesRequest => chartSeriesFactory.GenerateChartSeries(
                        chartSeriesRequest, stockHistory));

            return stockChartSeries;
        }

        #endregion
    }
}
