using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.FinanceClient.YahooClient;
using FinanceWebsite.Library.BusinessLogic.Factories;
using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Managers
{
    public class StockManager
    {
        #region Constructors and Destructors

        public StockManager()
        {

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
            var yahooHistory = await Historical.GetPriceAsync(
                request.StockHistoryDataRequest.TickerSymbol, 
                request.StockHistoryDataRequest.TechnicalAnalysisBeginDate, 
                request.StockHistoryDataRequest.TechnicalAnalysisEndDate);
            
            var chartSeriesFactory = new StockChartSeriesFactory();

            var stockChartSeries = request.StockChartSeriesRequest.SelectMany(
                chartSeriesRequest => chartSeriesFactory.GenerateChartSeries(
                        chartSeriesRequest, yahooHistory));

            return stockChartSeries;
        }

        #endregion
    }
}
