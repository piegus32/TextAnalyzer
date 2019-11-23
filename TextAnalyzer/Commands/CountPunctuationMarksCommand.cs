using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Commands
{
	class CountPunctuationMarksCommand : ICommand
	{
		public string Description => "Count all punctuation marks";

		public bool Reportable => true;

		List<char> punctuationMarksList = new List<char>() { '.', ',', '?', '!', ';' };

		public void Activate()
		{
			string text = TextFileFetcher.GetTextFileString();
			int counter = 0;
			foreach (var letter in text)
			{
				if (punctuationMarksList.Contains(letter))
				{
					counter++;
				}
			}
			Writer.WriteMessege($"Number of punctuation marks: {counter}");
		}
	}
}
