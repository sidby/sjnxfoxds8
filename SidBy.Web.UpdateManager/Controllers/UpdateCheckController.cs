using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using SidBy.Web.UpdateManager.Helpers;

namespace SidBy.Web.UpdateManager.Controllers
{
    public class UpdateCheckController : Controller
    {
        private const string appNewestVersionString = "1.0.0.1";

        public ActionResult Index()
        {
            Uri referrer = Request.UrlReferrer;

            if (!AppVersionHelper.IsValidReferrer(referrer))
                return null;

            int appCurrentVersion = AppVersionHelper.GetAppVersionFromQuery(referrer.PathAndQuery);
            if (appCurrentVersion <= 0)
                return null;

            int appNewestVersion = AppVersionHelper.GetAppVersion(appNewestVersionString);

            if (appCurrentVersion == appNewestVersion)
                return null;
            
            // http://fiddler2.com/client/2.4.5.0
            // http://d-hub.net/Progs/Rent/1.0.0.0

            // TODO: Create upload application releases infrastructure
            // to automatically generate proper xml
            // TODO: Use Sql Database to get releaseinfo
          
            // Latest release
            var xml = new XDocument(
            new XElement("RentUpdates",
                new XElement("Update", new XAttribute("Version", "1.0.0.1"),
                    new XElement("Description", "Это первая версия программы"),
                    new XElement("Url", "http://d-hub.net/Progs/Rent/Rent_1.0.0.1.zip"),
                    new XElement("MD5", "6779e08397dbe492c6f74c2e12ddff19")
                )
            ));

           return new XmlActionResult(xml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progName"></param>
        /// <returns></returns>
        [Obsolete("Not used now")]
        private XDocument GetUpdatesXml(string progName)
        {
            if (String.IsNullOrEmpty(progName))
                throw new ArgumentException("Uknown program name");

            string path = HttpRuntime.AppDomainAppVirtualPath + Path.Combine("UpdatesXml", progName + "Updates.xml");

            XDocument xmlDoc = null;
            using (StreamReader file = System.IO.File.OpenText(path))
                xmlDoc = XDocument.Load(file);

            return xmlDoc;
        }

       
    }
}
