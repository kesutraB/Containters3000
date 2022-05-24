using System;
using System.Collections.Generic;
using Containers3000.Helpers;

namespace Containers3000.Models
{
	public abstract class StorageBase
	{
		public Guid StorageId { get; }
		public StorageState State { get; set; } = StorageState.None;
		public int Height { get; protected set; }
		public int Width { get; protected set; }
		public int Length { get; protected set; }
		public int Weight { get; protected set; }
		public int LoadedWeight { get; set; }
		public double Volume { get; protected set; }
		public double AvailableVolume { get; protected set; }

		protected StorageBase(int height, int width, int length, int weight)
		{
			StorageId = Guid.NewGuid();
			Height = height;
			Width = width;
			Length = length;
			Weight = weight;
			LoadedWeight = 0;
			Volume = height * width * length;
			AvailableVolume = Volume;
		}

		#region Managing generated ids

		public static string GetId(List<string> generatedIds)
		{
			string id = "";

			do
			{
				int x = GeneratingHelper.GetRng(0, 10);
				int y = GeneratingHelper.GetRng(10, 100);

				id = x + "-" + y;
			} while (CheckGeneratedId(id, generatedIds));

			generatedIds.Add(id);
			return id;
		}

		public static bool CheckGeneratedId(string id, List<string> generatedIds)
		{
			return generatedIds.Contains(id);
		}

		#endregion

		#region Managing storage

		public string ReturnStorageState(StorageBase storage)
		{
			if (storage.State == StorageState.Full)
				return "Full";

			return "Not Full";
		}

		public void CheckStorageState(StorageBase smallerStorage, StorageBase biggerStorage)
		{
			if (biggerStorage.DoesSmallerStorageFitIntoBiggerStorage(smallerStorage))
				biggerStorage.State = StorageState.NotFull;
			else if (!biggerStorage.DoesSmallerStorageFitIntoBiggerStorage(smallerStorage))
				biggerStorage.State = StorageState.Full;
		}

		public bool AddSmallerStorageToBiggerStorage(StorageBase storage, List<StorageBase> storageInside)
		{
			if (!DoesSmallerStorageFitIntoBiggerStorage(storage))
				return false;

			storageInside.Add(storage);
			AvailableVolume -= storage.Volume;
			AddWeight(storage.Weight);
			return true;
		}

		public bool DoesSmallerStorageFitIntoBiggerStorage(StorageBase storage)
		{
			return storage.Volume < AvailableVolume;
		}

		public int CountSmallerStorage(List<StorageBase> storageInside)
		{
			return storageInside.Count;
		}

		public void AddWeight(int newWeight)
		{
			LoadedWeight += newWeight;
		}

		#endregion
	}
}