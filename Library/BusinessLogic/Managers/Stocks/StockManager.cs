using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.FinanceClient.YahooClient;
using FinanceWebsite.FinanceClient.YahooClient.Models;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;
using FinanceWebsite.Library.BusinessLogic.Factories;
using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Managers.Stocks
{
    public class StockManager
    {
        #region Constructors and Destructors

        public StockManager()
        {

        }

        #endregion

        #region Public Static Methods

        public static List<string> GetAvailableUpperTechnicalIndicators()
        {
            return new List<string>
            {
                StockChartSeriesType.BOLLINGER_BANDS,
                StockChartSeriesType.SMA
            };
        }

        #endregion

        #region Public Methods

        public async Task<List<ChartSeries>> GetStockChartSeries(StockChartRequest request)
        {
            var yahooHistory = await Historical.GetPriceAsync(
                request.StockHistoryDataRequest.TickerSymbol, 
                request.StockHistoryDataRequest.TechnicalAnalysisBeginDate, 
                request.StockHistoryDataRequest.TechnicalAnalysisEndDate);
            var stockChartSeries = new List<ChartSeries>();
            var chartSeriesFactory = new StockChartSeriesFactory();

            foreach (var chartSeriesRequest in request.StockChartSeriesRequest)
            {
                stockChartSeries.AddRange(
                    chartSeriesFactory.GenerateChartSeries(
                        chartSeriesRequest, yahooHistory));
            }

            return stockChartSeries;
        }

        #endregion
    }
}
