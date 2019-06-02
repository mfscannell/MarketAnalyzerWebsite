using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

using FinanceWebsite.Common.Domain;

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
            List<HistoryPrice> stockHistoryData,
            DateTime beginDate,
            DateTime endDate)
        {
            switch (stockChartSeriesRequest.Type)
            {
                case StockChartSeriesNameEnum.BollingerBands:
                    this.numberOfUpperSeriesCreated++;
                    var bollingerBandsCalculator = new BollingerBandsCalculator(
                        BollingerBandsCalculator.ParseNumDays(stockChartSeriesRequest.Params),
                        BollingerBandsCalculator.ParseNumStandardDeviations(stockChartSeriesRequest.Params));
                    var bollingerBandValues = stockHistoryData
                        .Select(tradingDay => bollingerBandsCalculator.CalculateBollingerBands(tradingDay))
                        .Where(bbValue => beginDate <= bbValue.Date && bbValue.Date <= endDate);

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
                case StockChartSeriesNameEnum.Ema:
                    this.numberOfUpperSeriesCreated++;
                    var emaCalculator = new ExponentialMovingAverageCalculator(int.Parse(stockChartSeriesRequest.Params));

                    return new ExponentialMovingAverageChartSeries[1]
                    {
                        new ExponentialMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day EMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = emaCalculator.CalculateMovingAverage(tradingDay.AdjClose)
                                    })
                                .Where(ema => beginDate <= ema.X && ema.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Price:
                    var priceData = new List<PriceSeriesDataPoint>();

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        if (beginDate <= stockHistoryData[i].Date && stockHistoryData[i].Date <= endDate)
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
                    }

                    return new PriceChartSeries[1]
                    {
                        new PriceChartSeries(priceData)
                    };
                case StockChartSeriesNameEnum.Rsi:
                    this.numberOfChartsCreated++;
                    var rsiCalculator = new RelativeStrengthIndexCalculator(int.Parse(stockChartSeriesRequest.Params));

                    return new RelativeStrengthIndexChartSeries[1]
                    {
                        new RelativeStrengthIndexChartSeries(
                            this.numberOfChartsCreated,
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = rsiCalculator.CalculateRelativeStrengthIndex(tradingDay.AdjClose)
                                    })
                                .Where(rsi => beginDate <= rsi.X && rsi.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Sma:
                    this.numberOfUpperSeriesCreated++;
                    var smaCalculator = new SimpleMovingAverageCalculator(int.Parse(stockChartSeriesRequest.Params));

                    return new SimpleMovingAverageChartSeries[1]
                    {
                        new SimpleMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day SMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = smaCalculator.CalculateMovingAverage(tradingDay.AdjClose)
                                    })
                                .Where(sma => beginDate <= sma.X && sma.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Tema:
                    this.numberOfUpperSeriesCreated++;
                    var temaCalculator = new TripleExponentialMovingAverageCalculator(
                        int.Parse(stockChartSeriesRequest.Params));

                    return new TripleExponentialMovingAverageChartSeries[1]
                    {
                        new TripleExponentialMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day TEMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = temaCalculator.CalculateMovingAverage(tradingDay.AdjClose)
                                    })
                                .Where(tema => beginDate <= tema.X && tema.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Vema:
                    this.numberOfUpperSeriesCreated++;
                    var vemaCalculator = new VolumeExponentialMovingAverageCalculator(
                        int.Parse(stockChartSeriesRequest.Params));

                    return new VolumeExponentialMovingAverageChartSeries[1]
                    {
                        new VolumeExponentialMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day VEMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = vemaCalculator.CalculateMovingAverage(tradingDay.AdjClose, tradingDay.Volume)
                                    })
                                .Where(vema => beginDate <= vema.X && vema.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Vwma:
                    this.numberOfUpperSeriesCreated++;
                    var vwmaCalculator = new VolumeWeightedMovingAverageCalculator(
                        int.Parse(stockChartSeriesRequest.Params));

                    return new SimpleMovingAverageChartSeries[1]
                    {
                        new SimpleMovingAverageChartSeries(
                            $"{stockChartSeriesRequest.Params}-Day VWMA",
                            StockChartSeriesColor.UPPERS[this.numberOfUpperSeriesCreated],
                            stockHistoryData
                                .Select(tradingDay =>
                                    new LineSeriesDataPoint
                                    {
                                        X = tradingDay.Date,
                                        Y = vwmaCalculator.CalculateMovingAverage(tradingDay.AdjClose, tradingDay.Volume)
                                    })
                                .Where(vwma => beginDate <= vwma.X && vwma.X <= endDate))
                    };
                case StockChartSeriesNameEnum.Volume:
                    this.numberOfChartsCreated++;
                    var volumeData = new List<ColumnSeriesDataPoint>();

                    for (var i = 0; i < stockHistoryData.Count; i++)
                    {
                        if (beginDate <= stockHistoryData[i].Date && stockHistoryData[i].Date <= endDate)
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
