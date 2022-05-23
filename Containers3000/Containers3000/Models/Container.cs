using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public static List<string> ContainerIds = new List<string>();
		public string ContainerId { get; private set; }
		public double AvailableBoxStorage { get; private set; }
		private List<Box> StoragedBoxes { get; set; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ContainerId = Helper.GetId(ContainerIds);
			AvailableBoxStorage = Volume;
			StoragedBoxes = new List<Box>();
		}

		public static Container CreateContainer()
		{
			return new Container(20, 500, 100, 10000);
		}

		public bool AddBoxToContainer(Box box)
		{
			if (!DoesBoxFitIntoContainer(box))
				return false;

			StoragedBoxes.Add(box);
			AvailableBoxStorage -= box.Volume;
			AddWeight(box.Weight);
			return true;
		}

		public bool DoesBoxFitIntoContainer(Box box)
		{
			return box.Volume < AvailableBoxStorage;
		}

		public int CountStoragedBoxes()
		{
			return StoragedBoxes.Count;
		}
	}
}