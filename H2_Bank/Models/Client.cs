using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Bank.Models
{
	internal class Client
	{
		internal Account account;
		internal string Name { get; set; }
		internal byte Age { get; set; }

		internal Client(string name, byte age) 
		{
			Name = name;
			Age = age;

			account = new Account(this);
		}
	}
}
