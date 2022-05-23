using System;
using System.Collections.Generic;

namespace Containers3000
{
	public class Helper
	{
		public static int GetRng(int minValue, int maxValue)
		{
			Random random = new Random();
			return random.Next(minValue, maxValue);
		}

		public static string GetId(List<string> generatedIds)
		{
			string id = "";

			do
			{
				int x = Helper.GetRng(0, 10);
				int y = Helper.GetRng(10, 100);

				id = x + " - " + y;
			} while (CheckGeneratedId(id, generatedIds));

			generatedIds.Add(id);
			return id;
		}

		public static bool CheckGeneratedId(string id, List<string> generatedIds)
		{
			return generatedIds.Contains(id);
		}
	}
}