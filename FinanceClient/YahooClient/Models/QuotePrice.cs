﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.FinanceClient.YahooClient.Models
{
    public class QuotePrice
    {
        public string Symbol { get; set; }

        public string Exchange { get; set; }

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public long Volume { get; set; }

        public DateTime Timestamp { get; set; } = new DateTime();
    }
}
