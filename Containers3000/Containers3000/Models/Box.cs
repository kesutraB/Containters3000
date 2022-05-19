using System;

namespace Containers3000.Models
{
	public class Box : StorageBase
	{
		public Guid BoxId { get; protected set; }

		public Box(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			BoxId = Guid.NewGuid();
		}

		public override string ToString()
		{
			return ($"Box weighs {Weight} kg and has a volume of {Volume} cm3.");
		}
	}
}
