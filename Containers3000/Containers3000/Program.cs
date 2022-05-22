using System;
using System.Collections.Generic;
using Containers3000.Models;
using BetterConsoleTables;

namespace Containers3000
{
	internal class Program
	{
		public const int NumberOfBoxes = 200;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();

		static void Main(string[] args)
		{
			Box nullBox = null;
			AddingBoxesUntilFull(NumberOfBoxes, 0, nullBox);

			PrintTable();

		}

		private static void AddingBoxesUntilFull(int notStoragedBoxes, int firstBox, Box nullBox)
		{
			Container container = Container.CreateContainer();
			Containers.Add(container);

			for (int i = firstBox; i < notStoragedBoxes; i++)
			{
				Box box;
				box = Box.GetBox(nullBox);
				Boxes.Add(box);

				if (!container.DoesBoxFitIntoContainer(box))
				{
					Box notFittingBox = box;
					Boxes.Remove(box);
					AddingBoxesUntilFull(notStoragedBoxes, i, notFittingBox);
					return;
				}
				else
					container.AddBoxToContainer(box);
				
				nullBox = null;
			}
		}

		private static void PrintTable()
		{
			int i = 1;
			var table = new Table("No.", "Container ID", "Number of boxes", "Loaded Weight");
			table.Config = TableConfiguration.UnicodeAlt();
			foreach (var container in Containers)
			{
				table.AddRow(i, container.StorageId, container.CountStoragedBoxes(), $"{container.ContentWeight} kg");
				i++;
			}

			Console.WriteLine(table.ToString());
		}
	}
}
