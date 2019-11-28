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
		public bool Reportable => true;

		public string Description => "Count letters from file";

        public void Activate()
        {
            var text = TextFileFetcher.GetTextFileString();

            var total = Regex.Matches(text, @"[a-zA-Z]").Count;

            var vowels = Regex.Matches(text, @"[AEIOUaeiou]").Count;

            Writer.WriteMessege($"Text vowels count : {vowels} \nText consonants count: {total - vowels}");
        }
    }
}
