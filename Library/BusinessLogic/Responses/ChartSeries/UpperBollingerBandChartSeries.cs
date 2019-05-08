using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class UpperBollingerBandChartSeries : ChartSeries
    {
        #region Constructors

        public UpperBollingerBandChartSeries(string color) : base()
        {
            this.Name = "Upper Bollinger Band";
            this.Type = ChartType.CHART_TYPE_LINE;
            this.Color = color;
        }

        #endregion
    }
}
