using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Responses.ChartSeries.DataPoints
{
    public class PriceSeriesDataPoint : SeriesDataPoint
    {
        public DateTime X { get; set; }

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public string Color { get; set; }

        public string LineColor { get; set; }
    }
}
