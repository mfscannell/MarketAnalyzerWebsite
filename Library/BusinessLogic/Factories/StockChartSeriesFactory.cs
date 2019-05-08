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

using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Factories
{
    public class StockChartSeriesFactory
    {
        #region Private Fields

        private int numChartsCreated;

        private int numUpperCharts;

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
                    var upperBandChartSeries = new UpperBollingerBandChartSeries(
                        StockChartSeriesColor.UPPERS[this.numUpperCharts]);
                    var middleBandChartSeries = new MiddleBollingerBandChartSeries(
                        StockChartSeriesColor.UPPERS[this.numUpperCharts]);
                    var lowerBandChartSeries = new LowerBollingerBandChartSeries(
                        StockChartSeriesColor.UPPERS[this.numUpperCharts]);
                    var bollingerBandsCalculator = new BollingerBandsCalculator(
                        BollingerBandsCalculator.ParseNumDays(stockChartSeriesRequest.Params),
                        BollingerBandsCalculator.ParseNumStandardDeviations(stockChartSeriesRequest.Params));

                    foreach (var tradingDay in stockHistoryData)
                    {
                        var bollingerBandValue = bollingerBandsCalculator.CalculateBollingerBands(tradingDay.AdjClose);

                        upperBandChartSeries.Data.Add(new LineSeriesDataPoint
                        {
                            X = tradingDay.Date,
                            Y = bollingerBandValue.UpperBandValue
                        });
                        middleBandChartSeries.Data.Add(new LineSeriesDataPoint
                        {
                            X = tradingDay.Date,
                            Y = bollingerBandValue.MovingAverageValue
                        });
                        lowerBandChartSeries.Data.Add(new LineSeriesDataPoint
                        {
                            X = tradingDay.Date,
                            Y = bollingerBandValue.LowerBandValue
                        });
                    }

                    this.numUpperCharts++;

                    return new ChartSeries[3] 
                    {
                        upperBandChartSeries,
                        middleBandChartSeries,
                        lowerBandChartSeries
                    };
                case StockChartSeriesType.PRICE:
                    var priceChartSeries = new PriceChartSeries();

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        priceChartSeries.Data.Add(
                            new PriceSeriesDataPoint
                            {
                                X = stockHistoryData[i].Date,
                                Open = stockHistoryData[i].Open,
                                High = stockHistoryData[i].High,
                                Low = stockHistoryData[i].Low,
                                Close = stockHistoryData[i].AdjClose,
                                Color = i > 0 && stockHistoryData[i].AdjClose < stockHistoryData[i - 1].AdjClose 
                                    ? StockChartSeriesColor.DOWN_PRICE 
                                    : StockChartSeriesColor.UP_PRICE
                            });
                    }

                    return new PriceChartSeries[1] 
                    {
                        priceChartSeries
                    };
                case StockChartSeriesType.SMA:
                    var smaChartSeries = new SimpleMovingAverageChartSeries(
                        $"{stockChartSeriesRequest.Params}-Day SMA",
                        StockChartSeriesColor.UPPERS[this.numUpperCharts]);
                    var smaCalculator = new SimpleMovingAverageCalculator(int.Parse(stockChartSeriesRequest.Params));

                    foreach (var tradingDay in stockHistoryData)
                    {
                        var movingAvg = smaCalculator.CalculateMovingAverage(tradingDay.AdjClose);

                        smaChartSeries.Data.Add(new LineSeriesDataPoint
                        {
                            X = tradingDay.Date,
                            Y = movingAvg
                        });
                    }

                    this.numUpperCharts++;

                    return new SimpleMovingAverageChartSeries[1] 
                    {
                        smaChartSeries
                    };
                case StockChartSeriesType.VOLUME:
                    this.numChartsCreated++;
                    var volumeChartSeries = new VolumeChartSeries(this.numChartsCreated);

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        volumeChartSeries.Data.Add(
                            new ColumnSeriesDataPoint
                            {
                                X = stockHistoryData[i].Date,
                                Y = stockHistoryData[i].Volume,
                                Color = i > 0 && stockHistoryData[i].AdjClose < stockHistoryData[i - 1].AdjClose
                                    ? StockChartSeriesColor.DOWN_PRICE
                                    : StockChartSeriesColor.UP_PRICE
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
