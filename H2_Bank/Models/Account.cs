using System.Collections.Generic;
using H2_Bank.Models.Cards;
using H2_Bank.Models.Factories;

namespace H2_Bank.Models
{
	internal class Account
	{
		internal List<Card> Cards { get; set; }

		internal Client AccountOwner { get; set; }
		internal string AccountNumber { get; set; }
		internal double Balance { get; set; }

		internal Account(Client accountOwner) 
		{
			AccountOwner = accountOwner;

			Cards = new List<Card>();
		}

		internal void AddCardToAccount() 
		{
			CardFactory cardFactory = new CardFactory();
			Card card = cardFactory.CreateCard(this);

			Cards.Add(card);
		}
	}
}