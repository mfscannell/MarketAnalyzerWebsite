using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using FinanceWebsite.Common.Core.Encryption.Generic;

namespace FinanceWebsite.Common.Core.Encryption.Csp
{
    public class CspSaltGenerator : ISaltGenerator
    {
        public string GenerateSalt()
        {
            var randomNumberGenerator = new RNGCryptoServiceProvider();

            byte[] saltBuffer = new byte[32];

            randomNumberGenerator.GetNonZeroBytes(saltBuffer);

            var salt = BitConverter.ToString(saltBuffer);

            return salt;
        }
    }
}
