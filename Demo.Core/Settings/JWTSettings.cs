using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Settings
{
    public class JWTSettings
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public int TokenExpiry_Minutes { get; set; }
        public int ExtendedExpiry_Minutes { get; set; }
    }
}
