using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.StockClient.Generic;
using FinanceWebsite.Common.Domain;
using FinanceWebsite.StockClient.Utils;

namespace FinanceWebsite.StockClient.YahooClient
{
    public class YahooStockClient : IGetStockHistory
    {
        #region Public Methods

        public async Task<List<HistoryPrice>> GetPriceAsync(string symbol, DateTime start, DateTime end)
        {
            try
            {
                var csvData = await this.GetRawAsync(symbol, start, end).ConfigureAwait(false);

                if (csvData != null)
                {
                    return await this.ParsePriceAsync(csvData).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

            return new List<HistoryPrice>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get raw stock historical price from Yahoo Finance
        /// </summary>
        /// <param name="symbol">Stock ticker symbol</param>
        /// <param name="start">Starting datetime</param>
        /// <param name="end">Ending datetime</param>
        /// <param name="eventType">Event type (e.g: history, div)</param>
        /// <returns>Raw history price string</returns>
        private async Task<string> GetRawAsync(string symbol, DateTime start, DateTime end, string eventType = "history")
        {
            string csvData = null;

            try
            {
                var url = "https://query1.finance.yahoo.com/v7/finance/download/{0}?period1={1}&period2={2}&interval=1d&events={3}&crumb={4}";

                //if no token found, refresh it
                if (string.IsNullOrEmpty(YahooToken.Cookie) || string.IsNullOrEmpty(YahooToken.Crumb))
                {
                    if (!await YahooToken.RefreshAsync(symbol).ConfigureAwait(false))
                    {
                        return await this.GetRawAsync(symbol, start, end).ConfigureAwait(false);
                    }
                }

                url = string.Format(
                    url, 
                    symbol, 
                    Math.Round(DateTimeConverter.ToUnixTimestamp(start), 0),
                    Math.Round(DateTimeConverter.ToUnixTimestamp(end), 0), 
                    eventType, 
                    YahooToken.Crumb);

                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, YahooToken.Cookie);
                    csvData = await wc.DownloadStringTaskAsync(url).ConfigureAwait(false);
                }
            }
            catch (WebException webEx)
            {
                var response = (HttpWebResponse)webEx.Response;

                //Re-fetching token
                if (response.StatusCode != HttpStatusCode.Unauthorized ||
                    response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }

                Debug.Print(webEx.Message);
                YahooToken.Cookie = "";
                YahooToken.Crumb = "";
                Debug.Print("Re-fetch token");

                return await this.GetRawAsync(symbol, start, end).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

            return csvData;
        }

        private async Task<List<HistoryPrice>> ParsePriceAsync(string csvData)
        {
            return await Task.Run(() =>
            {
                var historyPrices = new List<HistoryPrice>();

                try
                {
                    var rows = csvData.Split(Convert.ToChar(10));

                    //row(0) was ignored because is column names
                    //data is read from oldest to latest
                    for (var i = 1; i <= rows.Length - 1; i++)
                    {
                        var row = rows[i];

                        if (string.IsNullOrEmpty(row))
                        {
                            continue;
                        }

                        var cols = row.Split(',');

                        if (cols[1] == "null")
                        {
                            continue;
                        }

                        var item = new HistoryPrice
                        {
                            Date = DateTime.Parse(cols[0]),
                            Open = Convert.ToDouble(cols[1]),
                            High = Convert.ToDouble(cols[2]),
                            Low = Convert.ToDouble(cols[3]),
                            Close = Convert.ToDouble(cols[4]),
                            AdjClose = Convert.ToDouble(cols[5])
                        };

                        //fixed issue in some currencies quote (e.g: SGDAUD=X)
                        if (cols[6] != "null")
                        {
                            item.Volume = Convert.ToInt64(cols[6]);
                        }

                        historyPrices.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }

                return historyPrices;
            }).ConfigureAwait(false);
        }

        #endregion
    }
}
