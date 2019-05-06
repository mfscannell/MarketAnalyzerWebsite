using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceWebsite.Library.BusinessLogic.Requests;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;
using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Factories
{
    public class TechnicalIndicatorCalculatorFactory
    {
        public static ITechnicalIndicatorCalculator GetTechnicalIndicatorCalculator(StockChartSeriesRequest technicalIndicator)
        {
            switch (technicalIndicator.Type)
            {
                case StockChartSeriesType.BOLLINGER_BANDS:
                    // TODO:  this assumes the parameters passed in are valid.
                    var paramsArrayString = technicalIndicator.Params.Split(',');
                    var paramsArrayInt = new int[2] { int.Parse(paramsArrayString[0]), int.Parse(paramsArrayString[1]) };
                    return new BollingerBandsCalculator(paramsArrayInt[0], paramsArrayInt[1]);
                case StockChartSeriesType.SMA:
                    return new SimpleMovingAverageCalculator(int.Parse(technicalIndicator.Params));
                default:
                    return null;
            }
        }
    }
}
