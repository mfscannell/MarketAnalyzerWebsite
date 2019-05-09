using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Library.BusinessLogic.Enums
{
    public class StockChartSeriesColor
    {
        public const string BOLLINGER_BANDS = "navy";

        public const string BLUE = "blue";

        public const string CYAN = "cyan";

        public const string DOWN_PRICE = "red";

        public const string DOWN_VOLUME = "red";

        public const string GREEN = "green";

        public const string MAGENTA = "magenta";

        public const string NAVY = "navy";

        public const string PURPLE = "purple";

        public const string RED = "red";

        public const string UP_PRICE = "green";

        public const string UP_VOLUME = "green";

        public const string YELLOW = "yellow";

        public const string WHITE = "white";

        public static readonly string[] UPPERS = new string[5] { RED, NAVY, CYAN , MAGENTA, MAGENTA};
    }
}
