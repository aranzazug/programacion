using System;

namespace DoFactory.GangOfFour.Chain.Structural
{

	class MainApp
	{
		
		static void Main()
		{
			
			Handler h1 = new Squirtle();
			Handler h2 = new Wartortle();
			Handler h3 = new Blastoise();
			Handler h4 = new MegaBlastoise();
			h1.SetSuccessor(h2);
			h2.SetSuccessor(h3);
			h3.SetSuccessor(h4);


			string[] requests = { "stage1", "stage2" , "stage3", "megaevolved", "stage1", "stage3" };

			foreach (string request in requests)
			{
				h1.HandleRequest(request);
			}


			Console.ReadKey();
		}
	}


	abstract class Handler
	{
		protected Handler successor;

		public void SetSuccessor(Handler successor)
		{
			this.successor = successor;
		}

		public abstract void HandleRequest(string request);
	}


	class Squirtle : Handler
	{
		public override void HandleRequest(string request)
		{
			if (request == "stage1")
			{
				Console.WriteLine("{0} can handle a pokemon evolved up to {1}\n",
					this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}


	class Wartortle : Handler
	{
		public override void HandleRequest(string request)
		{
			if (request == "stage2")
			{
				Console.WriteLine("{0} can handle a pokemon evolved up to {1}\n",
					this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}


	class Blastoise : Handler
	{
		public override void HandleRequest(string request)
		{
			if (request == "stage3")
			{
				Console.WriteLine("{0} can handle a pokemon evolved up to {1}\n",
					this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}

	class MegaBlastoise : Handler
	{
		public override void HandleRequest(string request)
		{
			if (request == "megaevolved")
			{
				Console.WriteLine("{0} can handle a {1} pokemon\n",
					this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}
}

