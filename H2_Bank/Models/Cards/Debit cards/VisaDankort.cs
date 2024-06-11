using H2_Bank.Interfaces;
using System;

namespace H2_Bank.Models.Cards.Debit_cards
{
	internal class VisaDankort : DebitCard, ICreditCard
	{
		public int CreditLimit { get; set; }

		internal VisaDankort(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account)
			: base(cardHolderName, cardNumber, expirationDate, account)
		{
			MinimumAgeOfOwnership = 18;
			CanPayOnline = true;
			CanPayInternational = true;
			CanHaveNegativeBalance = true;
			CreditLimit = 20000;
		}
	}
}
