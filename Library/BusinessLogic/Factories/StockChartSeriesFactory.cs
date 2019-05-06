using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.FinanceClient.YahooClient.Models;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace FinanceWebsite.Library.BusinessLogic.Factories
{
    public class StockChartSeriesFactory
    {
        #region Private Fields

        private int numChartsCreated;

        #endregion

        #region Constructors

        public StockChartSeriesFactory()
        {
            this.numChartsCreated = 0;
        }

        #endregion

        #region Public Methods

        public ChartSeries[] GenerateChartSeries(
            StockChartSeriesRequest stockChartSeriesRequest, 
            List<HistoryPrice> stockHistoryData)
        {
            switch (stockChartSeriesRequest.Type)
            {
                case StockChartSeriesType.BOLLINGER_BANDS:
                    var upperBandChartSeries = new UpperBollingerBandChartSeries();
                    var middleBandChartSeries = new MiddleBollingerBandChartSeries();
                    var lowerBandChartSeries = new LowerBollingerBandChartSeries();
                    var bollingerBandsParams = stockChartSeriesRequest.Params.Split(',').Select(int.Parse).ToArray();
                    var bollingerBandsCalculator = new BollingerBandsCalculator(
                        bollingerBandsParams[0], 
                        bollingerBandsParams[1]);

                    foreach (var tradingDay in stockHistoryData)
                    {
                        var bollingerBandValue = bollingerBandsCalculator.CalculateBollingerBands(tradingDay.AdjClose);

                        upperBandChartSeries.Data.Add(
                            new List<object>
                            {
                                tradingDay.Date,
                                bollingerBandValue.UpperBandValue
                            });
                        middleBandChartSeries.Data.Add(
                            new List<object>
                            {
                                tradingDay.Date,
                                bollingerBandValue.MovingAverageValue
                            });
                        lowerBandChartSeries.Data.Add(
                            new List<object>
                            {
                                tradingDay.Date,
                                bollingerBandValue.LowerBandValue
                            });
                    }

                    return new ChartSeries[3] 
                    {
                        upperBandChartSeries,
                        middleBandChartSeries,
                        lowerBandChartSeries
                    };
                case StockChartSeriesType.PRICE:
                    var priceChartSeries = new PriceChartSeries();

                    foreach (var tradingDay in stockHistoryData)
                    {
                        priceChartSeries.Data.Add(
                            new List<object>
                            {
                                tradingDay.Date,
                                tradingDay.Open,
                                tradingDay.High,
                                tradingDay.Low,
                                tradingDay.AdjClose
                            });
                    }

                    return new PriceChartSeries[1] 
                    {
                        priceChartSeries
                    };
                case StockChartSeriesType.SMA:
                    var smaChartSeries = new SimpleMovingAverageChartSeries(
                        $"{stockChartSeriesRequest.Params}-Day SMA");
                    var smaCalculator = new SimpleMovingAverageCalculator(int.Parse(stockChartSeriesRequest.Params));

                    foreach (var tradingDay in stockHistoryData)
                    {
                        var movingAvg = smaCalculator.CalculateMovingAverage(tradingDay.AdjClose);

                        smaChartSeries.Data.Add(new List<object> { tradingDay.Date, movingAvg });
                    }

                    return new SimpleMovingAverageChartSeries[1] 
                    {
                        smaChartSeries
                    };
                case StockChartSeriesType.VOLUME:
                    this.numChartsCreated++;
                    var volumeChartSeries = new VolumeChartSeries(this.numChartsCreated);

                    foreach (var tradingDay in stockHistoryData)
                    {
                        volumeChartSeries.Data.Add(
                            new List<object>
                            {
                                tradingDay.Date,
                                tradingDay.Volume,
                            });
                    }

                    return new VolumeChartSeries[1] { volumeChartSeries };
                default:
                    return null;
            }
        }

        #endregion
    }
}
