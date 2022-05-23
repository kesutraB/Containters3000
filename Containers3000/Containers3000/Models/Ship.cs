using System.Collections.Generic;
using Containers3000.Helpers;

namespace Containers3000.Models
{
	public class Ship : StorageBase
	{
		public static List<string> ShipIds = new List<string>();
		public string ShipId { get; private set; }
		public List<StorageBase> ContainersInside { get; set; }
		public ShipState State { get; set; } = ShipState.None;

		public Ship(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ShipId = GetId(ShipIds);
			ContainersInside = new List<StorageBase>();
		}

		public static Ship CreateShip()
		{
			return new Ship(40, 250, 1000, 100000);
		}

		public string ReturnShipState(Ship ship)
		{
			if (ship.State == ShipState.Full)
				return "Full";

			return "Not Full";
		}

		public void CheckShipState(Ship ship, Container container)
		{
			if (ship.DoesSmallerStorageFitIntoBiggerStorage(container))
				ship.State = ShipState.NotFull;
			else if (!ship.DoesSmallerStorageFitIntoBiggerStorage(container))
				ship.State = ShipState.Full;
		}
	}
}