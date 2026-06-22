namespace HeapImp
{
	// min heap
	class Heap
	{
		// add at the end
		// replace with parents until parent val is small
		// this we called percolate up
		public void push (List<int> self , int val)
		{
			self.Append(val);
			int i = self.Count-1;
			while (self[i] < self[i/2])
			{
				int temp = self[i];
				self[i] = self[i/2];
				self[i/2] = temp;
				i = i / 2;
			}
		}
		// replace last element with first
		// loop till hight
		// swap right element with parent if right element is in the present and right element is smaller
		// then left element and right element smaller then parent
		// swap left element with parent if left element is smaller then parent 
		// do above till parent is smaller , if parent smaller break the loop
		// this we called percolate down
		public void pop(List<int> self, int val)
		{
			if (self.Count ==1)
			{
				return;
			}
			if (self.Count == 2)
			{
				self.RemoveAt(self.Count - 1);
				return;
			}
			int i = 1;
			int res = self[i];
			self[i] = self[self.Count-1];
			while (self[i*2] < self.Count)
			{
				if (self[i*2+1] < self.Count && self[i * 2 + 1] < self[i*2] && self[i*2+1] < self[i])
				{
					// swap right element
					int temp = self[i];
					self[i] = self[i * 2 + 1];
					i = i * 2 + 1;
				}
				else if (self[i * 2] < self[i])
				{
					// swap left element 
					int temp = self[i];
					self[i] = self[i * 2];
					i = i * 2;
				}
				else
				{
					break;
				}
			}
		}
		// append 0th element and from (length-1)/2 do percolate down till 1th element  
		// means loop from (length-1)/2 to 1 and 
		// loop till hight
		// swap right element with parent if right element is in the present and right element is smaller
		// then left element and right element smaller then parent
		// swap left element with parent if left element is smaller then parent 
		// do above till parent is smaller , if parent smaller break the loop
		public void Heapify (List<int> self)
		{
			self.Append(self[0]);
			int curr = (self.Count-1)/2;
			while(curr > 0)
			{
				int i = curr;
				while (self[i*2]<self.Count)
				{
					if (self[i*2+1]<self.Count && self[i * 2 + 1] < self[i*2] && self[i * 2 + 1] < self[i])
					{
						//swap right
						int temp = self[i];
						self[i] = self[i * 2 + 1];
						i = i * 2 + 1;
					}
					else if (self[i * 2] < self[i])
					{
						// swap left element 
						int temp = self[i];
						self[i] = self[i * 2];
						i = i * 2;
					}
					else
					{
						break;
					}
				}
				curr = curr - 1;
			}
		}
	}
}