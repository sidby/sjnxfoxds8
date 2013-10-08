using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SidBy.Web.UpdateManager.Helpers
{
    public static class AppVersionHelper
    {
        private const int VersionDigitPlaces = 2;

        private static Regex digitsOnly = new Regex(@"[^\d]");

        public static bool IsValidReferrer(Uri referrer)
        {
            if (referrer == null)
                return false;

            if (referrer.Host != Constansts.Host)
                return false;

            return true;
        }

        public static int GetAppVersionFromQuery(string data)
        {
            if (String.IsNullOrEmpty(data))
                return -1;

            int lastSlash = data.LastIndexOf('/');
            if (lastSlash > 0)
                return GetAppVersion(data.Remove(0, lastSlash + 1));

            return -1;
        }

        public static int GetAppVersion(string versionString)
        {
            string[] splitVersion = versionString.Split('.');
            StringBuilder sb = new StringBuilder();
            foreach (var split in splitVersion)
            {
                if (!String.IsNullOrEmpty(split))
                {
                    string digOnly = digitsOnly.Replace(split, "").ToString();
                    if (!String.IsNullOrEmpty(digOnly))
                        sb.Append(digOnly.PadRight(VersionDigitPlaces, '0'));
                }
            }

            int ver = -1;

            Int32.TryParse(sb.ToString(), out ver);
            return ver;
        }
    }
}