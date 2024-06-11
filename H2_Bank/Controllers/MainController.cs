using H2_Bank.Models;
using H2_Bank.Models.Cards;
using H2_Bank.Models.Factories;
using H2_Bank.Views;
using System;
using System.Collections.Generic;

namespace H2_Bank.Controllers
{
	internal class MainController
	{
		private View view = new View();

		private List<Client> _clients = new List<Client>();

		internal void Main()
		{
			CreateClients();
			CreateCards();
			ShowCardInfo();
			SimulatePurchase();
			view.Pause();
		}

		private void CreateClients()
		{
			ClientFactory clientFactory = new ClientFactory();

			for (byte i = 0; i < 10; i++)
			{
				_clients.Add(clientFactory.CreateClient());
			}
		}

		private void CreateCards()
		{
			Random random = new Random();

			foreach (Client client in _clients)
			{
				int TotalCards = random.Next(1, 3);

				for (int i = 0;i < TotalCards; i++)
				{
					client.account.AddCardToAccount();
				}
			}
		}

		private void ShowCardInfo()
		{
			foreach (Client client in _clients)
			{
				List<Card> clientCards = client.account.Cards;

				foreach (Card card in client.account.Cards)
				{
					view.Message(card.ToString());
				}
			}
		}

		private void SimulatePurchase()
		{
			PurchaseController purchaseController = new PurchaseController();

			foreach (Client client in _clients)
			{
				List<Card> clientCards = client.account.Cards;

				view.Message($"Attempting purchase simulations with {client.Name}'s card(s)");

				foreach(Card card in client.account.Cards)
				{
					purchaseController.LocalPurchase(card);
					purchaseController.OnlinePurchase(card);
					purchaseController.InternationalPurchase(card);
				}
			}
		}
	}
}
