using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class SimpleMovingAverageChartSeries : ChartSeries
    {
        #region Constructors

        public SimpleMovingAverageChartSeries(string name, string color) : base()
        {
            this.Name = name;
            this.Type = ChartType.CHART_TYPE_LINE;
            this.Color = color;
        }

        #endregion
    }
}
