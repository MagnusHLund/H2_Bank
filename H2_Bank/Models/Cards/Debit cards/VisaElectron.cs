using System;

namespace H2_Bank.Models.Cards.Debit_cards
{
	internal class VisaElectron : DebitCard
	{
		internal VisaElectron(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account)
			: base(cardHolderName, cardNumber, expirationDate, account)
		{
			minimumAgeOfOwner = 15;
			CanPayOnline = true;
			CanPayInternational = true;
		}
	}
}
