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

            // TODO add series for Uppers and lowers
            foreach (var upper in request.Uppers)
            {
                var data = new List<List<object>>();

                var calculator = upper.GetTechnicalCalculator();

                foreach (var tradingDay in yahooHistory)
                {
                    // TODO loop on trading days and get technical indicator value and
                    // add to data.
                    // NOTE:  upper could be multiple lines and would need multiple
                    // upper StockSeries objects to add to list of stock series.
                    var techValue = calculator.GetTechnicalIndicatorValue(tradingDay.AdjClose);

                    data.Add(new List<object> { tradingDay.Date, techValue[0] });
                }

                var upperSeries = new StockSeries
                {
                    Data = data,
                    Name = upper.GetName(),
                    Type = upper.GetChartType(),
                    YAxis = 0
                };

                stockSeries.Add(upperSeries);
            }

            return stockSeries;
        }

        #endregion
    }
}
