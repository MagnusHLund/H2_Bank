using H2_Bank.Interfaces;
using System;

namespace H2_Bank.Models.Cards
{
	internal abstract class CreditCard : Card, ICreditCard
	{
		public int CreditLimit { get; set;  }

		internal CreditCard(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account) : base (cardHolderName, cardNumber, expirationDate, account)
		{
			CanHaveNegativeBalance = true;
		}
	}
}
