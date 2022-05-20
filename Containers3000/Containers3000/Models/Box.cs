using System;

namespace Containers3000.Models
{
	public class Box : StorageBase
	{
		public Guid BoxId { get; protected set; }

		public Box(int height, int width, int length, int weight) : base(height, width, length, weight) { }

		public static Box GenerateBoxParameters()
		{
			int height = Helper.GetRng(10, 50);
			int width = Helper.GetRng(10, 50);
			int length = Helper.GetRng(10, 50);
			int weight = Helper.GetRng(10, 50);

			return new Box(height, width, length, weight);
		}

		public static Box GetBox(Box nullBox)
		{
			Box box;
			if (nullBox == null)
				box = GenerateBoxParameters();
			else
				box = nullBox;

			return box;
		}

		public override string ToString()
		{
			return ($"Box weighs {Weight} kg and has a volume of {Volume} cm3.");
		}
	}
}
