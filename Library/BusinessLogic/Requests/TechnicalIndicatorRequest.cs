using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.TechnicalIndicators;
using FinanceWebsite.Library.BusinessLogic.Responses;
using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Requests
{
    public class TechnicalIndicatorRequest
    {
        #region Public Properties

        public string Type { get; set; }

        public string Params { get; set; }

        #endregion

        #region Public Methods

        public int GetNumPreviousCalendarDays()
        {
            // TODO need to move this out of this class
            switch (this.Type)
            {
                case TechnicalIndicatorType.EMA:
                    return int.Parse(this.Params) * -2;
                case TechnicalIndicatorType.SMA:
                    return int.Parse(this.Params) * -2;
                default:
                    return 0;
            }
        }

        #endregion
    }
}
