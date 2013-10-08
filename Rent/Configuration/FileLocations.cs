using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Rent.Configuration
{
    /// <summary>
    /// Data file locations resolution under Data subdirectory
    /// </summary>
    internal sealed class FileLocations
    {
        /// <summary>
        /// Gets the directory name of data directory,
        /// where all files changed by user should be stored
        /// </summary>
        private const string DATA_DIRECTORY = "Data";

        /// <summary>
        /// Gets the name of custom user options configuration file ("App.config").
        /// </summary>
        internal const string CONFIG_FILENAME = "App.config";

        internal static string LastUpdateCheck
        {
            get { return ("LastUpdateCheck.txt"); }
        }

        /// <summary>
        /// Gets the full file path to the required file or directory in application data directory.
        /// </summary>
        /// <param name="relativePath">The relative path to the file from data directory.</param>
        internal static string GetFullPath(string relativePath)
        {
            string root = GetDataRootDirectoryFullPath();
            return Path.Combine(root, relativePath);
        }

        private static string GetDataRootDirectoryFullPath()
        {
            string root = Path.Combine(Program.Info.Location, DATA_DIRECTORY);
     
            EnsureDataDirectory(root);
            return root;
        }

        private static void EnsureDataDirectory(string root)
        {
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
        }
    }
}
