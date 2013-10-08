using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SidBy.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateManager um = new UpdateManager();
            um.UseProxy = true;
            um.GetReleaseInfo();
        }
    }
}
