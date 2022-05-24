using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Containers3000.Models;
using BetterConsoleTables;

namespace Containers3000
{
	internal class Program
	{
		public const int NumberOfBoxes = 600;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();
		public static List<Ship> Ships = new List<Ship>();

		static void Main(string[] args)
		{
			Box nullBox = null;
			AddingBoxesUntilFull(NumberOfBoxes, 0, nullBox);
			int numberOfContainers = Containers.Count;
			AddingContainersUntilFull(numberOfContainers, 0);

			Menu();
		}

		private static void Menu()
		{
			PrintMenuTable();
			Console.Write("Enter any action: ");
			string input = Console.ReadLine();
			int switchMenu = int.Parse(input);
			Console.WriteLine("\n\n");
			Console.ResetColor();

			switch (switchMenu)
			{
				case 1:
					PrintPortTable();
					break;
				case 2:
					Console.WriteLine("Not yet");
					break;
				case 3:
					Console.WriteLine("Not yet");
					break;
			}
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

				ship.CheckShipState(ship, container);
				ship.ReturnShipState(ship);
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
			ColumnHeader[] portHeaders = new[]
			{
				new ColumnHeader("Ship ID", Alignment.Center, Alignment.Center),
				new ColumnHeader("Ship State", Alignment.Center, Alignment.Center),
				new ColumnHeader("Container ID", Alignment.Center, Alignment.Center),
				new ColumnHeader("Boxes Inside", Alignment.Center, Alignment.Center),
				new ColumnHeader("Loaded Weight", Alignment.Center, Alignment.Center),
				//new ColumnHeader("Location", Alignment.Center, Alignment.Center),
				//new ColumnHeader("Docking spot", Alignment.Center, Alignment.Center),
			};
			var portTable = new Table(portHeaders);
			portTable.Config = TableConfiguration.UnicodeAlt();
			foreach (var ship in Ships)
			{
				foreach (var container in Containers)
				{
					portTable.AddRow(ship.ShipId, ship.ReturnShipState(ship), container.ContainerId, container.CountSmallerStorage(container.BoxesInside), $"{container.ContentWeight} kg");
				}
			}

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("Port Table: \n");
			Console.WriteLine(portTable.ToString());
			Console.ResetColor();
		}

		private static void PrintMenuTable()
		{
			ColumnHeader[] menuHeaders = new[]
			{
				new ColumnHeader("Action Key", Alignment.Center, Alignment.Center),
				new ColumnHeader("Action", Alignment.Center, Alignment.Center)
			};
			
			var menuTable = new Table(menuHeaders)
				.AddRow("1", "Print table with port info")
				.AddRow("2", "Move container to different ship")
				.AddRow("3", "Unload container from ship to docks");

			menuTable.Config = TableConfiguration.UnicodeAlt();
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(menuTable.ToString());
		}
	}
}
