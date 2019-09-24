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
        int getResponse;

        //Delegate WriteMessege.
        Action<string> writeMessege = Writer.WriteMessege;

        public void StartMenu()
        {
            writeMessege("1.Type 1");
            writeMessege("2.Type 2");
            writeMessege("3.Type 3");
            writeMessege("4.Type 4");
            writeMessege("Took: ");

            //Try-catch exception before switching option.
            //If getRespone different than int32 , return to method.
            try
            {
                getResponse = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                StartMenu();
            }
            

            switch (getResponse)
            {
                case 1:
                    writeMessege("First Option");
                    StartMenu();
                    break;
                case 2:
                    writeMessege("Second Option");
                    StartMenu();
                    break;
                case 3:
                    writeMessege("Third Option");
                    StartMenu();
                    break;
                case 4:
                    writeMessege("Exiting Program...");
                    Thread.Sleep(2000);
                    return;
                default:
                    StartMenu();
                    break;
            }
        }
    }
}
