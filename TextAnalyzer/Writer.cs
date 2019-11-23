using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    enum WriterMode
    {
        File,
        Console
    }

    class Writer
    {
        private const string REPORT_FILE_PATH = "report.txt";

        private static WriterMode mode = WriterMode.Console;

        public static void WriteMessege(string messege)
        {
            if(mode == WriterMode.Console)
            {
                Console.WriteLine(messege);
            }
            else if(mode == WriterMode.File)
            {
                if(!File.Exists(REPORT_FILE_PATH))
                {
                    File.Create(REPORT_FILE_PATH);
                }

                File.WriteAllText(REPORT_FILE_PATH, messege);
            }
        }

        public static void WriteMessege(string messege, params object[] arg)
        {
            Console.WriteLine(messege, arg);
        }

        public static void GetMessege()
        {
            Console.ReadLine();
        }

        List<char> stoppers = new List<char>() { '.', '!', '?' };

        private int Check()
        {
            int counter = 0;
            string text = "badfads";

            bool wasPreviousEndChar = false;

            foreach (var word in text)
            {
                if(wasPreviousEndChar == true)
                {
                    if (word == ' ')
                    {
                        counter++;
                        wasPreviousEndChar = false;
                        continue;
                    }
                }

                if(stoppers.Contains(word))
                {
                    wasPreviousEndChar = true;
                }
            }

            return counter;
        }
    }
}
