using System;
using System.Collections.Generic;
using Containers3000.Models;
using BetterConsoleTables;

namespace Containers3000
{
	internal class Program
	{
		public const int NumberOfBoxes = 750;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();
		public static List<Ship> Ships = new List<Ship>();

		static void Main(string[] args)
		{
			Box nullBox = null;
			AddingBoxesUntilFull(NumberOfBoxes, 0, nullBox);
			int numberOfContainers = Containers.Count;
			AddingContainersUntilFull(numberOfContainers, 0);

			PrintPortTable();

		}

		private static void AddingContainersUntilFull(int notStoragedContainers, int firstContainer)
		{
			var ship = Ship.CreateShip();
			Ships.Add(ship);

			for (int i = firstContainer; i < notStoragedContainers; i++)
			{
				var container = Containers[i];
				Containers.Add(container);

				if (!ship.DoesSmallerStorageFitIntoBiggerStorage(container))
				{
					var notFittingContainer = container;
					Containers.Remove(notFittingContainer);
					AddingContainersUntilFull(notStoragedContainers, i);
					return;
				}

				ship.AddSmallerStorageToBiggerStorage(container, ship.ContainersInside);
			}
		}

		private static void AddingBoxesUntilFull(int notStoragedBoxes, int firstBox, Box nullBox)
		{
			var container = Container.CreateContainer();
			Containers.Add(container);

			for (int i = firstBox; i < notStoragedBoxes; i++)
			{
				var box = Box.GetBox(nullBox);
				Boxes.Add(box);

				if (!container.DoesSmallerStorageFitIntoBiggerStorage(box))
				{
					var notFittingBox = box;
					Boxes.Remove(box);
					AddingBoxesUntilFull(notStoragedBoxes, i, notFittingBox);
					return;
				}

				container.AddSmallerStorageToBiggerStorage(box, container.BoxesInside);

				nullBox = null;
			}
		}

		private static void PrintPortTable()
		{
			int i = 1;
			var table = new Table("No.","Ship ID"/*, "Number of Containers", "Ship State"*/, "Container ID", "Number of Boxes", "Loaded Weight"/*, "Location", "Docking Spot"*/);
			table.Config = TableConfiguration.UnicodeAlt();
			foreach (var ship in Ships)
			{
				foreach (var container in Containers)
				{
					table.AddRow(i, ship.ShipId, container.ContainerId, container.CountSmallerStorage(container.BoxesInside), $"{container.ContentWeight} kg");
					i++;
				}
			}

			Console.WriteLine("Port Table: \n");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine(table.ToString());
			Console.ResetColor();
		}
	}
}
