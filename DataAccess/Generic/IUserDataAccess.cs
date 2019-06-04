using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceWebsite.Common.Domain;

namespace FinanceWebsite.DataAccess.Generic
{
    public interface IUserDataAccess
    {
        void SaveUser(User user);

        bool UserExists(string email, string hashedPassword);
    }
}
