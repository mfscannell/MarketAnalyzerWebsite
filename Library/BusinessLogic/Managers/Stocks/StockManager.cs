using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses;
using FinanceWebsite.FinanceClient.YahooClient;
using FinanceWebsite.FinanceClient.YahooClient.Models;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;
using FinanceWebsite.Library.BusinessLogic.Factories;

namespace FinanceWebsite.Library.BusinessLogic.Managers.Stocks
{
    public class StockManager
    {
        #region Constructors and Destructors

        public StockManager()
        {

        }

        #endregion

        #region Public Methods

        public async Task<List<StockSeries>> GetStockSeries(StockChartRequest request)
        {
            var yahooHistory = await Historical.GetPriceAsync(
                request.TickerSymbol, 
                request.TechnicalAnalysisBeginDate, 
                request.TechnicalAnalysisEndDate);

            var stockSeries = new List<StockSeries>();

            var ohlcSeries = new StockSeries { Type = "candlestick", Name = request.TickerSymbol, YAxis = 0 };
            var volumeSeries = new StockSeries { Type = "column", Name = "Volume", YAxis = 1 };

            foreach (var tradingDay in yahooHistory)
            {
                ohlcSeries.Data.Add(
                    new List<Object>
                    {
                        tradingDay.Date,
                        tradingDay.Open,
                        tradingDay.High,
                        tradingDay.Low,
                        tradingDay.AdjClose
                    });

                volumeSeries.Data.Add(
                    new List<Object>
                    {
                        tradingDay.Date,
                        tradingDay.Volume
                    });
            }

            stockSeries.Add(ohlcSeries);
            stockSeries.Add(volumeSeries);

            foreach (var upper in request.Uppers)
            {
                var iTechnicalIndicator = TechnicalIndicatorCalculatorFactory.GetTechnicalCalculator(upper);
                var upperSeries = StockSeriesFactory.InitializeStockSeries(upper);

                foreach (var tradingDay in yahooHistory)
                {
                    var techValue = iTechnicalIndicator.GetTechnicalIndicatorValue(tradingDay.AdjClose);

                    for (var i = 0; i < upperSeries.Length; i++)
                    {
                        upperSeries[i].Data.Add(new List<object> { tradingDay.Date, techValue[i] });
                    }
                }

                for (var i = 0; i < upperSeries.Length; i++)
                {
                    stockSeries.Add(upperSeries[i]);
                }
            }

            return stockSeries;
        }

        #endregion
    }
}
