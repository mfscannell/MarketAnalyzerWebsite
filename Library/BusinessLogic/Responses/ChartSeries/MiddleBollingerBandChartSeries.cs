using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class MiddleBollingerBandChartSeries : ChartSeries
    {
        #region Constructors

        public MiddleBollingerBandChartSeries(string color, IEnumerable<SeriesDataPoint> dataPoints) : base()
        {
            this.Name = "Middle Bollinger Band";
            this.Type = ChartType.LINE;
            this.DashStyle = Enums.DashStyle.DOT;
            this.Color = color;
            this.Data = dataPoints;
        }

        #endregion
    }
}
