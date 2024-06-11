using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Bank.Interfaces
{
	public interface ICard
	{
		double Balance { get; set; }
		string GenerateCardNumber();
		void GenerateExpirationDate();
		string GenerateCvvNumber();
		void SpendMoney(float amount);
	}
}
