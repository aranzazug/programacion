using System;
using System.Collections.Generic;
using System.Threading;

namespace DoFactory.GangOfFour.Singleton.RealWorld
{

	class MainApp
	{

		static void Main()
		{
			LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

			if (b1 == b2 && b2 == b3 && b3 == b4)
			{
				Console.WriteLine("Votes in Antioquia\n");
			}

			// Load balance 15 server requests
			LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
			for (int i = 0; i < 15; i++)
			{
				string server = balancer.Server;
				Console.WriteLine("Has to vote in: " + server);
			}

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Singleton' class
	/// </summary>
	class LoadBalancer
	{
		private static LoadBalancer _instance;
		private List<string> votingplaces = new List<string>();
		private Random location = new Random();

		// Lock synchronization object
		private static object syncLock = new object();

		// Constructor (protected)
		protected LoadBalancer()
		{
			// List of available servers
			votingplaces.Add("Envigado");
			votingplaces.Add("Medellín");
			votingplaces.Add("Bello");
			votingplaces.Add("Sabaneta");
			votingplaces.Add("Itagui");
		}

		public static LoadBalancer GetLoadBalancer()
		{
			// Support multithreaded applications through
			// 'Double checked locking' pattern which (once
			// the instance exists) avoids locking each
			// time the method is invoked
			if (_instance == null)
			{
				lock (syncLock)
				{
					if (_instance == null)
					{
						_instance = new LoadBalancer();
					}
				}
			}

			return _instance;
		}

		// Simple, but effective random load balancer
		public string Server
		{
			get
			{
				int l = location.Next(votingplaces.Count);
				return votingplaces[l].ToString();
			}
		}
	}
}