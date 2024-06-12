﻿namespace H2_Bank.Models
{
	internal class Client
	{
		internal Account Account { get; }
		internal string Name { get; set; }
		internal byte Age { get; set; }

		internal Client(string name, byte age) 
		{
			Name = name;
			Age = age;

			Account = new Account(this);
		}
	}
}
