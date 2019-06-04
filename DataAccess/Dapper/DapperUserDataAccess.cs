using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using FinanceWebsite.Common.Domain;
using FinanceWebsite.DataAccess.Generic;
using FinanceWebsite.Common.Domain;

namespace FinanceWebsite.DataAccess.Dapper
{
    public class DapperUserDataAccess : IUserDataAccess
    {
        #region Private Fields

        private SqlConnection dapperConnection;

        #endregion

        #region Constructors

        public DapperUserDataAccess(SqlConnection dapperConnection)
        {
            this.dapperConnection = dapperConnection;
        }

        #endregion

        #region Public Methods

        public void SaveUser(User user)
        {
            this.dapperConnection.Execute(
                "INSERT INTO [Users] ([Email], [Salt], [HashedPassword]) VALUES (@UserId, @Email, @Salt, @HashedPassword)", 
                user);
        }

        public bool UserExists(string email, string hashedPassword)
        {
            return this.dapperConnection.Query<int>(
                "SELECT COUNT(1) FROM [Users] WHERE [Email] = @Email AND [HashedPassword] = @HashedPassword",
                new { Email = email, HashedPassword = hashedPassword}).FirstOrDefault() > 0;
        }

        #endregion
    }
}
