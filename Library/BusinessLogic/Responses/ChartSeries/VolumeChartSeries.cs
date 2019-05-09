using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class VolumeChartSeries : ChartSeries
    {
        #region Constructors

        public VolumeChartSeries(int yAxis, IEnumerable<ColumnSeriesDataPoint> dataPoints) : base()
        {
            Name = "Volume";
            Type = ChartType.COLUMN;
            YAxis = yAxis;
            this.Data = dataPoints;
        }

        #endregion
    }
}
