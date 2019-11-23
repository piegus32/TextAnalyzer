using System;
using System.IO;

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
			switch (mode)
			{
				case WriterMode.Console:
				    Console.WriteLine(messege);
					break;
				case WriterMode.File:
					File.AppendAllText(REPORT_FILE_PATH, messege);
					break;
			}
		}

        public static void WriteMessege(string messege, params object[] arg)
        {
            //Console.WriteLine(messege, arg);
			switch (mode)
			{
				case WriterMode.Console:
					Console.WriteLine(messege, arg);
					break;
				case WriterMode.File:
					File.AppendAllText(REPORT_FILE_PATH, String.Format(messege, arg));
					break;
			}
		}

        public static void GetMessege()
        {
            Console.ReadLine();
        }

		public static void SetWritingMode(WriterMode newMode)
		{
			mode = newMode;
		}

		public static void ClearReport()
		{
			if (File.Exists(REPORT_FILE_PATH))
			{
				File.Delete(REPORT_FILE_PATH);
			}
		}
	}
}
