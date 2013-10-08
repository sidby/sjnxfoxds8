using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rent.IrrBy
{
    public class IrrByRentParser : IRentParser
    {
        private const string StartDataFlag = "<table class=\"adListTable\">";
        private const string EndDataFlag = "<ul class=\"fpages\">";
        private const string AdSeparator = "<tr class=\"advertRow\">";
        private const string AdIdStartPattern = "ad_id=\"";
        private const char AdIdEndPattern = '\"';
        private const string AdCreatedStartPattern = "date_create=\"";
        private const char AdCreatedEndPattern = '\"';

        private const string PriceStartPattern = "priceUSD\">";
        private const char PriceEndPattern = '&';

        private const string AdOwnerLoginNameStartPattern = "user_login=\"";
        private const char AdOwnerLoginNameEndPattern = '\"';

        private const string AdOwnerUserUrlStartPattern = "user_url=\"";
        private const char AdOwnerUserUrlEndPattern = '\"';

        private const string DescriptionStartPattern = "<p>";
        private const char DescriptionEndPattern = '<';

        private const string LinkStartPattern = "<a href=\"";
        private const char LinkEndPattern = '<';

        public List<RentedApartment> Parse(string siteDomain, string html)
        { 
            return Parse(siteDomain, html, null, null);
        }

        public List<RentedApartment> Parse(string siteDomain, string html, string[] adOwnerLoginNameFilter, string[] adDescriptionFilter)
        {
            string cHtml = String.Empty;

            if (!String.IsNullOrEmpty(html))
            {
                int startIndex = html.IndexOf(StartDataFlag);
                if (startIndex > 0)
                {
                    cHtml = html.Remove(0, startIndex + StartDataFlag.Length);
                    int endIndex = cHtml.IndexOf(EndDataFlag);
                    if (endIndex > 0)
                        cHtml = cHtml.Remove(endIndex, cHtml.Length - endIndex);
                }
            }

            RentedApartmentCollection collection = new RentedApartmentCollection();

            List<RentedApartment> apartments = new List<RentedApartment>();
            string[] stringSeparators = new string[] { "<tr class=\"advertRow\">" };

            string[] matchAds = cHtml.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string matchAd in matchAds)
            {
                RentedApartment apartment = new RentedApartment();

                string ad_id = ParserHelper.GetDataValue(matchAd, AdIdStartPattern, AdIdEndPattern);
                if (!String.IsNullOrEmpty(ad_id))
                    apartment.AdId = ulong.Parse(ad_id);
                else
                    continue;

                apartment.IsFiltered = false;

                string date_create = ParserHelper.GetDataValue(matchAd, AdCreatedStartPattern, AdCreatedEndPattern);
                if (!String.IsNullOrEmpty(date_create))
                    apartment.AdCreated = GetDateTime(date_create);

                string price_usd = ParserHelper.GetDataValue(matchAd, PriceStartPattern, PriceEndPattern);
                if (!String.IsNullOrEmpty(price_usd))
                {
                    ulong price = 0;
                    ulong.TryParse(price_usd, out price);
                    apartment.Price = price;
                }

                // http://irr.by/user/488351/
                string user_url = ParserHelper.GetDataValue(matchAd, AdOwnerUserUrlStartPattern, AdOwnerUserUrlEndPattern);
                if (!String.IsNullOrEmpty(user_url))
                {
                    apartment.AdOwnerUserUrl = siteDomain + user_url;

                    // Parse OwnerId
                    string ownerIdStr = Regex.Match(user_url, @"\d+").Value;
                    if (!String.IsNullOrEmpty(ownerIdStr))
                        apartment.AdOwnerId = ulong.Parse(ownerIdStr);
                }

                GetLinkAndTitle(siteDomain, apartment, matchAd, LinkStartPattern, LinkEndPattern);

                string user_login = ParserHelper.GetDataValue(matchAd, AdOwnerLoginNameStartPattern, AdOwnerLoginNameEndPattern);
                if (!String.IsNullOrEmpty(user_login))
                {
                    if (adOwnerLoginNameFilter != null && !apartment.IsFiltered)
                    {
                        foreach (string filter in adOwnerLoginNameFilter)
                        {
                            if (user_login.IndexOf(filter, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                            {
                                apartment.IsFiltered = true;
                                break;
                            }
                        }
                    }

                    apartment.AdOwnerLoginName = user_login;
                }

                string description = ParserHelper.GetDataValue(matchAd, DescriptionStartPattern, DescriptionEndPattern);
                if (!String.IsNullOrEmpty(description))
                {
                    if (adDescriptionFilter != null && !apartment.IsFiltered)
                    {
                        foreach (string filter in adDescriptionFilter)
                        {
                            if (description.IndexOf(filter, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                            {
                                apartment.IsFiltered = true;
                                break;
                            }
                        }
                    }

                    apartment.Description = description;
                }

                apartments.Add(apartment);
            }

            return apartments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apartment"></param>
        /// <param name="source"></param>
        /// <param name="startPattern"></param>
        /// <param name="endPattern"></param>
        private static void GetLinkAndTitle(string siteDomain, RentedApartment apartment, string source, string startPattern, char endPattern)
        {
            if (String.IsNullOrEmpty(source) || apartment == null)
                return;

            int startIndex = source.IndexOf(startPattern);

            if (startIndex < 0)
                return;

            string startPart = source.Substring(startIndex + startPattern.Length);

            StringBuilder sbLink = new StringBuilder();
            StringBuilder sbTitle = new StringBuilder();

            bool parsingLink = true;
            foreach (char symb in startPart)
            {
                if (symb == endPattern)
                    break;

                if (parsingLink && symb != '"')
                    sbLink.Append(symb);
                else if (parsingLink)
                    parsingLink = false;
                else if (symb != '>')
                    sbTitle.Append(symb);
            }

            apartment.Title = sbTitle.ToString();
            apartment.AdUrl = siteDomain + sbLink.ToString();
        }

        /// <summary>
        /// Parse "hh:mm, dd.MM.YYYY" pattern
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static DateTime GetDateTime(string text)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string[] dattime = text.Split(',');
            if (dattime.Length != 2)
                return new DateTime();

            string[] hhmm = dattime[0].Trim().Split(':');

            if (hhmm.Length != 2)
                return new DateTime();

            string[] ddMMYYYY = dattime[1].Trim().Split('.');
            if (ddMMYYYY.Length != 3)
                return new DateTime();

            return new DateTime(Int32.Parse(ddMMYYYY[2]),
                Int32.Parse(ddMMYYYY[1]), Int32.Parse(ddMMYYYY[0]), Int32.Parse(hhmm[0]), Int32.Parse(hhmm[1]), 0);
        }
    }
}
