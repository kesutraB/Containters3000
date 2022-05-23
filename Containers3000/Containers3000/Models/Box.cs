namespace Containers3000.Models
{
	public class Box : StorageBase
	{

		public Box(int height, int width, int length, int weight) : base(height, width, length, weight) { }

		public static Box GenerateBoxParameters()
		{
			int height = Helper.GetRng(25, 51);
			int width = Helper.GetRng(25, 51);
			int length = Helper.GetRng(25, 51);
			int weight = Helper.GetRng(250, 501);

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
