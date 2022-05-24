using Containers3000.Helpers;

namespace Containers3000.Models
{
	public class Box : StorageBase
	{

		public Box(int height, int width, int length, int weight) : base(height, width, length, weight) { }

		public static Box CreateBox()
		{
			int height = GeneratingHelper.GetRng(25, 51);
			int width = GeneratingHelper.GetRng(25, 51);
			int length = GeneratingHelper.GetRng(25, 51);
			int weight = GeneratingHelper.GetRng(250, 501);

			return new Box(height, width, length, weight);
		}

		public static Box GetBox(Box nullBox)
		{
			Box box;
			if (nullBox == null)
				box = CreateBox();
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
