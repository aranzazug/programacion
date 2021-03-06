using System;

namespace DoFactory.GangOfFour.Prototype.Structural
{
	
	class MainApp
	{
				static void Main()
		{
			
			Random rnd = new Random();
			int stuid = rnd.Next(1, 15);
			int stuid2 = rnd.Next(1, 15);
			int stuid3 = rnd.Next(1, 15);

		
		  

			ConcretePrototype1 p1 = new ConcretePrototype1(stuid);
			ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
			Console.WriteLine("Student ID: {0}", c1.Id);

			ConcretePrototype2 p2 = new ConcretePrototype2(stuid2);
			ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
			Console.WriteLine("Student ID: {0}", c2.Id);

			ConcretePrototype3 p3 = new ConcretePrototype3(stuid3);
			ConcretePrototype3 c3 = (ConcretePrototype3)p3.Clone();
			Console.WriteLine("Student ID: {0}", c3.Id);

			
			Console.ReadKey();
		}
	}


	
	abstract class Prototype
	{
		private int _id;

		
		public Prototype(int id)
		{
			this._id = id;
		}

		
		public int Id
		{
			get { return _id; }
		}

		public abstract Prototype Clone();
	}


	class ConcretePrototype1 : Prototype
	{
		
		public ConcretePrototype1(int id)
			: base(id)
		{
		}

		
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}

	
	class ConcretePrototype2 : Prototype
	{
		
		public ConcretePrototype2(int id)
			: base(id)
		{
		}

		
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}

	class ConcretePrototype3 : Prototype
	{
		
		public ConcretePrototype3(int id)
			: base(id)
		{
		}

		
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}
}

