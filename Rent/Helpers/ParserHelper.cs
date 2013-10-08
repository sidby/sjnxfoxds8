using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Rent
{
    public static class ParserHelper
    {
        public static string GetDataValue(string source, string startPattern, char endPattern)
        {
            if (String.IsNullOrEmpty(source))
                return String.Empty;

            int startIndex = source.IndexOf(startPattern);

            if (startIndex < 0)
                return String.Empty;

            string startPart = source.Substring(startIndex + startPattern.Length);

            StringBuilder sb = new StringBuilder();

            foreach (char symb in startPart)
            {
                if (symb != endPattern)
                    sb.Append(symb);
                else
                    break;
            }

            return sb.ToString();
        }
    }
}
