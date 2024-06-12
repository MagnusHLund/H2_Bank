using System;

namespace H2_Bank.Views
{
	/// <summary>
	/// This class could have been summarized to one method, with an optional console.color parameter.
	/// I felt that it was more convinient to have these methods split into 3. 
	/// Imagine this code being used for a larger codebase. 
	/// Having these methods split up would lead to an easy to use standard for outputting to the console.
	/// </summary>
	internal class View
	{
		/// <summary>
		/// Outputs a custom message based on parameter.
		/// </summary>
		/// <param name="message">String parameter, which determines the message which is output</param>
		internal void Message(string message)
		{
			Console.WriteLine(message);
		}

		/// <summary>
		/// Outputs a custom message based on parameter.
		/// The message is output with red text.
		/// </summary>
		/// <param name="message">String parameter, which determines the message which is output</param>
		internal void Error(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		/// <summary>
		/// Outputs a custom message based on parameter.
		/// The message is output with green text.
		/// </summary>
		/// <param name="message">String parameter, which determines the message which is output</param>
		internal void Success(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		/// <summary>
		/// This method pauses the program, until the user clicks enter.
		/// </summary>
		internal void Pause()
		{
			Console.ReadLine();
		}
	}
}
