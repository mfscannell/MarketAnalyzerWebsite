using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class TechnicalIndicator
    {
        #region Public Constants

        public const string BOLLINGER_BANDS = "Bollinger Bands";

        public const string CHART_TYPE_LINE = "line";

        public const string EMA = "EMA";

        public const string SMA = "SMA";

        #endregion

        #region Public Properties

        public string Type { get; set; }

        public string Params { get; set; }

        #endregion

        #region Public Methods

        public string GetChartType()
        {
            switch (this.Type)
            {
                case TechnicalIndicator.EMA:
                    return TechnicalIndicator.CHART_TYPE_LINE;
                case TechnicalIndicator.SMA:
                    return TechnicalIndicator.CHART_TYPE_LINE;
                default:
                    return "";
            }
        }

        public string GetName()
        {
            switch (this.Type)
            {
                case TechnicalIndicator.EMA:
                    return $"{this.Params}-Day EMA";
                case TechnicalIndicator.SMA:
                    return $"{this.Params}-Day SMA";
                default:
                    return "";
            }
        }

        public int GetNumPreviousCalendarDays()
        {
            switch (this.Type)
            {
                case TechnicalIndicator.EMA:
                    return int.Parse(this.Params) * -2;
                case TechnicalIndicator.SMA:
                    return int.Parse(this.Params) * -2;
                default:
                    return 0;
            }
        }

        public ITechnicalIndicatorCalculator GetTechnicalCalculator()
        {
            switch (this.Type)
            {
                case TechnicalIndicator.SMA:
                    return new SimpleMovingAverage(int.Parse(this.Params));
                default:
                    return null;
            }
        }

        #endregion
    }
}
