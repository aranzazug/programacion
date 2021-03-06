using System;

namespace DoFactory.GangOfFour.Abstract.RealWorld
{
	
	class MainApp
	{
		
		public static void Main()
		{
			
			FoodFactory caribbean = new CaribbeanFactory();
			FoodWorld world = new FoodWorld(caribbean);
			world.RunFoodChain();

			
			FoodFactory country = new CountryFactory();
			world = new FoodWorld(country);
			world.RunFoodChain();

			
			Console.ReadKey();
		}
	}



	abstract class FoodFactory
	{
		public abstract Fruit CreateFruit();
		public abstract Meat CreateMeat();
	}

	
	class CountryFactory : FoodFactory
	{
		public override Fruit CreateFruit()
		{
			return new Jalapeno();
		}
		public override Meat CreateMeat()
		{
			return new Steak();
		}
	}

	
	class CaribbeanFactory : FoodFactory
	{
		public override Fruit CreateFruit()
		{
			return new Pineapple();
		}
		public override Meat CreateMeat()
		{
			return new Ham();
		}
	}

	
	abstract class Fruit
	{
	}

	
	abstract class Meat
	{
		public abstract void Eat(Fruit h);
	}

	
	class Jalapeno : Fruit
	{
	}

	
	class Steak : Meat
	{
		public override void Eat(Fruit h)
		{
			
			Console.WriteLine(this.GetType().Name +
				" goes with " + h.GetType().Name);
		}
	}

	
	class Pineapple : Fruit
	{
	}

	
	class Ham : Meat
	{
		public override void Eat(Fruit h)
		{
			
			Console.WriteLine(this.GetType().Name +
				" goes well with " + h.GetType().Name);
		}
	}

	
	class FoodWorld
	{
		private Fruit ffruit;
		private Meat mmeat;

		
		public FoodWorld(FoodFactory factory)
		{
			mmeat = factory.CreateMeat();
			ffruit = factory.CreateFruit();
		}

		public void RunFoodChain()
		{
			mmeat.Eat(ffruit);
		}
	}
}
