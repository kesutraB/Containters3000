using System.Collections.Generic;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public static List<string> ContainerIds = new List<string>();
		public string ContainerId { get; private set; }
		public List<StorageBase> BoxesInside { get; set; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ContainerId = GetId(ContainerIds);
			BoxesInside = new List<StorageBase>();
		}

		public static Container CreateContainer()
		{
			return new Container(20, 100, 500, 1000);
		}

		public static Container GetContainer(Container nullContainer)
		{
			Container container;
			if (nullContainer == null)
				container = CreateContainer();
			else
				container = nullContainer;

			return container;
		}
	}
}