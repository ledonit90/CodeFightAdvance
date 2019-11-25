int largestIsland(int[][] map)
{
    int C = map.Length;
    HashSet<int> oSe = new HashSet<int>();
    int mvl = 0;
    int id = 0;
    for (int i = 0; i < C; i++)
    {
        int D = map[i] != null && map[i].Length != 0? map[i].Length : 0;
        for (int j = 0; j < D; j++)
        {
            id=id+1;
            if (map[i][j] == 1 && !oSe.Contains(id))
            {
                int oldCount = oSe.Count;
                SI(oSe, map, id, i, j, D, C);
                int newsCount = oSe.Count;
                int nel = newsCount - oldCount;
                mvl = nel > mvl ? nel : mvl;
            }
        }
    }
    return mvl;
}

void SI(HashSet<int> oSe, int[][] map,int id, int i, int j, int D, int C)
{
    if(j<= D-1 && j >= 0 && i >= 0 && i <= C -1  && !oSe.Contains(id))
    {
        if (map[i][j] == 1)
        {
            oSe.Add(id);
            SI(oSe, map, id - 1, i, j - 1, D, C);
            SI(oSe, map, id + 1, i, j + 1, D, C);

            if (i > 0 && map[i-1] != null)
            {
                int D1 = map[i - 1].Length;
                SI(oSe, map, id - D1 - 1, i - 1, j - 1, D1, C);
                SI(oSe, map, id - D1, i - 1, j, D1, C);
                SI(oSe, map, id - D1 + 1, i - 1, j + 1, D1, C);
            }
            if (i < C - 1 && map[i+1] != null)
            {
                int D2 = map[i + 1].Length;
                SI(oSe, map, id + D - 1, i + 1, j - 1, D2, C);
                SI(oSe, map, id + D, i + 1, j, D2, C);
                SI(oSe, map, id + D + 1, i + 1, j + 1, D2, C);
            }
        }
    }   
}
//https://app.codesignal.com/challenge/y8gs2h5XotJDALspF