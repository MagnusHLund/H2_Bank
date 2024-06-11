using System;

namespace H2_Bank.Models.Factories
{
	internal class ClientFactory
	{
		private static readonly string[] _firstNames =
		{
			"James", "John", "Robert", "Michael", "William",
			"David", "Richard", "Joseph", "Thomas", "Charles",
			"Mary", "Jennifer", "Linda", "Patricia", "Elizabeth"
		};

		private static readonly string[] _lastNames =
		{
			"Smith", "Johnson", "Williams", "Brown", "Jones",
			"Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
			"Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson"
		};

		private Random _random = new Random();

		internal Client CreateClient()
		{
			string clientName = GenerateName();
			byte clientAge = GenerateAge();

			Client client = new Client(clientName, clientAge);

			DepositMoney(client);

			return client;
		}

		private string GenerateName()
		{
			byte firstNameValue = (byte)_random.Next(_firstNames.Length);
			byte LastNameValue = (byte)_random.Next(_lastNames.Length);

			string firstName = _firstNames[firstNameValue];
			string lastName = _lastNames[LastNameValue];

			return $"{firstName} {lastName}";
		}

		private byte GenerateAge()
		{
			return (byte)_random.Next(15, 100);
		}

		private void DepositMoney(Client client)
		{
			client.account.Balance = _random.Next(1000, 10000);
		}
	}
}
