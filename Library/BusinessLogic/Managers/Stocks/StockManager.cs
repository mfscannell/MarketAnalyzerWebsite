using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses;
using FinanceWebsite.FinanceClient.YahooClient;
using FinanceWebsite.FinanceClient.YahooClient.Models;

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
                //ohlcSeries.Data.Add(
                //    new OhlcData
                //    {
                //        Date = tradingDay.Date,
                //        Open = tradingDay.Open,
                //        High = tradingDay.High,
                //        Low = tradingDay.Low,
                //        Close = tradingDay.AdjClose
                //    });

                ohlcSeries.Data.Add(
                    new List<Object>
                    {
                        tradingDay.Date,
                        tradingDay.Open,
                        tradingDay.High,
                        tradingDay.Low,
                        tradingDay.AdjClose
                    });

                //volumeSeries.Data.Add(
                //    new VolumeData
                //    {
                //        Date = tradingDay.Date,
                //        Volume = tradingDay.Volume
                //    });
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

            return stockSeries;
        }

        #endregion
    }
}
