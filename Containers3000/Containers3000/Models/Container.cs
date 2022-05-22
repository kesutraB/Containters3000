using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public double AvailableStorage { get; protected set; }
		private List<Box> StoragedBoxes { get; set; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			AvailableStorage = Volume;
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
			AvailableStorage -= box.Volume;
			AddWeight(box.Weight);
			return true;
		}

		public bool DoesBoxFitIntoContainer(Box box)
		{
			System.Console.WriteLine(box.ToString());
			return box.Volume < AvailableStorage;
		}

		public int CountStoragedBoxes()
		{
			return StoragedBoxes.Count;
		}
	}
}