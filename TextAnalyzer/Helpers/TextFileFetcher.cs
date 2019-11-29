using System;
using System.Net;
using System.IO;

namespace TextAnalyzer
{
    static class TextFileFetcher
    {
        private const string REPORT_FILE = "report.txt";
        private const string LINK = "https://s3.zylowski.net/public/input/3.txt";
        private static string FILE_NAME;
        public static string Link => LINK;
        public static string FileName
        {
            get => FILE_NAME;
            set => FILE_NAME = value;
        }


        public static bool DownloadFileFromURL(string URL, string fileName = null)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(URL, fileName != null ? fileName: Path.GetFileName(URL) );
                    FILE_NAME = fileName;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Get Text File from web client.
        /// </summary>
        /// <returns>Returns the string with entire text.</returns>
        public static string GetTextFileString(string filename = null)
        {
            if (File.Exists(FILE_NAME))
            {
                return File.ReadAllText(FILE_NAME);
            }

            if (!DownloadFileFromURL(LINK)) { 
                Console.Write("ERROR: Could not fetch the file.");
            }

            if (File.Exists(FILE_NAME))
            {
                return File.ReadAllText(FILE_NAME);
            }
            return null;
        }

        public static void CleanupFileIfPossible()
        {
            if (File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);
            }

            if (File.Exists(REPORT_FILE))
            {
                File.Delete(REPORT_FILE);
            }
        }

        public static bool CheckIfFileExists()
        {
            return File.Exists(FILE_NAME);
        }
    }
}
