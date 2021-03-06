using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Factory.RealWorld
{
	
	class MainApp
	{
		
		static void Main()
		{
	
			BodyPart[] bodyparts = new BodyPart[2];

			bodyparts[0] = new Face();
			bodyparts[1] = new Hand();

			foreach (BodyPart bodypart in bodyparts)
			{
				Console.WriteLine("\n" + bodypart.GetType().Name + "--");
				foreach (Part ppart in bodypart.Parts)
				{
					Console.WriteLine(" " + ppart.GetType().Name);
				}
			}
				
			Console.ReadKey();
		}
	}
		
	abstract class Part
	{
	}
		
	class Eyes : Part
	{
	}
		
	class Nose : Part
	{
	}
		
	class Mouth : Part
	{
	}
		
	class Palm : Part
	{
	}
		
	class Thumb : Part
	{
	}
		
	class RestOfFingers : Part
	{
	}
		


	abstract class BodyPart
	{
		private List<Part> parts = new List<Part>();

		public BodyPart()
		{
			this.CreateParts();
		}

		public List<Part> Parts
		{
			get { return parts; }
		}
			
		public abstract void CreateParts();
	}


	class Face : BodyPart
	{
		
		public override void CreateParts()
		{
			Parts.Add(new Eyes());
			Parts.Add(new Nose());
			Parts.Add(new Mouth());
		}
	}


	class Hand : BodyPart
	{

		public override void CreateParts()
		{
			Parts.Add(new Palm());
			Parts.Add(new Thumb());
			Parts.Add(new RestOfFingers());
		}
	}
}