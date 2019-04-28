using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class TechnicalIndicator
    {
        #region Public Constants

        public const string BOLLINGER_BANDS = "Bollinger Bands";

        public const string EMA = "EMA";

        public const string SMA = "SMA";

        #endregion

        #region Public Properties

        public string Type { get; set; }

        public string Params { get; set; }

        #endregion

        #region Public Methods

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

        #endregion
    }
}
