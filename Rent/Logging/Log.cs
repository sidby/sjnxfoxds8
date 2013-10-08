using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent
{
    internal class Logging
    {
        internal static readonly ILog Log = LogManager.GetLogger("Rent");
    }
}
