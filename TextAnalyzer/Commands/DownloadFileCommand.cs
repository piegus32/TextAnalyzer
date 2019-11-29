using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class DownloadFileCommand : ICommand
    {
        public bool Reportable => false;

        public string Description => "Download file from internet/Load from disc.";

        public void Activate()
        {
            Writer.WriteMessege("Would you like to download file from internet? (Y/N)");
            string option = Console.ReadLine();
            if (option.ToString().ToLower() == "y")
            {
                Writer.WriteMessege("Type URL of text file (type 'default' for default file):");
                string url = Console.ReadLine();

                if (url.ToLower() == "default")
                {
                    url = TextFileFetcher.Link;
                }

                Console.Clear();

                Writer.WriteMessege("Choose file name:");
                string name = Console.ReadLine();

                Writer.WriteMessege("Downloading file...");
                if (TextFileFetcher.DownloadFileFromURL(url, name))
                {
                    Writer.WriteMessege($"File {TextFileFetcher.FileName} downloaded correctly");
                }
                else
                {
                    Writer.WriteMessege("Cannot download a file");
                }
            }
            else
            {
                Console.Clear();

                Writer.WriteMessege("Getting file from local disk");
                Writer.WriteMessege("Type text file name:");
                string url = Console.ReadLine();
                Writer.WriteMessege("You typed: " + url);

                TextFileFetcher.FileName = url;
                if (!TextFileFetcher.CheckIfFileExists())
                {
                    Writer.WriteMessege("\nThe file does not exist!");
                }
            }

            Writer.WriteMessege(TextFileFetcher.GetTextFileString());
        }
    }
}
