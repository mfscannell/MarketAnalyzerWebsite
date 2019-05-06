using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class PriceChartSeries : ChartSeries
    {
        #region Constructors

        public PriceChartSeries() : base()
        {
            Type = ChartType.CHART_TYPE_CANDLESTICK;
        }

        #endregion
    }
}
