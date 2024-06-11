using System;

namespace H2_Bank.Models.Cards
{
	internal abstract class DebitCard : Card
	{
		internal DebitCard(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account) : base(cardHolderName, cardNumber, expirationDate, account)
		{
			CanHaveNegativeBalance = false;
		}
	}
}
