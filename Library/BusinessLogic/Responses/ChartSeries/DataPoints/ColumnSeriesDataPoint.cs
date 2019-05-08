using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints
{
    public class ColumnSeriesDataPoint : SeriesDataPoint
    {
        public DateTime X { get; set; }

        public double Y { get; set; }

        public string Color { get; set; }
    }
}
