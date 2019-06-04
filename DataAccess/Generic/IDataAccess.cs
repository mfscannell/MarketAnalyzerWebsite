using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.DataAccess.Generic
{
    public interface IDataAccess
    {
        void CloseConnection();

        void Dispose();

        IStockPriceDataAccess GetStockPriceDataAccess();

        IUserDataAccess GetUserDataAccess();
    }
}
