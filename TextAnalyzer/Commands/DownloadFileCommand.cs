﻿using System;
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

		public string Description => "Download file from internet";

        public void Activate()
        {
            Writer.WriteMessege("Would you like to download file from internet? (Y/N)");
            string option = Console.ReadLine();
            if (option.ToString().ToLower() == "y")
            {
                Writer.WriteMessege("Type URL of text file:");
                string url = Console.ReadLine();

                Writer.WriteMessege("Downloading file...");
                if (TextFileFetcher.DownloadFileFromURL(url))
                {
                    Writer.WriteMessege($"File {TextFileFetcher.FILE_NAME} downloaded correctly");
                }
                else
                {
                    Writer.WriteMessege("Cannot download a file");
                }
            }
            else
            {
                Writer.WriteMessege("Getting file from local disk");
                Writer.WriteMessege("Type text file name:");
                string url = Console.ReadLine();
                Writer.WriteMessege("You typed: " + url);

                TextFileFetcher.FILE_NAME = url;
            }
            Writer.WriteMessege(TextFileFetcher.GetTextFileString());
        }
    }
}