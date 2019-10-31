int[] nearestVowel(string s)
{
    s = s.ToLower();
    int[] rtInt = s.Select((c, i) => i).ToArray();
    var x = s.Where(c => c == 'a' || c == 'o' || c == 'u' || c == 'i' || c == 'e').Select((c, i) => i).ToList();
    int count = x.Count;
    if (count == 0) return rtInt.Select(i => { i = -1; return i; }).ToArray();
    AssginInt(rtInt, 0, x[0] - 1, 0);
    for (int i = 1; i <= x.Count -2; i++)
    {
        int m = (x[i + 1] - x[i] + 1) / 2;
        AssginInt(rtInt, x[i]+1, x[i] + m, 1);
        AssginInt(rtInt, x[i] + m + 1, x[i + 1] -1 , 0);
        rtInt[x[i]] = 0;
        rtInt[x[i+1]] = 0;
    }
    AssginInt(rtInt, x[count - 1] + 1, rtInt.Count() -1 , 1);
    return rtInt;
}

void AssginInt(int[] rtInt,int s, int e, int t)
{
    int count = t == 1 ? 1: e - s + 1;
    while(s <= e)
    {
        if(t == 1)
        {
            rtInt[s] = count;
            count++;
        }
        else
        {
            rtInt[s] = count;
            count--;
        }
        s++;
    }
}