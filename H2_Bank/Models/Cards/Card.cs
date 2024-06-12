using System;

namespace H2_Bank.Models.Cards
{
	internal abstract class Card
	{
		protected string cardHolderName;
		protected string cardNumber;
		protected DateTime? expirationDate;

		internal protected bool CanPayInternational { get; set;  }
		internal protected bool CanPayOnline { get; set; }
		internal protected bool CanHaveNegativeBalance { get; set; }
		internal protected Account Account { get; }
		protected byte MinimumAgeOfOwnership { get; set; }

		internal Card(string cardHolderName, string cardNumber, DateTime? expirationDate, Account account) 
		{
			this.cardHolderName = cardHolderName;
			this.cardNumber = cardHolderName;
			this.expirationDate = expirationDate;
			Account = account;
		}

		/// <summary>
		/// This method reduces the account balance, from a purchase
		/// </summary>
		/// <param name="amount"></param>
		internal void SpendMoney(double amount)
		{
			Account.Balance -= amount;
		}

		/// <summary>
		/// This overrides the ToString method, to return a specific string, containing values of the card.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"Card type: {this.GetType().Name} \n" +
				$"Card number: {cardNumber}" +
				$"Card owner: {cardHolderName}";
		}
	}
}
