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
            // TODO: Send packet with headers like in fiddler to UpdateCheck.aspx

           // RssFeed feed = RssFeed.Read(RSS_URL);
            //if (feed != null)
            //{
            //    RssItem newvestRssItem = SelectNewvestRssRssItem(feed, buildDate);
               // if (newvestRssItem != null)
                //    return new ReleaseInfo(newvestRssItem.PubDate, newvestRssItem.Title);
            //}

            return ReleaseInfo.NotAvailable;
        }

        private static void DownloadLatestRelease()
        {
            const string MainProgramExe = "Rent.exe";
            const string UpdateProgramExe = "RentUpdater.exe";

            try
            {
                String url = Settings.Default.UpdateSource;
                String contents = Web.HTTPAsString(url);

                if (!String.IsNullOrEmpty(contents))
                {
                    RentUpdates updates = (RentUpdates)Serialize.DeSerializeXML(contents, typeof(RentUpdates));
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
