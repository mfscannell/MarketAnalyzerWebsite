using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class UpperBollingerBandChartSeries : ChartSeries
    {
        #region Constructors

        public UpperBollingerBandChartSeries(string color, IEnumerable<SeriesDataPoint> dataPoints) : base()
        {
            this.Name = "Upper Bollinger Band";
            this.Type = ChartType.LINE;
            this.Color = color;
            this.Data = dataPoints;
        }

        #endregion
    }
}
