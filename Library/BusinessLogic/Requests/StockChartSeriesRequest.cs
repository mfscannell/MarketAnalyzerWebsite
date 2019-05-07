using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class StockChartSeriesRequest
    {
        #region Public Properties

        public string Type { get; set; }

        public string Params { get; set; }

        #endregion

        #region Public Methods

        public int GetNumPreviousCalendarDays()
        {
            // TODO need to move this out of this class
            switch (this.Type)
            {
                case StockChartSeriesType.BOLLINGER_BANDS:
                    return BollingerBandsCalculator.ParseNumDays(this.Params) * -2;
                case StockChartSeriesType.EMA:
                    return int.Parse(this.Params) * -2;
                case StockChartSeriesType.PRICE:
                    return 0;
                case StockChartSeriesType.SMA:
                    return int.Parse(this.Params) * -2;
                case StockChartSeriesType.VOLUME:
                    return 0;
                default:
                    return 0;
            }
        }

        #endregion
    }
}
