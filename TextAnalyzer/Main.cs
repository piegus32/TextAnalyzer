using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Commands;

namespace TextAnalyzer
{
    class Main
    {
        protected readonly Action<string> writeMessege = Writer.WriteMessege;
        protected static readonly List<ICommand> optionsList = new List<ICommand>();
	    public static List<ICommand> Commands => optionsList;

        public Main()
        {
            optionsList.Add(new DownloadFileCommand());
            optionsList.Add(new LettersCountReportCommand());
            optionsList.Add(new CountWordsCommand());
            optionsList.Add(new CountPunctuationMarksCommand());
            optionsList.Add(new CountEveryLetterReportCommand());
            optionsList.Add(new CountSentencesInFileCommand());
            optionsList.Add(new CreateReportCommand());
            optionsList.Add(new ExitCommand());
          
		    StartMenu();
        }

        public void StartMenu()
        {
            if (TextFileFetcher.CheckIfFileExists())
            {
                writeMessege("Opened File:" + TextFileFetcher.FileName);
                WriteOptionsAndTakeChoice(optionsList);
            }
            else
            {
                writeMessege("No File Loaded");
                WriteOptionsAndTakeChoice(GetOnFileNotDownloadedOptions());
            }
            

        }

        private List<ICommand> GetOnFileNotDownloadedOptions()
        {
            var downloadIndex = optionsList.FindIndex((e) => e.GetType() == typeof(DownloadFileCommand));
            var exitIndex = optionsList.FindIndex((e) => e.GetType() == typeof(ExitCommand));

            List<ICommand> options = new List<ICommand>{ optionsList[downloadIndex], optionsList[exitIndex] };
            return options;
        }

        private void WriteOptionsAndTakeChoice(List<ICommand> viableOptions)
        {
            int i = 1;
            foreach (ICommand command in viableOptions)
            {
                writeMessege($"{i++}. {command.Description}");
            }
            writeMessege("Took: ");

            //Try-catch exception before choosing option.
            //If the read int is not a valid index in options list, retry
            try
            {
                int response = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                viableOptions[response - 1].Activate();
                StartMenu();
            }
            catch (Exception)
            {
                StartMenu();
            }
        }
    }
}
