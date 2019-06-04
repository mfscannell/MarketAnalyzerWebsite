using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebsite.Common.Core.Encryption.Generic
{
    public interface ISaltGenerator
    {
        string GenerateSalt();
    }
}
