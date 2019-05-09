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

        private int numberOfChartsCreated;

        private int numberOfUpperSeriesCreated;

        #endregion

        #region Constructors

        public StockChartSeriesFactory()
        {
            this.numberOfChartsCreated = 0;
            this.numberOfUpperSeriesCreated = 0;
        }

        #endregion

        #region Public Methods

        public ChartSeries[] GenerateChartSeries(
            StockChartSeriesRequest stockChartSeriesRequest, 
            List<HistoryPrice> stockHistoryData)
        {
            switch (stockChartSeriesRequest.Type)
            {
                case StockChartSeriesName.BOLLINGER_BANDS:
                    this.numberOfUpperSeriesCreated += 3;
                    var bollingerBandsCalculator = new BollingerBandsCalculator(
                        BollingerBandsCalculator.ParseNumDays(stockChartSeriesRequest.Params),
                        BollingerBandsCalculator.ParseNumStandardDeviations(stockChartSeriesRequest.Params));
                    var bollingerBandValues = stockHistoryData.Select(
                        tradingDay => bollingerBandsCalculator.CalculateBollingerBands(tradingDay));

                    return new ChartSeries[3]
                    {
                        new UpperBollingerBandChartSeries(
                            StockChartSeriesColor.BOLLINGER_BANDS,
                            bollingerBandValues.Select(bbValue => new LineSeriesDataPoint
                                {
                                    X = bbValue.Date,
                                    Y = bbValue.UpperBandValue
                                })),
                        new MiddleBollingerBandChartSeries(
                            StockChartSeriesColor.BOLLINGER_BANDS,
                            bollingerBandValues.Select(bbValue => new LineSeriesDataPoint
                                {
                                    X = bbValue.Date,
                                    Y = bbValue.MovingAverageValue
                                })),
                        new LowerBollingerBandChartSeries(
                            StockChartSeriesColor.BOLLINGER_BANDS,
                            bollingerBandValues.Select(bbValue => new LineSeriesDataPoint
                                {
                                    X = bbValue.Date,
                                    Y = bbValue.LowerBandValue
                                }))
                    };
                case StockChartSeriesName.PRICE:
                    var priceData = new List<PriceSeriesDataPoint>();

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        priceData.Add(new PriceSeriesDataPoint
                        {
                            X = stockHistoryData[i].Date,
                            Open = stockHistoryData[i].Open,
                            High = stockHistoryData[i].High,
                            Low = stockHistoryData[i].Low,
                            Close = stockHistoryData[i].AdjClose,
                            Color = stockHistoryData[i].Close > stockHistoryData[i].Open
                                    ? StockChartSeriesColor.WHITE
                                    : i > 0 && stockHistoryData[i].AdjClose < stockHistoryData[i - 1].AdjClose
                                    ? StockChartSeriesColor.DOWN_PRICE
                                    : StockChartSeriesColor.UP_PRICE,
                            LineColor = i > 0 && stockHistoryData[i].AdjClose < stockHistoryData[i - 1].AdjClose
                                    ? StockChartSeriesColor.DOWN_PRICE
                                    : StockChartSeriesColor.UP_PRICE
                        });
                    }

                    return new PriceChartSeries[1]
                    {
                        new PriceChartSeries(priceData)
                    };
                case StockChartSeriesName.SMA:
                    this.numberOfUpperSeriesCreated++;
                    var smaCalculator = new SimpleMovingAverageCalculator(int.Parse(stockChartSeriesRequest.Params));

                    return new SimpleMovingAverageChartSeries[1]
                    {
                        new SimpleMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day SMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData.Select(
                                tradingDay =>
                                new LineSeriesDataPoint
                                {
                                    X = tradingDay.Date,
                                    Y = smaCalculator.CalculateMovingAverage(tradingDay.AdjClose)
                                }))
                    };
                case StockChartSeriesName.VOLUME:
                    this.numberOfChartsCreated++;
                    var volumeData = new List<ColumnSeriesDataPoint>();

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        volumeData.Add(
                            new ColumnSeriesDataPoint
                            {
                                X = stockHistoryData[i].Date,
                                Y = stockHistoryData[i].Volume,
                                Color = i > 0 && stockHistoryData[i].AdjClose < stockHistoryData[i - 1].AdjClose
                                    ? StockChartSeriesColor.DOWN_PRICE
                                    : StockChartSeriesColor.UP_PRICE
                            });
                    }

                    return new VolumeChartSeries[1] 
                    {
                        new VolumeChartSeries(this.numberOfChartsCreated, volumeData)
                    };
                default:
                    return null;
            }
        }

        #endregion
    }
}
