using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Composite.Structural
{

	class MainApp
	{

		static void Main()
		{
	
			Composite kingdom = new Composite("Kingdom");


			Composite animalia = new Composite("Animalia");
			animalia.Add(new Leaf("Around 1.4M species"));

			Composite phylluma = new Composite("Phyllum");
			phylluma.Add(new Leaf("Chordata"));
			phylluma.Add(new Leaf("annelida"));
			phylluma.Add(new Leaf("Others.."));

			Composite plantae = new Composite("Plantae");
			plantae.Add(new Leaf("Around 275000 species"));

			Composite phyllump = new Composite("Phyllum");
			phyllump.Add(new Leaf("Angiospermae"));
			phyllump.Add(new Leaf("Marcantiophyta"));
			phyllump.Add(new Leaf("Others.."));



			kingdom.Add(animalia);
			kingdom.Add(plantae);
			animalia.Add (phylluma);
			plantae.Add (phyllump);




	
			Leaf leaf = new Leaf("Leaf D");
			kingdom.Add(leaf);
			kingdom.Remove(leaf);

			kingdom.Display(1);


			Console.ReadKey();
		}
	}


	abstract class Component
	{
		protected string name;


		public Component(string name)
		{
			this.name = name;
		}

		public abstract void Add(Component c);
		public abstract void Remove(Component c);
		public abstract void Display(int depth);
	}


	class Composite : Component
	{
		private List<Component> _children = new List<Component>();

	
		public Composite(string name)
			: base(name)
		{
		}

		public override void Add(Component component)
		{
			_children.Add(component);
		}

		public override void Remove(Component component)
		{
			_children.Remove(component);
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new String('-', depth) + name);

			foreach (Component component in _children)
			{
				component.Display(depth + 2);
			}
		}
	}

	/// <summary>
	/// The 'Leaf' class
	/// </summary>
	class Leaf : Component
	{
		// Constructor
		public Leaf(string name)
			: base(name)
		{
		}

		public override void Add(Component c)
		{
			Console.WriteLine("Cannot add to a leaf");
		}

		public override void Remove(Component c)
		{
			Console.WriteLine("Cannot remove from a leaf");
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new String('-', depth) + name);
		}
	}
}