int[] nearestVowel(string s)
{
    s = s.ToLower();
    int[] rtInt = s.Select((c, i) => i).ToArray();
    var tempList = s.Select((c, i) => new { c = c, i = i }).ToList();
    var x = tempList.Where(k => k.c == 'a' || k.c == 'o' || k.c == 'u' || k.c == 'i' || k.c == 'e').Select(k=>k.i).ToList();
    int count = x.Count;
    if (count == 0) return rtInt.Select(i => { i = -1; return i; }).ToArray();
    AssginInt(rtInt, 0, x[0] - 1, 0);
    for (int i = 0; i <= x.Count -2; i++)
    {
        int m = (x[i + 1] - x[i]) / 2;
        AssginInt(rtInt, x[i]+1, x[i] + m, 1);
        AssginInt(rtInt, x[i] + m + 1, x[i + 1] -1 , 0);
        rtInt[x[i]] = 0;
        rtInt[x[i+1]] = 0;
    }
    AssginInt(rtInt, x[count - 1] + 1, rtInt.Count() -1 , 1);
    return rtInt.Select((c,i) => { if(x.Contains(i)) c = 0; return c; }).ToArray();
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