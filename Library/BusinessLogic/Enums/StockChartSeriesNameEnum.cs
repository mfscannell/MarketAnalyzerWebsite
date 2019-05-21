using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
//using System.Data.Metadata.Edm;

using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FinanceWebsite.Library.BusinessLogic.Enums
{
    public enum StockChartSeriesNameEnum
    {
        [Description("Bollinger Bands")]
        [EnumMember(Value = "Bollinger Bands")]
        BollingerBands,

        [Description("EMA")]
        Ema,

        [EnumMember(Value = "Price")]
        Price,

        [EnumMember(Value = "Rsi")]
        Rsi,

        [Description("SMA")]
        [EnumMember(Value = "SMA")]
        Sma,

        [Description("Triple EMA")]
        [EnumMember(Value = "Triple EMA")]
        Tema,

        [Description("VWMA")]
        [EnumMember(Value = "VWMA")]
        Vwma,

        [EnumMember(Value = "Volume")]
        Volume
    }
}
