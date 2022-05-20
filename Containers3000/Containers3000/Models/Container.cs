using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public double AvailableStorage { get; protected set; }
		private List<Box> StoragedBoxes { get; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight) { }

		public static Container CreateContainer()
		{
			return new Container(20, 50, 100, 10000);
		}

		public bool AddBoxToContainer(Box box)
		{
			if (!DoesBoxFitIntoContainer(box))
				return false;

			StoragedBoxes.Add(box);
			AvailableStorage -= box.Volume;
			AddWeight(box.Weight);
			return true;
		}

		public bool DoesBoxFitIntoContainer(Box box)
		{
			return box.Volume < AvailableStorage;
		}

		//public int CountStoragedBoxes()
		//{
		//	return StoragedBoxes.Count;
		//}
	}
}