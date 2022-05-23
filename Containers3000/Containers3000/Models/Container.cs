using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public string GeneratedId { get; private set; }
		public double AvailableStorage { get; private set; }
		private List<Box> StoragedBoxes { get; set; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			GeneratedId = GetId();
			AvailableStorage = Volume;
			StoragedBoxes = new List<Box>();
		}

		public List<string> GeneratedIds = new List<string>();

		public static Container CreateContainer()
		{
			return new Container(20, 500, 100, 10000);
		}

		public string GetId()
		{
			string id = "";

			do
			{
				int x = Helper.GetRng(0, 10);
				int y = Helper.GetRng(10, 100);

				id = x + " - " + y;
			} while (CheckGeneratedId(id));

			GeneratedIds.Add(id);
			return id;
		}

		public bool CheckGeneratedId(string id)
		{
			return GeneratedIds.Contains(id);
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

		public int CountStoragedBoxes()
		{
			return StoragedBoxes.Count;
		}
	}
}