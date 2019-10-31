public static int[] nearestVowel(string s)
{
    s = s.ToLower();
    int[] rtInt = s.Select((c, i) => i).ToArray();
    int count = rtInt.Count();
    var tmp1 = -1;
    var tmp2 = 0;
    for (int i = 0; i < count; i++)
    {
        if (s[i] == 'a' || s[i] == 'o' || s[i] == 'u' || s[i] == 'i' || s[i] == 'e' || i == count - 1)
        {
            if (i == count - 1 && s[i] != 'a' && s[i] != 'o' && s[i] != 'u' && s[i] != 'i' && s[i] != 'e' )
            {
                int x = 0;
                while (tmp2 != count - 1)
                {
                    rtInt[tmp2 + 1] = ++x;
                    tmp2++;
                }
            }
            else if(tmp1 == -1)
            {
                int x = 0;
                tmp1 = 0;
                rtInt[i] = 0;
                tmp2 = i;
                int vet = tmp2;
                while (vet != 0)
                {
                    rtInt[vet - 1] = tmp2 - vet + 1;
                    vet--;
                }
            }
            else
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
                    if (sodu == 1) rtInt[i - tmp] = sdem - Math.Abs(dem) + 1 - sodu;
                    else
                    {
                        if (dem == 0) dem++;
                        rtInt[i - tmp] = sdem - Math.Abs(dem) + 1;
                    }
                    dem++;
                    tmp--;
                }
            }
        }
    }
    if(tmp1 == -1)
    {
        for (int i = 0; i < count; i++)
        {
            rtInt[i] = -1;
        }
        return rtInt;
    }
    return rtInt; 
}