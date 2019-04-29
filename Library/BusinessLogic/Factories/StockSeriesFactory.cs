using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.Responses;
using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Factories
{
    public class StockSeriesFactory
    {
        public static StockSeries[] InitializeStockSeries(TechnicalIndicatorRequest technicalIndicator)
        {
            switch (technicalIndicator.Type)
            {
                case TechnicalIndicatorType.BOLLINGER_BANDS:
                    return new StockSeries[3] 
                    {
                        new StockSeries
                        {
                            Data = new List<List<object>>(),
                            Name = "Upper Bollinger Band",
                            Type = ChartType.CHART_TYPE_LINE,
                            YAxis = 0
                        },
                        new StockSeries
                        {
                            DashStyle = Enums.DashStyle.DOT,
                            Data = new List<List<object>>(),
                            Name = "Middle Bollinger Band",
                            Type = ChartType.CHART_TYPE_LINE,
                            YAxis = 0
                        },
                        new StockSeries
                        {
                            Data = new List<List<object>>(),
                            Name = "Lower Bollinger Band",
                            Type = ChartType.CHART_TYPE_LINE,
                            YAxis = 0
                        }
                    };
                case TechnicalIndicatorType.EMA:
                    return new StockSeries[1]
                    {
                        new StockSeries
                        {
                            Data = new List<List<object>>(),
                            Name = $"{technicalIndicator.Params}-Day EMA",
                            Type = ChartType.CHART_TYPE_LINE,
                            YAxis = 0
                        }
                    };
                case TechnicalIndicatorType.SMA:
                    return new StockSeries[1]
                    {
                        new StockSeries
                        {
                            Data = new List<List<object>>(),
                            Name = $"{technicalIndicator.Params}-Day SMA",
                            Type = ChartType.CHART_TYPE_LINE,
                            YAxis = 0
                        }
                    };
                default:
                    return null;
            }
        }
    }
}
