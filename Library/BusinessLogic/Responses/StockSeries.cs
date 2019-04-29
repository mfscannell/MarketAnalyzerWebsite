using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Responses
{
    public class StockSeries
    {
        #region Constructors and Destructors

        public StockSeries()
        {
            Type = string.Empty;
            Name = string.Empty;
            Data = new List<List<object>>();
            YAxis = 0;
        }

        #endregion

        #region Public Properties

        public string Type { get; set; }

        public string Name { get; set; }

        public List<List<Object>> Data { get; set; }

        public int YAxis { get; set; }

        #endregion
    }
}
