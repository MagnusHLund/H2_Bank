using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Bank.Models
{
	internal class Client
	{
		internal Account _account;
		internal string Name { get; set; }

		internal Client(string name) 
		{
			Name = name;
			_account = new Account(name);
		}
	}
}
