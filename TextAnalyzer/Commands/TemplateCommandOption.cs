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

		public string Description => "Download file from internet";

        public void Activate()
        {
            Writer.WriteMessege(TextFileFetcher.GetTextFileString());
        }
    }
}
