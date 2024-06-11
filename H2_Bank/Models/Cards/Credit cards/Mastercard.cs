using System;

namespace H2_Bank.Models.Cards.Credit_cards
{
	internal class Mastercard : CreditCard
	{
		private const double _dailyWithdrawlLimit = 5000;
		private const double _MonthlyWithdrawlLimit = 40000;

		internal double RemainingDailyWithdrawlLimit { get; private set; }
		internal double RemainingMonthlyWithdrawalLimit { get; private set; }

		internal Mastercard(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account) : base(cardHolderName, cardNumber, expirationDate, account)
		{
			minimumAgeOfOwner = 18;
			CanPayOnline = true;
			CanPayInternational = true;
			CreditLimit = 40000;
		}
	}
}
