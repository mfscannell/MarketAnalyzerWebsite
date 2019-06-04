using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Common.Domain
{
    public class User
    {
        public long UserId { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string HashedPassword { get; set; }
    }
}
