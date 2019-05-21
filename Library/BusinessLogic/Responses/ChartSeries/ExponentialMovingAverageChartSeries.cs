using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class ExponentialMovingAverageChartSeries : ChartSeries
    {
        #region Constructors

        public ExponentialMovingAverageChartSeries(string name, string color, IEnumerable<LineSeriesDataPoint> data) : base()
        {
            this.Name = name;
            this.Type = ChartType.LINE;
            this.Color = color;
            this.Data = data;
        }

        #endregion
    }
}
