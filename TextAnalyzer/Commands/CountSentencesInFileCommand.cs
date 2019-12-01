using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Commands
{
    class CountSentencesInFileCommand : ICommand
    {
		public bool Reportable => true;

		List<char> endCharacters = new List<char>(){'?','.'};

        public string Description => "Count all sentences in file.";

        public void Activate()
        {
            CountSentences();
        }

        protected void CountSentences()
        {
            var text = TextFileFetcher.GetTextFileString();
            var sentences = text.Where((t, i) => endCharacters.Contains(t) && text[i + 1] == ' ' ||
                                                 endCharacters.Contains(t) && text[i + 1] == '\n'
            ).Count();
            Writer.WriteMessege($"Value of sentences in file is {sentences}");
        }
    }
}
