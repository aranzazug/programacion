using System;
using System.Collections;

namespace DoFactory.GangOfFour.Iterator.Structural
{

	class MainApp
	{

		static void Main()
		{
			FellowshipMembers members = new FellowshipMembers();
			members[0] = "Frodo";
			members[1] = "Gandalf";
			members[2] = "Aragorn";
			members[3] = "Legolas";
			members[4] = "Merry";
			members[5] = "Pippin";
			members[6] = "Sam";
			members[7] = "Gimli";
			members[8] = "Boromir";


			ConcreteIterator i = new ConcreteIterator(members);

			Console.WriteLine("Members of the Fellowship of the ring:\n");

			object item = i.First();
			while (item != null)
			{
				Console.WriteLine(item);
				item = i.Next();
			}


			Console.ReadKey();
		}
	}


	abstract class Aggregate
	{
		public abstract Iterator CreateIterator();
	}


	class FellowshipMembers : Aggregate
	{
		private ArrayList _items = new ArrayList();

		public override Iterator CreateIterator()
		{
			return new ConcreteIterator(this);
		}

		public int Count
		{
			get { return _items.Count; }
		}


		public object this[int index]
		{
			get { return _items[index]; }
			set { _items.Insert(index, value); }
		}
	}


	abstract class Iterator
	{
		public abstract object First();
		public abstract object Next();
		public abstract bool IsDone();
		public abstract object CurrentItem();
	}


	class ConcreteIterator : Iterator
	{
		private FellowshipMembers _aggregate;
		private int _current = 0;


		public ConcreteIterator(FellowshipMembers aggregate)
		{
			this._aggregate = aggregate;
		}


		public override object First()
		{
			return _aggregate[0];
		}


		public override object Next()
		{
			object ret = null;
			if (_current < _aggregate.Count - 1)
			{
				ret = _aggregate[++_current];
			}

			return ret;
		}


		public override object CurrentItem()
		{
			return _aggregate[_current];
		}


		public override bool IsDone()
		{
			return _current >= _aggregate.Count;
		}
	}
}