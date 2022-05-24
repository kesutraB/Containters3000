using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Ship : StorageBase
	{
		public static List<string> ShipIds = new List<string>();
		public string ShipId { get; private set; }
		public List<StorageBase> ContainersInside { get; set; }

		public Ship(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ShipId = GetId(ShipIds);
			ContainersInside = new List<StorageBase>();
		}

		public static Ship CreateShip()
		{
			return new Ship(40, 250, 1000, 100000);
		}

	}
}