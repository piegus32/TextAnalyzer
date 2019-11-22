using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class LettersCountReportCommand : ICommand
    {
        public string Description => "Count letters from file";

        public void Activate()
        {
            String text = TextFileFetcher.GetTextFileString();
            /**
             * Sign Count
             * Writer.WriteMessege("Text sign count: {0}", text.Length.ToString());
             */
            Writer.WriteMessege("Text letter count [a-Z]: {0}\n", Regex.Replace(text, @"(\W)+", "").Length.ToString());
        }
    }
}
