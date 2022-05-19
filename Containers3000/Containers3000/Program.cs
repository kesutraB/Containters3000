using System;
using System.Collections.Generic;
using Containers3000.Models;

namespace Containers3000
{
	internal class Program
	{
		public const int NumberOfBoxes = 10;
		public static List<Box> Boxes = new List<Box>();
		public static Container Container = new Container(20, 50, 100, 1000);
		static void Main(string[] args)
		{
			PrintInfo();
		}

		private static void PrintInfo()
		{
			Console.WriteLine("Box List: ");
			for (int i = 0; i < NumberOfBoxes; i++)
			{
				var box = Container.GenerateBoxParameters();

				Boxes.Add(box);
				Console.WriteLine(box);

				if (Container.DoesBoxFitContainer(Boxes[i]))
				{
					Container.DontAddBoxToContainer(box);
					Console.WriteLine($"Number of Boxes added: {Boxes.Count - 1}.");
					Environment.Exit(1);
				}
				else
					Container.AddBoxToContainer(Boxes[i]);

				Container.PrintRemainingStorage();
			}

			Console.WriteLine($"Number of Boxes added: {Boxes.Count}.");
		}
	}
}
