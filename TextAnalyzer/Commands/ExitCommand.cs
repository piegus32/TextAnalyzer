using System;
using System.Threading;
using System.IO;

namespace TextAnalyzer
{
    class ExitCommand : ICommand
    {
		public bool Reportable => false;

		public string Description => "Exit Program";
     
        /// <summary>
        /// Cleanup the code and exit the program.
        /// </summary>
        public void Activate()
        {
            TextFileFetcher.CleanupFileIfPossible();

            Writer.WriteMessege("Exiting Program...");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
