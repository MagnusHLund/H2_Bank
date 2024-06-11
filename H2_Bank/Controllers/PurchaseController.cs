using H2_Bank.Models.Cards;
using H2_Bank.Views;
using System;

namespace H2_Bank.Controllers
{
	internal class PurchaseController
	{
		private Random _random = new Random();
		private View _view = new View();

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

		internal void LocalPurchase(Card card)
		{
			Purchase(card);
		}

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
