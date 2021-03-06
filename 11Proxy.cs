using System;

namespace DoFactory.GangOfFour.Proxy.RealWorld
{

	class MainApp
	{

		static void Main()
		{

			MathProxy proxy = new MathProxy();


			Console.WriteLine("657890 Cop to Dollars = " + proxy.Dol(657890));
			Console.WriteLine("657890 Cop to Euro = " + proxy.Euro(657890));
			Console.WriteLine("657890 Cop to Yen = " + proxy.Yen(657890));
			Console.WriteLine("657890 Cop to Rupee = " + proxy.Rupee(657890));


			Console.ReadKey();
		}
	}


	public interface IMath
	{
		double Dol(double x);
		double Euro(double x);
		double Yen(double x);
		double Rupee(double x);
	}
		

	class Math : IMath
	{
		public double Dol(double x) { return x * 0.00033; }
		public double Euro(double x) { return x * 0.00030; }
		public double Yen(double x) { return x * 0.040; }
		public double Rupee(double x) { return x * 0.22; }
	}


	class MathProxy : IMath
	{
		private Math _math = new Math();

		public double Dol(double x)
		{
			return _math.Dol(x);
		}
		public double Euro(double x)
		{
			return _math.Euro(x);
		}
		public double Yen(double x)
		{
			return _math.Yen(x);
		}
		public double Rupee(double x)
		{
			return _math.Rupee(x);
		}
	}
}