using Rent.IrrBy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Rent.IrrBy
{
    public class IrrBySiteRentData
    {
        public const string SiteDomain = "http://irr.by";
        // /rooms=1%2C2
        private string Uri = "/realestate/longtime/search/geo_city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA/price=%D0%BC%D0%B5%D0%BD%D1%8C%D1%88%D0%B5+{0}/currency=USD/tab=users/page_len{1}/";

        public bool UseProxy { get; set; }

        public string AdOwnerLoginNameFilter { get; set; }
        public string AdDescriptionFilter { get; set; }

        public IrrBySiteRentData()
        {
            UseProxy = false;
        }

        public RentedApartmentCollection GetData(int itemsOnPage, int priceUpperLimit)
        {
            string queryString = SiteDomain + String.Format(Uri, priceUpperLimit, itemsOnPage);

            List<RentedApartment> apartments = new List<RentedApartment>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);

            if (UseProxy)
            {
                request.Proxy = HttpWebRequest.DefaultWebProxy;
                request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.PreAuthenticate = true;
            }
            
            request.UseDefaultCredentials = true;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3";
            
            using(WebResponse response = request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            {
                string html = String.Empty;

                if (dataStream.CanRead)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(dataStream))
                        {
                            html = sr.ReadToEnd();
                        }
                    }
                    catch (IOException ex)
                    {
                        Logging.Log.Error(String.Format("Сайт {0} недоступен. Попробуйте позже", SiteDomain), ex);
                    }
                    finally
                    {
                        dataStream.Close();
                        response.Close();
                    }

                    IrrByRentParser parser = new IrrByRentParser();

                    string[] adOwnerLoginNameFilterArr = null;
                    string[] adDescriptionFilterArr = null;

                    if (!String.IsNullOrEmpty(AdOwnerLoginNameFilter))
                        adOwnerLoginNameFilterArr = AdOwnerLoginNameFilter.Split(';');
                    if (!String.IsNullOrEmpty(AdDescriptionFilter))
                        adDescriptionFilterArr = AdDescriptionFilter.Split(';');

                    apartments = parser.Parse(SiteDomain, html, adOwnerLoginNameFilterArr, adDescriptionFilterArr);

                }
            }

            RentedApartmentCollection collection = new RentedApartmentCollection
            {
                apartments = apartments,
                SiteDomain = SiteDomain
            };

            return collection;
        }
    }
}
