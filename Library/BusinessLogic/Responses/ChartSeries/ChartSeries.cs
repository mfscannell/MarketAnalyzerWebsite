using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Library.BusinessLogic.Enums;
using FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries
{
    public class ChartSeries
    {
        #region Constructors and Destructors

        public ChartSeries()
        {
            DashStyle = Enums.DashStyle.SOLID;
            Data = new List<SeriesDataPoint>();
            LineWidth = 1;
            Name = string.Empty;
            Type = string.Empty;
            YAxis = 0;
        }

        #endregion

        #region Public Properties

        public string Color { get; set; }

        public string DashStyle { get; set; }

        public IEnumerable<SeriesDataPoint> Data { get; set; }

        public int LineWidth { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int YAxis { get; set; }

        #endregion
    }
}
