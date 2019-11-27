using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class TemplateCommandOption : ICommand
    {
		public bool Reportable => false;

		public string Description => "Template option, writes the text file in the console";

        public void Activate()
        {
            Writer.WriteMessege(TextFileFetcher.GetTextFileString());
        }
    }
}
