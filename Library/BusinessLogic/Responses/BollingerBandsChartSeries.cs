using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses
{
    public class BollingerBandsChartSeries : ChartSeries
    {
        #region Constructors

        public BollingerBandsChartSeries(string name) : base()
        {
            this.Name = name;
            this.Type = ChartType.CHART_TYPE_LINE;

            if (name.Equals(MIDDLE_BOLLINGER_BAND))
            {
                this.DashStyle = Enums.DashStyle.DOT;
            }
        }

        #endregion

        #region

        public const string UPPER_BOLLINGER_BAND = "Upper Bollinger Band";

        public const string MIDDLE_BOLLINGER_BAND = "Middle Bollinger Band";

        public const string LOWER_BOLLINGER_BAND = "Lower Bollinger Band";
        #endregion
    }
}
