using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Common.Core.Encryption.Generic
{
    public interface IPasswordUtilities
    {
        string GenerateSalt();

        string HashPassword(string salt, string submittedPassword);

        bool ValidatePassword(string salt, string submittedPassword, string hashedPassword);
    }
}
