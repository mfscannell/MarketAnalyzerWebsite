using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class ChartSeries
    {
        #region Constructors and Destructors

        public ChartSeries()
        {
            DashStyle = Enums.DashStyle.SOLID;
            Type = string.Empty;
            Name = string.Empty;
            Data = new List<List<object>>();
            YAxis = 0;
        }

        #endregion

        #region Public Properties

        public string DashStyle { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public List<List<Object>> Data { get; set; }

        public int YAxis { get; set; }

        #endregion
    }
}
