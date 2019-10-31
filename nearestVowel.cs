int[] nearestVowel(string s)
{
    s = s.ToLower();
    int[] rtInt = s.Select((c, i) => i).ToArray();
    int count = rtInt.Count();
    var tmp1 = 0;
    var tmp2 = 0;
    for (int i = 0; i < count; i++)
    {
        if (s[i] == 'a' || s[i] == 'o' || s[i] == 'u' || s[i] == 'i' || s[i] == 'e')
        {
            if(i != count -1)
            {
                rtInt[i] = 0;
                tmp1 = tmp2;
                tmp2 = i;
                int tmp = tmp2 - tmp1 - 1;
                int sdem = (tmp + 1) / 2;
                int dem = -tmp / 2;
                int sodu = (sdem + dem);
                while (tmp != 0)
                {
                    rtInt[i - tmp] = sdem - Math.Abs(dem) + 1 - sodu;
                    dem++;
                    tmp--;
                }
            }
            else
            {
                int x = 0;
                while (tmp2 != count -1)
                {
                    rtInt[tmp2 + 1] = ++x;
                    tmp2++;
                }
            }
        }
    }
    if(tmp2 == 0)
    {
        return rtInt.Select(t => -1).ToArray();
    }
    return rtInt; 
}