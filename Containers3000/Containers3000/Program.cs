using System;
using System.Collections.Generic;
using System.Threading;
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
			Container nullContainer = null;
			AddingBoxesUntilFull(NumberOfBoxes, 0, nullBox);
			int numberOfContainers = Containers.Count;
			AddingContainersUntilFull(numberOfContainers, 0, nullContainer);

			while (true)
			{
				Menu();
				Thread.Sleep(500);
			}
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
					PrintShipTable();
					Console.WriteLine("\n");
					PrintContainerTable();
					break;
				case 2:
					Console.WriteLine("Not yet");
					break;
				case 3:
					Console.WriteLine("Not yet");
					break;
				case 4:
					Environment.Exit(0);
					break;
			}
		}

		#region Adding storage

		private static void AddingContainersUntilFull(int notStoragedContainers, int firstContainer, Container nullContainer)
		{
			var ship = Ship.CreateShip();
			Ships.Add(ship);
			
			for (int i = firstContainer; i < notStoragedContainers; i++)
			{
				var container = Container.GetContainer(nullContainer);

				if (!ship.DoesSmallerStorageFitIntoBiggerStorage(container))
				{
					var notFittingContainer = container;
					Containers.Remove(notFittingContainer);
					AddingContainersUntilFull(notStoragedContainers, i, nullContainer);
					return;
				}

				ship.AddContainer(container);

				ship.CheckStorageState(container, ship);
				ship.ReturnStorageState(ship);

				nullContainer = null;
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
				container.CheckStorageState(box, container);
				container.ReturnStorageState(container);

				nullBox = null;
			}
		}

		#endregion

		#region Printing tables

		private static void PrintShipTable()
		{
			ColumnHeader[] shipHeaders = new[]
			{
				new ColumnHeader("Ship ID", Alignment.Center, Alignment.Center),
				new ColumnHeader("Ship State", Alignment.Center, Alignment.Center),
				new ColumnHeader("Containers Inside", Alignment.Center, Alignment.Center),
				new ColumnHeader("Loaded Weight", Alignment.Center, Alignment.Center),
				//new ColumnHeader("Docking spot", Alignment.Center, Alignment.Center),
			};
			
			var shipTable = new Table(shipHeaders);
			shipTable.Config = TableConfiguration.UnicodeAlt();
			foreach (var ship in Ships)
			{
				shipTable.AddRow(ship.ShipId, ship.ReturnStorageState(ship), ship.CountSmallerStorage(ship.ContainersInside), $"{ship.ContentWeight} kg");
			}

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("Ship Table: \n");
			Console.WriteLine(shipTable.ToString());
			Console.ResetColor();
		}

		private static void PrintContainerTable()
		{
			ColumnHeader[] containerHeaders = new[]
			{
				new ColumnHeader("Container ID", Alignment.Center, Alignment.Center),
				new ColumnHeader("Container State", Alignment.Center, Alignment.Center),
				new ColumnHeader("Containers Inside", Alignment.Center, Alignment.Center),
				new ColumnHeader("Loaded Weight", Alignment.Center, Alignment.Center),
				//new ColumnHeader("Location", Alignment.Center, Alignment.Center),
			};

			var containerTable = new Table(containerHeaders);
			containerTable.Config = TableConfiguration.UnicodeAlt();
			foreach (var container in Containers)
			{
				containerTable.AddRow(container.ContainerId, container.ReturnStorageState(container), container.CountSmallerStorage(container.BoxesInside), $"{container.ContentWeight} kg"/*, $"ship(ship id)/dock"*/);
			}

			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine("Container Table: \n");
			Console.WriteLine(containerTable.ToString());
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
				.AddRow("1", "Print tables with port info")
				.AddRow("2", "Move container to different ship")
				.AddRow("3", "Unload container from ship to docks")
				.AddRow("4", "Exit");

			menuTable.Config = TableConfiguration.UnicodeAlt();
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(menuTable.ToString());
		}

		#endregion
	}
}
