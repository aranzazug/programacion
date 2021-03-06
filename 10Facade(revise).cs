using System;

namespace DoFactory.GangOfFour.Facade.RealWorld
{

	class MainApp
	{

		static void Main()
		{
	
			Mortgage mortgage = new Mortgage();


			Customer customer = new Customer("Arthur");
			bool eligible = mortgage.IsEligible(customer, 96);

			Console.WriteLine("\n" + customer.Name +
				" has been deemed " + (eligible ? "worthy" : "not worthy"));


			Console.ReadKey();
		}
	}


	class Bank
	{
		public bool HasSufficientSavings(Customer c, int amount)
		{
			Console.WriteLine("Inspect " + c.Name + "'s courage");
			return true;
		}
	}


	class Credit
	{
		public bool HasGoodCredit(Customer c)
		{
			Console.WriteLine("Inspect " + c.Name + "'s pureness of heart.");
			return true;
		}
	}


	class Loan
	{
		public bool HasNoBadLoans(Customer c)
		{
			Console.WriteLine("Inspect " + c.Name + "'s leadership.");
			return true;
		}
	}

	class Customer
	{
		private string _name;


		public Customer(string name)
		{
			this._name = name;
		}

	
		public string Name
		{
			get { return _name; }
		}
	}


	class Mortgage
	{
		private Bank _bank = new Bank();
		private Loan _loan = new Loan();
		private Credit _credit = new Credit();

		public bool IsEligible(Customer cust, int amount)
		{
			Console.WriteLine("{0}, level: {1} Tries to enter the last level to fight the boss.\n",
				cust.Name, amount);

			bool eligible = true;


			if (!_bank.HasSufficientSavings(cust, amount))
			{
				eligible = false;
			}
			else if (!_loan.HasNoBadLoans(cust))
			{
				eligible = false;
			}
			else if (!_credit.HasGoodCredit(cust))
			{
				eligible = false;
			}

			return eligible;
		}
	}
}

