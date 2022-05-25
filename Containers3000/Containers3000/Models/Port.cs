using System.Collections.Generic;
using Containers3000.Helpers;

namespace Containers3000.Models
{
	public class Port
	{
		public int DockingSpots { get; set; }
		public List<int> Distances { get; set; }
		public List<Ship> DockedShips { get; set; }
		public Dictionary<int, Ship> DockingSpot { get; set; }
		public List<Container> ContainersInDocks { get; set; }
		public ContainerLocation Location { get; set; } = ContainerLocation.None;
		public DockOccupation Occupation { get; set; } = DockOccupation.None;

		public Port(int dockingSpots)
		{
			DockingSpots = dockingSpots;
			DockedShips = new List<Ship>();
			Distances = GetDistances();
			DockingSpot = new Dictionary<int, Ship>();
			ContainersInDocks = new List<Container>();
		}

		public List<int> GetDistances()
		{
			Distances = new List<int>(DockingSpots - 1);
			for (int i = 0; i < DockingSpots - 1; i++)
			{
				Distances.Add(GeneratingHelper.GetRng(100, 451));
			}
			return Distances;
		}

	}
}