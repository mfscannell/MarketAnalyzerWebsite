using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using FinanceWebsite.Common.Core.Encryption.Generic;

using BCrypt.Net;

namespace FinanceWebsite.Common.Core.Encryption.Csp
{
    public class PasswordUtilities : IPasswordUtilities
    {
        #region Public Methods

        public string GenerateSalt()
        {
            var randomNumberGenerator = new RNGCryptoServiceProvider();

            byte[] saltBuffer = new byte[32];

            randomNumberGenerator.GetNonZeroBytes(saltBuffer);

            var salt = BitConverter.ToString(saltBuffer);

            //return BCrypt.Net.BCrypt.GenerateSalt(32);

            return salt;
        }

        public string HashPassword(string submittedPassword, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(submittedPassword, salt);
        }

        public bool ValidatePassword(string submittedPassword, string salt, string hashedPassword)
        {
            //return BCrypt.Net.BCrypt.Verify(submittedPassword, hashedPassword);
            return HashPassword(submittedPassword, salt).Equals(hashedPassword);
        }

        #endregion
    }
}
