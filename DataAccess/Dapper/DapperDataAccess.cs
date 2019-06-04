using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using FinanceWebsite.DataAccess.Generic;

namespace FinanceWebsite.DataAccess.Dapper
{
    public class DapperDataAccess : IDataAccess
    {
        #region Private Fields

        private SqlConnection dapperConnection;

        private const string sqlConn = "Server=DESKTOP-IA6DI2G;Database=FinanceWebsite;Integrated Security=SSPI";

        #endregion

        #region Constructors

        public DapperDataAccess()
        {
            this.dapperConnection = new SqlConnection(sqlConn);
        }

        #endregion

        #region Public Methods

        public void CloseConnection()
        {
            this.dapperConnection.Close();
        }

        public void Dispose()
        {
            this.dapperConnection.Dispose();
        }

        public IStockPriceDataAccess GetStockPriceDataAccess()
        {
            return new DapperStockPriceDataAccess(this.dapperConnection);
        }

        public IUserDataAccess GetUserDataAccess()
        {
            return new DapperUserDataAccess(this.dapperConnection);
        }

        #endregion
    }
}
