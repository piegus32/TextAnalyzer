using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Main
    {
        //Delegate WriteMessege.
        Action<string> writeMessege = Writer.WriteMessege;
        List<ICommand> optionsList = new List<ICommand>();

        public Main()
        {
            optionsList.Add(new TemplateCommandOption());
            optionsList.Add(new ExitCommand());

            StartMenu();
        }

        public void StartMenu()
        {
            int i = 1;
            foreach (var command in optionsList)
            {
                writeMessege($"{i++}. {command.Description}");
            }
            writeMessege("Took: ");

            //Try-catch exception before choosing option.
            //If the read int is not a valid index in options list, retry
            try
            {
                int getRespone = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                optionsList[getRespone- 1].Activate();
                StartMenu();
            }
            catch (Exception)
            {
                StartMenu();
            }
        }
    }
}
