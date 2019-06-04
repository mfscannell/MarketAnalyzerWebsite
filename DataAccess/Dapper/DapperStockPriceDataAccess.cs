using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Dapper;

using FinanceWebsite.Common.Domain;
using FinanceWebsite.DataAccess.Generic;

namespace FinanceWebsite.DataAccess.Dapper
{
    public class DapperStockPriceDataAccess : IStockPriceDataAccess
    {
        #region Private Fields

        private SqlConnection dapperConnection;

        #endregion

        #region Constructors

        public DapperStockPriceDataAccess(SqlConnection dapperConnection)
        {
            this.dapperConnection = dapperConnection;
        }

        #endregion

        #region Public Methods

        public List<HistoryPrice> GetStockPriceHistory(string tickerSymbol, DateTime beginDate, DateTime endDate)
        {
            return this.dapperConnection.Query<HistoryPrice>(
                "SELECT [Date], [Open], [High], [Low], [Close], [Volume], [AdjClose] FROM [dbo].[StockPrices] WHERE [Symbol] = @Symbol AND @BeginDate <= [Date] AND [Date] <= @EndDate",
                new
                {
                    Symbol = tickerSymbol,
                    BeginDate = beginDate,
                    EndDate = endDate
                }).ToList();
        }

        #endregion
    }
}
