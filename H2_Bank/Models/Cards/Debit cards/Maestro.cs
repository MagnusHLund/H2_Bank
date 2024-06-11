using System;

namespace H2_Bank.Models.Cards.Debit_cards
{
	internal class Maestro : DebitCard
	{
		internal Maestro(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account) : base(cardHolderName, cardNumber, expirationDate, account)
		{
			MinimumAgeOfOwnership = 18;
			CanPayOnline = true;
			CanPayInternational = true;
		}
	}
}
