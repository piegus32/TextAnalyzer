using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Writer
    {
        public static void WriteMessege(string messege)
        {
            Console.WriteLine(messege);
        }

        public static void WriteMessege(string messege, params object[] arg)
        {
            Console.WriteLine(messege, arg);
        }

        public static void GetMessege()
        {
            Console.ReadLine();
        }
    }
}
