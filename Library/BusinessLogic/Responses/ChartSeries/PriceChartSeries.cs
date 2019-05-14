using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class PriceChartSeries : ChartSeries
    {
        #region Constructors

        public PriceChartSeries(IEnumerable<PriceSeriesDataPoint> dataPoints) : base()
        {
            this.Name = StockChartSeriesName.PRICE;
            this.Type = ChartType.CANDLESTICK;
            this.Data = dataPoints;
        }

        #endregion
    }
}
