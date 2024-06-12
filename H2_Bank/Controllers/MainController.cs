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
		private View _view = new View();
		private List<Client> _clients = new List<Client>();

		/// <summary>
		/// Entry point for the MainController.
		/// It calls the other methods within the class and pauses the program, using the View class.
		/// </summary>
		internal void Main()
		{
			CreateClients();
			CreateCards();
			ShowCardInfo();
			SimulatePurchase();
			_view.Pause();
		}

		/// <summary>
		/// This method uses the ClientFactory class to create 10 new clients.
		/// Each client then gets added to the _clients list.
		/// </summary>
		private void CreateClients()
		{
			ClientFactory clientFactory = new ClientFactory();

			for (byte i = 0; i < 10; i++)
			{
				_clients.Add(clientFactory.CreateClient());
			}
		}

		/// <summary>
		/// This method adds 1 or 2 cards to a clients account.
		/// Each client gets looped through.
		/// </summary>
		private void CreateCards()
		{
			Random random = new Random();

			foreach (Client client in _clients)
			{
				int TotalCards = random.Next(1, 3);

				for (int i = 0;i < TotalCards; i++)
				{
					client.Account.AddCardToAccount();
				}
			}
		}

		/// <summary>
		/// This method shows each card information, for each of the clients.
		/// </summary>
		private void ShowCardInfo()
		{
			foreach (Client client in _clients)
			{
				List<Card> clientCards = client.Account.Cards;

				foreach (Card card in client.Account.Cards)
				{
					_view.Message(card.ToString());
				}
			}
		}

		/// <summary>
		/// This method creates some test purchases.
		/// It uses the PurchaseController to create 3 purchase types, for each card.
		/// These types are LocalPurchase, OnlinePurchase, InternationalPurchase.
		/// </summary>
		private void SimulatePurchase()
		{
			PurchaseController purchaseController = new PurchaseController();

			foreach (Client client in _clients)
			{
				List<Card> clientCards = client.Account.Cards;

				_view.Message($"Attempting purchase simulations with {client.Name}'s card(s)");

				foreach(Card card in client.Account.Cards)
				{
					purchaseController.LocalPurchase(card);
					purchaseController.OnlinePurchase(card);
					purchaseController.InternationalPurchase(card);
				}
			}
		}
	}
}
