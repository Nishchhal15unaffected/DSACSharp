namespace Hashmap
{
	public class pairMap
	{
		public string key;
		public string value;
		public pairMap(string key, string value)
		{
			this.key = key;
			this.value = value;
		}
	}
	class HashMap
	{
		int capacity = 0;
		int size = 0;
		pairMap[] map = new pairMap[2];
		public HashMap()
		{
			capacity = 2;
			for (int i =0; i<capacity; i++)
			{
				map[i] = null;
			}
		}
		private int Hashing (string key)
		{
			int index = 0;
			foreach(char c in key)
			{
				index += (int)c;
			}
			return index;
		}

		public void Put(string key, string value)
		{
			int index = Hashing(key);
			while (true)
			{
				if (map[index] == null)
				{
					map[index] = new pairMap(key, value);
					size++;
					if (size>= capacity/2)
					{
						ReHashing();
					}
					return;
				}
				else if (map[index].key== key)
				{
					map[index].value = value;
					return;
				}
				index++;
			}
		}

		public string Get(string key)
		{
			int index = Hashing(key);
			while (map[index] != null)
			{
				if (map[index].key == key)
				{
					return map[index].value.ToString() ?? "";
				}
				index++;
			}
			return "";
		}

		private void ReHashing()
		{
			capacity = capacity * 2;
			pairMap[] Oldmap = map;
			map = new pairMap[capacity];
			for (int i =0; i< capacity; i++)
			{
				map[i] = null;
			}

			for (int i = 0; i < capacity; i++)
			{
				if (Oldmap[i] != null)
				{
					Put(Oldmap[i].key, Oldmap[i].value);
				}
			}
		}
	}
}