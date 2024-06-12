using H2_Bank.Models.Cards;
using H2_Bank.Views;
using System;

namespace H2_Bank.Controllers
{
	internal class PurchaseController
	{
		private Random _random = new Random();
		private View _view = new View();

		/// <summary>
		/// This method attempts to perform a purchase, if the card allows international transactions.
		/// </summary>
		/// <param name="card">Card to perform payment</param>
		internal void InternationalPurchase(Card card)
		{
			_view.Message("Attempting international purchase...");

			if (card.CanPayInternational)
			{
				Purchase(card);
			} 
			else
			{
				_view.Error("Purchase failed because the card is not allowed to perform international purchases");
			}
		}

		/// <summary>
		/// This method attempts to perform a purchase, if the card allows online transactions.
		/// </summary>
		/// <param name="card">Card to perform payment</param>
		internal void OnlinePurchase(Card card)
		{
			_view.Message("Attempting online purchase...");

			if (card.CanPayOnline)
			{
				Purchase(card);
			} 
			else
			{
				_view.Error("Purchase failed because the card is not allowed to perform online purchases");
			}
		}

		/// <summary>
		/// This method attempts to perform a purchase.
		/// </summary>
		/// <param name="card">Card to perform payment</param>
		internal void LocalPurchase(Card card)
		{
			Purchase(card);
		}

		/// <summary>
		/// This method checks if the card has enough money to perform a payment.
		/// </summary>
		/// <param name="card">Card to pay with</param>
		/// <param name="price">Total price of the purchase</param>
		/// <returns></returns>
		private bool SufficientFunds(Card card, int price)
		{
			if(card.CanHaveNegativeBalance)
			{
				return true;
			}

			if(card.Account.Balance >= price)
			{
				return true;
			} 
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Comes up with a random price tag.
		/// Spends money from the account if it has sufficient funds.
		/// </summary>
		/// <param name="card"></param>
		private void Purchase(Card card)
		{
			int price = _random.Next(250, 1000);

			if (SufficientFunds(card, price))
			{
				card.SpendMoney(price);
				_view.Success("Successful purchase!");
			}
			else
			{
				_view.Error("Could not purchase, due to insufficient funds!");
			}
		}
	}
}
