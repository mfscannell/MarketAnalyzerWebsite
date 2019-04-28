using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Responses
{
    public class VolumeData : StockData
    {

        #region Public Properties

        public DateTime Date { get; set; }

        public long Volume { get; set; }

        #endregion
    }
}
