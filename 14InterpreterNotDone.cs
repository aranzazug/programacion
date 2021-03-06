using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Interpreter.RealWorld
{

	class MainApp
	{

		static void Main()
		{
			string munotes = "414321";
			Context context = new Context(munotes);

	
			List<Expression> tree = new List<Expression>();
			tree.Add(new Note1());
			tree.Add(new Note2());
			tree.Add(new Note3());
			tree.Add(new Note4());
			/*tree.Add(new Note5());
			tree.Add(new Note6());
			tree.Add(new Note7());
			tree.Add(new Note8());*/


			// Interpret
			foreach (Expression exp in tree)
			{
				exp.Interpret(context);
			}

			Console.WriteLine("{0} = {1}",
				munotes, context.Output);

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Context' class
	/// </summary>
	class Context
	{
		private string _input;
		private string _output;

		// Constructor
		public Context(string input)
		{
			this._input = input;
		}

		// Gets or sets input
		public string Input
		{
			get { return _input; }
			set { _input = value; }
		}

		// Gets or sets output
		public string Output
		{
			get { return _output; }
			set { _output = value; }
		}
	}

	/// <summary>
	/// The 'AbstractExpression' class
	/// </summary>
	abstract class Expression
	{
		public void Interpret(Context context)
		{
			if (context.Input.Length == 1)
				return;

			if (context.Input.StartsWith(Do()))
			{
				context.Output += ("Do");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Re");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Mi");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Fa");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Sol");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("La");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Si");
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Re()))
			{
				context.Output += ("Do2");
				context.Input = context.Input.Substring(2);
			}
	
	
		}

		public abstract string Do();
		public abstract string Re();
		public abstract string Mi();
		public abstract string Fa();
		public abstract string Sol();
		public abstract string La();
		public abstract string Si();
		public abstract string Do2();
	}


	class Note1 : Expression
	{
		public override string Do() { return "1"; }
		public override string Re() { return " "; }
		public override string Mi() { return " "; }
		public override string Fa() { return " "; }
		public override string Sol() { return " "; }
		public override string La() { return " "; }
		public override string Si() { return " "; }
		public override string Do2() { return " "; }
	}

	/// <summary>
	/// A 'TerminalExpression' class
	/// <remarks>
	/// Hundred checks C, CD, D or CM
	/// </remarks>
	/// </summary>
	class Note2 : Expression
	{
		public override string Do() { return ""; }
		public override string Re() { return "2"; }
		public override string Mi() { return " "; }
		public override string Fa() { return " "; }
		public override string Sol() { return " "; }
		public override string La() { return " "; }
		public override string Si() { return " "; }
		public override string Do2() { return " "; }
	}


	class Note3 : Expression
	{
		public override string Do() { return ""; }
		public override string Re() { return ""; }
		public override string Mi() { return "3 "; }
		public override string Fa() { return " "; }
		public override string Sol() { return " "; }
		public override string La() { return " "; }
		public override string Si() { return " "; }
		public override string Do2() { return " "; }
	}


	class Note4 : Expression
	{
		public override string Do() { return ""; }
		public override string Re() { return ""; }
		public override string Mi() { return " "; }
		public override string Fa() { return "4 "; }
		public override string Sol() { return " "; }
		public override string La() { return " "; }
		public override string Si() { return " "; }
		public override string Do2() { return " "; }
	}
}