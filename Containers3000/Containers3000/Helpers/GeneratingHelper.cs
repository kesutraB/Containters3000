using System;

namespace Containers3000.Helpers
{
	public class GeneratingHelper
	{
		public static int GetRng(int minValue, int maxValue)
		{
			Random random = new Random();
			return random.Next(minValue, maxValue);
		}
	}
}