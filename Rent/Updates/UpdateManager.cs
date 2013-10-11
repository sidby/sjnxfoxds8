using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using Rent.Properties;
using Unified;
using Unified.Network.HTTP;
using System.Windows.Forms;
using Rent.Configuration;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using System.Xml;

namespace Rent.Updates
{
    internal class UpdateManager
    {
        /// <summary>
        /// Check for available application updates.
        /// </summary>
        internal static Task<ReleaseInfo> CheckForUpdates(bool automaticallyUpdate)
        {
            return Task<ReleaseInfo>.Factory.StartNew((autoUpdate) => PerformCheck((bool)autoUpdate), automaticallyUpdate);
        }

        private static ReleaseInfo PerformCheck(bool automaticallyUpdate)
        {
            ReleaseInfo downLoaded = CheckForRentRelease(Program.Info.BuildDate);

            // todo the automatic updates point to wrong URL this feature is not working
            bool autoUpdate = automaticallyUpdate; // obtain from command line arguments
            if (autoUpdate)
            {
                DownloadLatestRelease();
            }

            return downLoaded;
        }

        private static ReleaseInfo CheckForRentRelease(DateTime buildDate)
        {
            try
            {
                return TryCheckForRentRelease(buildDate);
            }
            catch (Exception exception)
            {
                Logging.Log.Error("Failed during CheckForRentRelease.", exception);
                return ReleaseInfo.NotAvailable;
            }
        }

        /// <summary>
        /// check d-hub.net to see if we have a new release available.
        /// Returns not null info about obtained current release.
        /// ReleaseInfo.NotAvailable in a case, new version was not checked or current version is the latest.
        /// </summary>
        private static ReleaseInfo TryCheckForRentRelease(DateTime buildDate)
        {
            var checksFile = new UpdateChecksFile();
            if (!checksFile.ShouldCheckForUpdate)
                return ReleaseInfo.NotAvailable;

            ReleaseInfo downLoaded = DownLoadLatestReleaseInfo(buildDate);
            checksFile.WriteLastCheck();
            return downLoaded;
        }

        private static ReleaseInfo DownLoadLatestReleaseInfo(DateTime buildDate)
        {
            RentUpdates doc = GetLatestVersion();
          
            if (doc != null)
            { 
                string version = doc.Updates.FirstOrDefault().Version;

                return new ReleaseInfo(DateTime.Now, version);
            }

            return ReleaseInfo.NotAvailable;
        }

        private static RentUpdates GetLatestVersion()
        {
            //Settings.Default.UpdateSource;
            string queryString = Settings.Default.UpdateSource;
            // string queryString = "http://localhost:63184/UpdateCheck";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);

            string appVersion = "1.0.0.0";
            string OSVersion = Environment.OSVersion.Version.ToString();
            string envVersion = Environment.Version.ToString();
            string culture = Thread.CurrentThread.CurrentCulture.Name;

            string bitOSVersion = "WOW64";
            if (!Environment.Is64BitOperatingSystem)
                bitOSVersion = "Win32";

            if (Properties.Settings.Default.UseProxy)
            {
                request.Proxy = HttpWebRequest.DefaultWebProxy;
                request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.PreAuthenticate = true;
            }

            request.UseDefaultCredentials = true;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Rent/" + appVersion + " (.NET " + envVersion + "; WinNT " + OSVersion + "; " + culture + "; " + bitOSVersion + ")";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3";
            request.Referer = "http://d-hub.net/Progs/Rent/client/" + appVersion;

            using (WebResponse response = request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            {
                string data = String.Empty;
                // Debugger.Launch();

                if (dataStream.CanRead)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(dataStream))
                        {
                            data = sr.ReadToEnd();

                            if (!String.IsNullOrEmpty(data))
                            {
                                try
                                {
                                    return (RentUpdates)Serialize.DeSerializeXML(data.ToString(), typeof(RentUpdates));
                                }
                                catch (XmlException ex)
                                {
                                    Logging.Log.Error(String.Format("Ошибка парсинга xml документа файла обновлений"), ex);
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Logging.Log.Error(String.Format("Сайт {0} недоступен. Попробуйте позже", queryString), ex);
                    }
                    finally
                    {
                        dataStream.Close();
                        response.Close();
                    }
                }
            }

            return null;
        }

        private static void DownloadLatestRelease()
        {
            const string MainProgramExe = "Rent.exe";
            const string UpdateProgramExe = "RentUpdater.exe";

            try
            {
                RentUpdates updates = GetLatestVersion();
            
                if (updates != null)
                {
                    String currentMd5 = GetMd5HashFromFile(MainProgramExe);
                    if (currentMd5 != null)
                    {
                        //get the latest build
                        System.Data.DataRow row = updates.Tables[0].Rows[0];
                        String md5 = (row["MD5"] as string);
                        if (!md5.Equals(currentMd5))
                        {
                            String version = (row["version"] as String);
                            if (!Directory.Exists("Builds"))
                                Directory.CreateDirectory("Builds");

                            String finalFolder = @"Builds\" + version;
                            if (!Directory.Exists(finalFolder))
                                Directory.CreateDirectory(finalFolder);

                            String filename = String.Format("{0}.zip", version);
                            filename = @"Builds\" + filename;
                            Boolean downloaded = true;

                            if (!File.Exists(filename))
                                downloaded = Web.SaveHTTPToFile((row["Url"] as String), filename);

                            if (downloaded && File.Exists(filename))
                            {
                                FastZip fz = new FastZip();
                                fz.ExtractZip(filename, finalFolder, null);

                                if (MessageBox.Show("Доступна новая версия приложения, хотите установить её сейчас?", "Новая версия", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    DirectoryInfo parent = FindFileInFolder(new DirectoryInfo(finalFolder), MainProgramExe);
                                    if (parent == null)
                                        return;

                                    finalFolder = parent.FullName;

                                    File.Copy(FileLocations.CONFIG_FILENAME, Path.Combine(finalFolder, FileLocations.CONFIG_FILENAME), true);

                                    String temp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                                    String updaterExe = Path.Combine(temp, UpdateProgramExe);
                                    if (File.Exists(Path.Combine(finalFolder, UpdateProgramExe)))
                                        File.Copy(Path.Combine(finalFolder, UpdateProgramExe), updaterExe, true);

                                    if (File.Exists(updaterExe))
                                    {
                                        //String args = "\"" + finalFolder + "\" \"" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\"";
                                        String args = String.Format("\"{0}\" \"{1}\"", finalFolder, Program.Info.Location);
                                        System.Diagnostics.Process.Start(updaterExe, args);
                                        Application.Exit();
                                    }
                                }

                            }
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                Logging.Log.Error("Failed during update.", exception);
            }
        }

        private static DirectoryInfo FindFileInFolder(DirectoryInfo path, String filename)
        {
            if (path.GetFiles(filename).Length > 0)
                return path;

            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                DirectoryInfo found = FindFileInFolder(dir, filename);
                if (found != null)
                    return found;
            }

            return null;
        }

        private static string GetMd5HashFromFile(string fileName)
        {
            String tmpFile = fileName + ".tmp";
            File.Copy(fileName, tmpFile, true);
            Byte[] retVal = null;

            using (FileStream file = new FileStream(tmpFile, FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                retVal = md5.ComputeHash(file);
                file.Close();
            }

            if (retVal != null)
            {
                StringBuilder s = new StringBuilder();
                foreach (Byte b in retVal)
                {
                    s.Append(b.ToString("x2").ToLower());
                }

                return s.ToString();
            }

            return null;
        }
    }
}
