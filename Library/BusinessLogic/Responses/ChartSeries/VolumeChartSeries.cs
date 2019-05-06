using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class VolumeChartSeries : ChartSeries
    {
        #region Constructors

        public VolumeChartSeries(int yAxis) : base()
        {
            Name = "Volume";
            Type = ChartType.CHART_TYPE_COLUMN;
            YAxis = yAxis;
        }

        #endregion
    }
}
