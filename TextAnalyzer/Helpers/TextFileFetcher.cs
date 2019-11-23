using System;
using System.Net;
using System.IO;

namespace TextAnalyzer
{
    static class TextFileFetcher
    {
        private const string FILE_NAME = "text.txt";
        private const string LINK = "https://s3.zylowski.net/public/input/3.txt";

        /// <summary>
        /// Get Text File from web client.
        /// </summary>
        /// <returns>Returns the string with entire text.</returns>
        public static string GetTextFileString()
        {
            if (File.Exists(FILE_NAME))
            {
                return File.ReadAllText(FILE_NAME);
            }

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(LINK, FILE_NAME);
                }
                catch(Exception)
                {
                    Console.Write("Could not fetch the file, try again.");
                    return null;
                }
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
        }
    }
}
