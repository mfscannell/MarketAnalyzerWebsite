using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    #region Constructors

    public class VolumeWeightedMovingAverageChartSeries : ChartSeries
    {
        public VolumeWeightedMovingAverageChartSeries(string name, string color, IEnumerable<LineSeriesDataPoint> data) : base()
        {
            this.Name = name;
            this.Type = ChartType.LINE;
            this.Color = color;
            this.Data = data;
        }
    }

    #endregion
}
