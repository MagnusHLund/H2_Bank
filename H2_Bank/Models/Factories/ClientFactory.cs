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

		/// <summary>
		/// This is the entry point for the factory.
		/// It calls the other methods within the class, to generate a client.
		/// It then deposits a random amount of money into the client's account. 
		/// </summary>
		/// <returns>It returns a ready to use client object</returns>
		internal Client CreateClient()
		{
			string clientName = GenerateName();
			byte clientAge = GenerateAge();

			Client client = new Client(clientName, clientAge);

			DepositMoney(client);

			return client;
		}

		/// <summary>
		/// Generates a random name for the client.
		/// </summary>
		/// <returns></returns>
		private string GenerateName()
		{
			byte firstNameValue = (byte)_random.Next(_firstNames.Length);
			byte LastNameValue = (byte)_random.Next(_lastNames.Length);

			string firstName = _firstNames[firstNameValue];
			string lastName = _lastNames[LastNameValue];

			return $"{firstName} {lastName}";
		}

		// Generates a random age for the client, between 15 and 99.
		private byte GenerateAge()
		{
			return (byte)_random.Next(15, 100);
		}

		/// <summary>
		/// Deposits a random amount of money within the clients account.
		/// </summary>
		/// <param name="client"></param>
		private void DepositMoney(Client client)
		{
			client.Account.Balance = _random.Next(1000, 10000);
		}
	}
}
