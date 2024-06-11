using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Bank.Views
{
	internal class View
	{
		internal void Message(string message)
		{
			Console.WriteLine(message);
		}

		internal void Error(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		internal void Success(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		internal void Pause()
		{
			Console.ReadLine();
		}
	}
}
