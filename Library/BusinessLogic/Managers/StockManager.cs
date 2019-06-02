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
using FinanceWebsite.DataAccess.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FinanceWebsite.Library.BusinessLogic.Managers
{
    public class StockManager : IStockManager
    {
        #region Private Fields

        private IGetStockHistory stockHistoryClient;

        private IDataAccess dataAccess;

        #endregion

        #region Constructors and Destructors

        public StockManager(IGetStockHistory stockHistoryClient, IDataAccess dataAccess)
        {
            this.stockHistoryClient = stockHistoryClient;
            this.dataAccess = dataAccess;
        }

        public void Dispose()
        {
            this.dataAccess.CloseConnection();
            this.dataAccess.Dispose();
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
                    StockChartSeriesName.EMA,
                    StockChartSeriesName.SMA,
                    StockChartSeriesName.TEMA,
                    StockChartSeriesName.VEMA,
                    StockChartSeriesName.VWMA
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
                request.StockHistoryDataRequest.BeginDate.AddDays(
                    request.StockChartSeriesRequest.Select(series => series.GetNumPreviousCalendarDays()).Min()),
                request.StockHistoryDataRequest.EndDate.AddDays(1));

            var chartSeriesFactory = new StockChartSeriesFactory();

            var stockChartSeries = request.StockChartSeriesRequest.SelectMany(
                chartSeriesRequest => chartSeriesFactory.GenerateChartSeries(
                        chartSeriesRequest, 
                        stockHistory,
                        request.StockHistoryDataRequest.BeginDate,
                        request.StockHistoryDataRequest.EndDate));

            return stockChartSeries;
        }

        #endregion
    }
}
