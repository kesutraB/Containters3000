using System;

namespace Containers3000.Models
{
	public class Container : StorageBase
	{
		public Guid ContainerId { get; protected set; }

		public Container(int height, int width, int length, int weight) : base(height, width, length, weight)
		{
			ContainerId = Guid.NewGuid();
		}

		public void PrintRemainingStorage()
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"Storage space remaining: {this.Volume}");
			Console.ResetColor();
		}

		public void AddBoxToContainer(Box box)
		{
			SubtractBoxVolume(box);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Box added.");
			Console.ResetColor();
		}

		public void DontAddBoxToContainer(Box box)
		{
			AddBoxVolume(box);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Box not added - Container is too full.");
			Console.ResetColor();
		}

		#region Helpers

		public void AddBoxVolume(Box box)
		{
			this.Volume += box.Volume;
		}

		public void SubtractBoxVolume(Box box)
		{
			this.Volume -= box.Volume;
		}

		public bool DoesBoxFitContainer(Box box)
		{
			if (box.Volume > this.Volume)
				return true;

			return false;
		}

		public static Box GenerateBoxParameters()
		{
			int height = GetRNG(10, 50);
			int width = GetRNG(10, 50);
			int length = GetRNG(10, 50);
			int weight = GetRNG(10, 50);

			return new Box(height, width, length, weight);
		}

		public static int GetRNG(int minValue, int maxValue)
		{
			Random random = new Random();
			return random.Next(minValue, maxValue);
		}

		#endregion
	}
}