using H2_Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Bank.Models.Cards
{
	internal abstract class Card : ICard
	{
		protected string[] cardPrefix;
		protected byte minimumAge;
		protected string cardHolder;
		protected DateTime expirationDate;

		internal Card(string name) 
		{
			cardHolder = name;
		}

		public double Balance { get; set; }

		public virtual string GenerateCardNumber()
		{
			return "";
		}

		public virtual void GenerateExpirationDate()
		{
			// Default max size: 5 år. YouthCard = null. Maestro = 5 år 8 måneder
			Random random = new Random();

			DateTime today = DateTime.Now;
			DateTime maxDate = today.AddYears(5);

			int dayRange = (today - maxDate).Days;
			int randomDay = random.Next(dayRange);

			expirationDate = today.AddDays(randomDay);
		}

		public virtual string GenerateCvvNumber()
		{
			Random random = new Random();
			int cvv = random.Next(100, 1000);
			return cvv.ToString();
		}

		public void SpendMoney(float amount)
		{
			Balance -= amount;
		}
	}
}
