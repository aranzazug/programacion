using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Builder.Structural
{

	public class MainApp
	{
		
		public static void Main()
		{
			Console.WriteLine ("\nThis is a list of our menu for ice cream cones");
			
			Director director = new Director();

			Builder b1 = new ConcreteBuilder1();
			Builder b2 = new ConcreteBuilder2();

			
			director.Construct(b1);
			Product p1 = b1.GetResult();
			p1.Show();
			Console.WriteLine ("\nThis is a list of our menu for sundaes");
			director.Construct(b2);
			Product p2 = b2.GetResult();
			p2.Show();

			Console.ReadKey();
		}
	}

	
	class Director
	{
		public void Construct(Builder builder)
		{
			builder.BuildPartA();
			builder.BuildPartB();
			builder.BuildPartC();
		}
	}

	
	abstract class Builder
	{
		public abstract void BuildPartA();
		public abstract void BuildPartB();
		public abstract void BuildPartC();
		public abstract Product GetResult();
	}

	
	class ConcreteBuilder1 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			_product.Add("\nStrawberry");
		}

		public override void BuildPartB()
		{
			_product.Add("Chocolate");
		}

		public override void BuildPartC()
		{
			_product.Add("Vanilla");
		}

		public override Product GetResult()
		{
			return _product;
		}
	}

	
	class ConcreteBuilder2 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			_product.Add("\nVanilla");
		}

		public override void BuildPartB()
		{
			_product.Add("Chocolate");
		}

		public override void BuildPartC()
		{
			_product.Add("Mixed");
		}


		public override Product GetResult()
		{
			return _product;
		}
	}

	
	class Product
	{
		private List<string> _parts = new List<string>();

		public void Add(string part)
		{
			_parts.Add(part);
		}

		public void Show()
		{
			Console.WriteLine("\nOur flavors:");
			foreach (string part in _parts)
				Console.WriteLine(part);
		}
	}
}