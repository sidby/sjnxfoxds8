using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;


namespace SidBy.Test
{
    public class UpdateManager
    {
        public bool UseProxy { get; set; }

        public void GetReleaseInfo()
        {
            string queryString = "http://d-hub.net/Progs/UpdateCheck";
            // string queryString = "http://localhost:63184/UpdateCheck";
                                    
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);
            
            string appVersion = "1.0.0.0";
            string OSVersion = Environment.OSVersion.Version.ToString();
            string envVersion = Environment.Version.ToString();
            string culture = Thread.CurrentThread.CurrentCulture.Name;

            string bitOSVersion = "WOW64";
            if (!Environment.Is64BitOperatingSystem)
                bitOSVersion = "Win32";

            // is Environment.Is64BitOperatingSystem

            if (UseProxy)
            {
                request.Proxy = HttpWebRequest.DefaultWebProxy;
                request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.PreAuthenticate = true;
            }

            request.UseDefaultCredentials = true;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            // User-Agent: Fiddler/2.4.5.0 (.NET 2.0.50727.4963; WinNT 6.1.7600.0; ru-RU; 1xAMD64)
            request.UserAgent = "Rent/" + appVersion + " (.NET " + envVersion + "; WinNT " + OSVersion + "; " + culture + "; " + bitOSVersion + ")";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3";
            request.Referer = "http://d-hub.net/Progs/Rent/client/" + appVersion;
            
            using (WebResponse response = request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            {
                string html = String.Empty;
               // Debugger.Launch();

                if (dataStream.CanRead)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(dataStream))
                        {
                            html = sr.ReadToEnd();

                            if (!String.IsNullOrEmpty(html))
                            {
                                try
                                {
                                    XDocument xd = XDocument.Parse(html);
                                }
                                catch (XmlException ex)
                                {
                                    // Logging.Log.Error(String.Format("Ошибка парсинга xml документа файла обновлений"), ex);

                                    // no xml was returned
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(String.Format("Сайт {0} недоступен. Попробуйте позже", queryString), ex);
                        // Logging.Log.Error(String.Format("Сайт {0} недоступен. Попробуйте позже", SiteDomain), ex);
                    }
                    finally
                    {
                        dataStream.Close();
                        response.Close();
                    }
                }
            }
        }
    }
}
