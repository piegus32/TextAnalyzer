using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Commands
{
    class CountSentencesInFileCommand : ICommand
    {

        List<char> endCharacters = new List<char>(){'?','!','.'};

        public string Description => "Count all sentences in file.";

        string text = TextFileFetcher.GetTextFileString();

        public void Activate()
        {
            CountSentences();
            throw new NotImplementedException();
        }

        protected void CountSentences()
        {
            var sentences = text.Where((t, i) => endCharacters.Contains(t) && text[i + 1] == ' ' ||
                                                 endCharacters.Contains(t) && text[i + 1] == '\n'
            ).Count();
            Writer.WriteMessege($"Value of sentences in file is {sentences}");
        }
    }
}
