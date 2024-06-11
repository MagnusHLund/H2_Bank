using System;

namespace H2_Bank.Models.Cards.Debit_cards
{
	internal class YouthCard : DebitCard
	{
		internal YouthCard(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account)
			: base(cardHolderName, cardNumber, expirationDate, account)
		{
			minimumAgeOfOwner = 18;
			CanPayOnline = false;
			CanPayInternational = false;
		}
	}
}
