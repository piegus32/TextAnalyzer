using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Commands
{
	class CreateReportCommand : ICommand
	{
		public string Description => "Create a report.";
		public bool Reportable => false;
		private static bool reportInProgress = false;
		public void Activate()
		{
			if (reportInProgress) return;
			reportInProgress = true;

			Writer.SetWritingMode(WriterMode.File);
			Writer.ClearReport();
			foreach (var command in Main.Commands)
			{
				if (!command.Reportable) continue;

				command.Activate();
				Writer.WriteMessege("\n");
			}
			reportInProgress = false;
			Writer.SetWritingMode(WriterMode.Console);
		}
	}
}
