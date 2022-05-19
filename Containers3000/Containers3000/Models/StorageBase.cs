
namespace Containers3000.Models
{
	public abstract class StorageBase
	{
		public int Height { get; protected set; }
		public int Width { get; protected set; }
		public int Length { get; protected set; }
		public int Weight { get; protected set; }
		public double Volume { get; protected set; }

		protected StorageBase(int height, int width, int length, int weight)
		{
			Height = height;
			Width = width;
			Length = length;
			Weight = weight;
			Volume = height * width * length;
		}
	}
}