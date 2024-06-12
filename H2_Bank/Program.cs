using H2_Bank.Controllers;

namespace H2_Bank
{
	internal class Program
	{
		/// <summary>
		/// Entry point for the application.
		/// Calls the MainController class' Main method.
		/// </summary>
		static void Main()
		{
			new MainController().Main();
		}
	}
}
