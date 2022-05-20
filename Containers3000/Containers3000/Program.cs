using System;
using System.Collections.Generic;
using Containers3000.Models;
using BetterConsoleTables;

namespace Containers3000
{
	internal class Program
	{
		public const int NumberOfBoxes = 30;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();

		static void Main(string[] args)
		{
			Box nullBox = null;
			PrintBoxList(NumberOfBoxes);

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
				
				if (container.DoesBoxFitIntoContainer(box))
				{
					Box notFittingBox = box;
					Boxes.Remove(box);
					AddingBoxesUntilFull(notStoragedBoxes, firstBox, notFittingBox);
					break;
				}

				container.AddBoxToContainer(box);

				nullBox = null;
			}
		}

		private static void PrintTable()
		{
			int i = 1;
			var table = new Table("No.", "Container ID", "Number of boxes", "Container Weight");
			table.Config = TableConfiguration.UnicodeAlt();
			foreach (var container in Containers)
			{
				table.AddRow(i, container.StorageId, 6, container.Weight);
				i++;
			}

			Console.WriteLine(table.ToString());
		}

		private static void PrintBoxList(int notStoragedBoxes)
		{
			Console.WriteLine("Box List: ");
			for (int i = 0; i < notStoragedBoxes; i++)
			{
				var box = Box.GenerateBoxParameters();
				if (i % 2 == 0)
					Console.ForegroundColor = ConsoleColor.Blue;

				Console.WriteLine($"{i + 1}. Box - {box.StorageId}");
				Console.ResetColor();

			}
		}
	}
}
