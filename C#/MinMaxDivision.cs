public class MinMaxDivision{

	public int solutions( int K, int M,int[] A)
	{
		int min = 0;
		int max = 0;
		foreach(var a in A)
		{
			max += a;
			min = Math.max(a: min, b: a);
		}

		int bestAnswer = max;

		while(min <= max)
		{
			int mid = (min + max)/2;
			int blocks = CheckBlocks(A, mid);
			if(blocks > K)
			{
				min = mid + 1;
			}
			else
			{
				max = mid -1;
				if(mid < bestAnswer)
				{
					bestAnswer = mid;
				}
			}
		}
		return bestAnswer;		
	}
	private int CheckBlocks(int[] A, int guess)
	{
		int blocks = 1;
		int blockSum = 0;
		foreach(var a in A)
		{
			blockSum +=a;
			if(blockSum > guess)
			{
				blockSum = a;
				blocks++;
			}
		}
		return blocks;
	}
}
