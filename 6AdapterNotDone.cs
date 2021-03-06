using System;

namespace DoFactory.GangOfFour.Adapter.RealWorld
{
	/// <summary>
	/// MainApp startup class for Real-World 
	/// Adapter Design Pattern.
	/// </summary>
	class MainApp
	{
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main()
		{
			// Non-adapted chemical compound
			Person unknown = new Person("Unknown");
			unknown.Display();

			// Adapted chemical compounds
			Person john = new IdPerson("John");
			john.Display();

			Person alexis = new IdPerson("Alexis");
			alexis.Display();

			Person andrew = new IdPerson("Andrew");
			andrew.Display();

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Target' class
	/// </summary>
	class Person
	{
		protected string nname;//_chemical;
		protected float hheight;//_boilingPoint;
		protected float wweight;//_meltingPoint;
		protected string  ggender;//_molecularWeight;
		protected int  iid;//_molecularFormula;

		// Constructor
		public Person(string name)
		{
			this.nname = name;
		}

		public virtual void Display()
		{
			Console.WriteLine("\nPerson name: {0} ------ ", nname);
		}
	}

	/// <summary>
	/// The 'Adapter' class
	/// </summary>
	class IdPerson : Person
	{
		private ChemicalDatabank _bank;

		// Constructor
		public IdPerson(string name)
			: base(name)
		{
		}

		public override void Display()
		{
			// The Adaptee
			_bank = new ChemicalDatabank();

			hheight = _bank.GetCriticalPoint(nname, "B");
			wweight = _bank.GetCriticalPoint(nname, "M");
			ggender = _bank.GetMolecularWeight(nname);
			iid = _bank.GetMolecularStructure(nname);

			base.Display();
			Console.WriteLine(" Height: {0}", hheight);
			Console.WriteLine(" Weight : {0}", wweight);
			Console.WriteLine(" Gender: {0}", ggender);
			Console.WriteLine(" Person Identification: {0}", iid);
		}
	}

	/// <summary>
	/// The 'Adaptee' class
	/// </summary>
	class ChemicalDatabank
	{
		// The databank 'legacy API'
		public float GetCriticalPoint(string compound, string point)
		{
			// Melting Point
			if (point == "M")
			{
				switch (compound.ToLower())
				{
				case "John": return 0.0f;
				case "Alexis": return 5.5f;
				case "Andrew": return -114.1f;
				default: return 0f;
				}
			}
			// Boiling Point
			else
			{
				switch (compound.ToLower())
				{
				case "john": return 100.0f;
				case "benzene": return 80.1f;
				case "ethanol": return 78.3f;
				default: return 0f;
				}
			}
		}

		public int GetMolecularStructure(int compound)
		{
			switch (compound.ToLower())
			{
			case "John": return 23;
			case "Alexis": return 6;
			case "Andrew": return 8;
			default: return 0;
			}
		}

		public string GetMolecularWeight(string compound)
		{
			switch (compound.ToLower())
			{
			case "John": return "18.015";
			case "Alexis": return "78.1134";
			case "Andrew": return "46.0688";
			default: return "0d";
			}
		}
	}
}