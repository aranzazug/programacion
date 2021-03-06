using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Command.RealWorld
{

	class MainApp
	{

		static void Main()
		{

			User user = new User();


			user.Compute("steps forward",100);
			user.Compute("steps back",50);
			user.Compute("steps left",45);
			user.Compute("steps right",70);


			user.Undo(3);


			user.Redo(2);

			Console.ReadKey();
		}
	}

	abstract class Command
	{
		public abstract void Execute();
		public abstract void UnExecute();
	}


	class CalculatorCommand : Command
	{
		private string _operator;
		private int _operand;
		private Calculator _calculator;


		public CalculatorCommand(Calculator calculator,
			string @operator, int operand)
		{
			this._calculator = calculator;
			this._operator = @operator;
			this._operand = operand;
		}


		public string Operator
		{
			set { _operator = value; }
		}


		public int Operand
		{
			set { _operand = value; }
		}


		public override void Execute()
		{
			_calculator.Operation(_operator, _operand);
		}


		public override void UnExecute()
		{
			_calculator.Operation(Undo(_operator), _operand);
		}


		private string Undo(string @operator)
		{
			switch (@operator)
			{
			case "steps forward": return "steps back";
			case "steps back": return "steps forward";
			case "steps left": return "steps right";
			case "steps right": return "steps left";
	
			default: throw new
				ArgumentException("@operator");
			}
		}
	}


	class Calculator
	{
		private int _curr = 0;

		public void Operation(string @operator, int operand)
		{
			switch (@operator)
			{
			case "steps forward": _curr += operand; break;
			case "steps back": _curr -= operand; break;
			case "steps right": _curr += operand; break;
			case "steps left": _curr -= operand; break;
		
			}
			Console.WriteLine(
				" takes {2} {1}",
				_curr, @operator, operand);
		}
	}


	class User
	{

		private Calculator _calculator = new Calculator();
		private List<Command> _commands = new List<Command>();
		private int _current = 0;

		public void Redo(int levels)
		{
			Console.WriteLine("\n---- Redo {0} actions \n", levels);

			for (int i = 0; i < levels; i++)
			{
				if (_current < _commands.Count - 1)
				{
					Command command = _commands[_current++];
					command.Execute();
				}
			}
		}

		public void Undo(int levels)
		{
			Console.WriteLine("\n---- Undo {0} actions \n", levels);

			for (int i = 0; i < levels; i++)
			{
				if (_current > 0)
				{
					Command command = _commands[--_current] as Command;
					command.UnExecute();
				}
			}
		}

		public void Compute(string @operator, int operand)
		{
	
			Command command = new CalculatorCommand(
				_calculator, @operator, operand);
			command.Execute();


			_commands.Add(command);
			_current++;
		}
	}
}
