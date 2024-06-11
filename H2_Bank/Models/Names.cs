using System;

namespace H2_Bank.Models
{
	internal class Names
	{
		private readonly string[] _firstNames;
		private readonly string[] _lastNames;

		internal string GenerateName()
		{
			Random random = new Random();

			int firstName = random.Next(_firstNames.Length);
			int lastName = random.Next(_lastNames.Length);

			return $"{_firstNames[firstName]} {_lastNames[lastName]}";
		} 
	}
}
