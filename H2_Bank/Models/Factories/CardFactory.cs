using H2_Bank.Models.Cards;
using H2_Bank.Models.Cards.Credit_cards;
using H2_Bank.Models.Cards.Debit_cards;
using H2_Bank.Models.Enums;
using System;
using System.Collections.Generic;

namespace H2_Bank.Models.Factories
{
	internal class CardFactory
	{
		// This dictionary has the maximum expiration date, for each card type.
		private static readonly Dictionary<CardType, DateTime?> _expirationDate = new Dictionary<CardType, DateTime?>()
		{
			{ CardType.YouthCard, null },
			{ CardType.Maestro, DateTime.Today.AddYears(5).AddMonths(8) },
			{ CardType.VisaElectron, DateTime.Today.AddYears(5) },
			{ CardType.VisaDankort, DateTime.Today.AddYears(5) },
			{ CardType.Mastercard, DateTime.Today.AddYears(5) }
		};

		// This dictionary has the card prefixes, for each card type.
		private static readonly Dictionary<CardType, int[]> _cardPrefixes = new Dictionary<CardType, int[]>()
		{
			{ CardType.YouthCard, new int[] { 2400 } },
			{ CardType.Maestro, new int[] { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 }},
			{ CardType.VisaElectron, new int[] { 4026, 417500, 4508, 4844, 4913, 4917 } },
			{ CardType.VisaDankort, new int[] { 4 } },
			{ CardType.Mastercard, new int[] { 51, 52, 53, 54, 55 } }
		};

		private static readonly Random _random = new Random();

		/// <summary>
		/// Creates a card for the given account.
		/// If the account owner is under 18, it randomly selects between YouthCard and VisaElectron.
		/// If the account owner is 18 or older, it randomly selects between Maestro, VisaElectron, VisaDankort, and Mastercard.
		/// </summary>
		/// <param name="account">The account for which the card is being created.</param>
		/// <returns>A card object associated with the given account.</returns>
		internal Card CreateCard(Account account)
		{
			CardType cardType;

			// If the account owner is under 18, randomly choose between YouthCard and VisaElectron
			if (account.AccountOwner.Age < 18)
			{
				cardType = _random.Next(2) == 0 ? CardType.YouthCard : CardType.VisaElectron;
			}
			else
			{
				// If the account owner is 18 or older, randomly choose between all card types except YouthCard
				CardType[] adultCardTypes = { CardType.Maestro, CardType.VisaElectron, CardType.VisaDankort, CardType.Mastercard };
				cardType = adultCardTypes[_random.Next(adultCardTypes.Length)];
			}

			string cardNumber = GenerateCardNumber(cardType);
			DateTime? expirationDate = GenerateExpirationDate(cardType);
			string cvv = GenerateCvvNumber();
			string cardHolderName = account.AccountOwner.Name;

			Card card = MapCardType(cardType, cardNumber, expirationDate, cvv, cardHolderName, account);
			return card;
		}

		/// <summary>
		/// Maps the card type to the corresponding card class and creates an instance of that class.
		/// </summary>
		/// <param name="cardType">The type of the card.</param>
		/// <param name="cardNumber">The card number.</param>
		/// <param name="expirationDate">The card's expiration date.</param>
		/// <param name="cvv">The CVV number.</param>
		/// <param name="cardHolderName">The name of the cardholder.</param>
		/// <param name="account">The associated account.</param>
		/// <returns>An instance of the specific card type.</returns>
		private Card MapCardType(CardType cardType, string cardNumber, DateTime? expirationDate, string cvv, string cardHolderName, Account account)
		{
			switch (cardType)
			{
				case CardType.VisaDankort:
					return new VisaDankort(cardHolderName, cardNumber,expirationDate, account);
				case CardType.YouthCard:
					return new YouthCard(cardHolderName, cardNumber, expirationDate, account);
				case CardType.VisaElectron:
					return new VisaElectron(cardHolderName, cardNumber, expirationDate, account);
				case CardType.Mastercard:
					return new Mastercard(cardHolderName, cardNumber, expirationDate, account);
				case CardType.Maestro:
					return new Maestro(cardHolderName, cardNumber, expirationDate, account);
				default:
					throw new NotImplementedException();
			}
		}
		/// <summary>
		/// Generates a valid card number for the specified card type.
		/// The card number is generated using the Luhn algorithm.
		/// </summary>
		/// <param name="cardType">The type of the card.</param>
		/// <returns>A valid card number.</returns>
		private string GenerateCardNumber(CardType cardType)
		{
			int[] cardPrefixes = _cardPrefixes[cardType];
			int randomPrefixValue = _random.Next(cardPrefixes.Length);
			string prefix = cardPrefixes[randomPrefixValue].ToString();

			byte totalCardNumberLength = 16;

			if(cardType == CardType.Maestro)
			{
				totalCardNumberLength = 19;
			}

			int length = totalCardNumberLength - prefix.Length;

			string cardNumber = prefix;
			for (int i = 0; i < length - 1; i++)
			{
				cardNumber += _random.Next(0, 9).ToString();
			}

			int checkDigit = GetCheckDigit(cardNumber);
			cardNumber += checkDigit;

			return cardNumber;
		}

		/// <summary>
		/// Calculates the check digit for a card number using the Luhn algorithm.
		/// </summary>
		/// <param name="cardNumber">The partial card number without the check digit.</param>
		/// <returns>The calculated check digit.</returns>
		private int GetCheckDigit(string cardNumber)
		{
			int totalSum = 0;

			for (int index = 0; index < cardNumber.Length; index++)
			{
				int digit = int.Parse(cardNumber[index].ToString());

				if (index % 2 == 0)
				{
					digit *= 2;

					if (digit > 9)
					{
						digit -= 9;
					}
				}

				totalSum += digit;
			}

			int modulus = totalSum % 10;

			return modulus == 0 ? 0 : 10 - modulus;
		}

		/// <summary>
		/// Generates a random expiration date for the card based on the card type's maximum expiration date.
		/// </summary>
		/// <param name="cardType">The type of the card.</param>
		/// <returns>The generated expiration date, or null if no expiration date is set for the card type.</returns>
		private DateTime? GenerateExpirationDate(CardType cardType)
		{
			DateTime today = DateTime.Today;
			DateTime? maxDate = _expirationDate[cardType];

			if (maxDate == null)
			{
				return null;
			}

			int dayRange = (maxDate.Value - today).Days;
			int randomDay = _random.Next(Math.Max(0, dayRange));

			DateTime expirationDate = today.AddDays(randomDay);

			return expirationDate;
		}

		/// <summary>
		/// Generates a random CVV number.
		/// </summary>
		/// <returns>A three-digit CVV number.</returns>
		private string GenerateCvvNumber()
		{
			int cvv = _random.Next(100, 1000);
			return cvv.ToString();
		}
	}
}
