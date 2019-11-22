using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class CountEveryLetterReportCommand : ICommand
    {
        public string Description => "Generate report for each letter from file";

        public void Activate()
        {
            List<LetterOccurrenceModel> letterOccurrenceList = new List<LetterOccurrenceModel>();

            String text = Regex.Replace(TextFileFetcher.GetTextFileString(), @"(\W|\d|_)+", "");

            foreach (char letter in text)
            {
                LetterOccurrenceModel letterOccurrenceModel = letterOccurrenceList.Find(item => item.letter == letter);
                if (letterOccurrenceModel == null)
                {
                    letterOccurrenceList.Add(new LetterOccurrenceModel(letter, 1));
                }
                else
                {
                    letterOccurrenceModel.Increase();
                }
            }
            Writer.WriteMessege("Report of letter occurrence in text");

            foreach (LetterOccurrenceModel letterOccurrenceModel in letterOccurrenceList.OrderBy(o => o.letter).ToList())
            {
                Writer.WriteMessege("Letter {0} : occurs {1} time(s)", letterOccurrenceModel.letter, letterOccurrenceModel.count);
            }

            Writer.WriteMessege("");
        }
    }
}
