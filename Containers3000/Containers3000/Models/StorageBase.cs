using System;

namespace Containers3000.Models
{
	public abstract class StorageBase
	{
		public Guid StorageId { get; }
		public int Height { get; protected set; }
		public int Width { get; protected set; }
		public int Length { get; protected set; }
		public int Weight { get; protected set; }
		public int ContentWeight { get; protected set; }
		public double Volume { get; protected set; }

		protected StorageBase(int height, int width, int length, int weight)
		{
			StorageId = Guid.NewGuid();
			Height = height;
			Width = width;
			Length = length;
			Weight = weight;
			ContentWeight = 0;
			Volume = height * width * length;
		}

		public void AddWeight(int newWeight)
		{
			ContentWeight += newWeight;
		}
	}
}