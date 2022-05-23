using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Ship : StorageBase
	{
		public static List<string> ShipIds = new List<string>();
		public string ShipId { get; private set; }
		public double AvailableContainerStorage { get; private set; }
		private List<Container> StoragedContainers { get; set; }

		public Ship(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ShipId = Helper.GetId(ShipIds);
			AvailableContainerStorage = Volume;
			StoragedContainers = new List<Container>();
		}

		public static Ship CreateShip()
		{
			return new Ship(100, 200, 1000, 200000);
		}
	}
}