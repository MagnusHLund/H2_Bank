using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using H2_Bank.Models.Cards;
using H2_Bank.Models.Cards.Credit_cards;
using H2_Bank.Models.Cards.Debit_cards;

namespace H2_Bank.Models
{
	internal class Account
	{
		internal List<Card> Cards { get; set; }

		internal string AccountOwner { get; set; }

		internal Account(string accountOwner) 
		{
			AccountOwner = accountOwner;
		}

		internal void AddCardToAccount() 
		{
			Random random = new Random();
			const byte totalCardTypes = 5;
			byte randomValue = (byte)random.Next(totalCardTypes);

			switch (randomValue)
			{
				case 0:
					Cards.Add(new Mastercard());
					break;
				case 1:
					Cards.Add(new Maestro());
					break;
				case 2:
					Cards.Add(new VisaDankort());
					break;
				case 3:
					Cards.Add(new VisaElectron());
					break;
				case 4:
					Cards.Add(new YouthCard());
					break;
				default:
					// Console log an error
					break;
			}
		}
	}
}
