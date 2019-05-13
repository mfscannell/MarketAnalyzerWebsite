using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class RelativeStrengthIndexChartSeries : ChartSeries
    {
        #region Constructors

        public RelativeStrengthIndexChartSeries(int yAxis, IEnumerable<LineSeriesDataPoint> data) : base()
        {
            this.Color = StockChartSeriesColor.RED;
            this.Data = data;
            this.Name = StockChartSeriesName.RSI;
            this.Type = ChartType.LINE;
            this.YAxis = yAxis;
        }

        #endregion
    }
}
