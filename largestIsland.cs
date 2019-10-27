int largestIsland(int[][] map)
{
    int C = map.Length;
    HashSet<int> oldSearch = new HashSet<int>();
    int maxvalue = 0;
    int id = 0;
    for (int i = 0; i < C; i++)
    {
        int D = map[i].Length;
        for (int j = 0; j < D; j++)
        {
            id=id+1;
            if (map[i][j] == 1 && !oldSearch.Contains(id))
            {
                int oldCount = oldSearch.Count;
                SearchItem(oldSearch, map, id, i, j, D, C);
                int newsCount = oldSearch.Count;
                int numberElement = newsCount - oldCount;
                maxvalue = numberElement > maxvalue ? numberElement : maxvalue;
            }
        }
    }
    return maxvalue;
}

void SearchItem(HashSet<int> oldSearch, int[][] map,int id, int i, int j, int D, int C)
{
    oldSearch.Add(id);    
    if (i != 0)
    {
        int D1 = map[i - 1].Length;
        if (j < D1 - 1)
        {
            if(map[i - 1][j + 1] == 1 && !oldSearch.Contains(id - D1 + 1))
            {
                SearchItem(oldSearch, map, id - D1 + 1, i - 1, j + 1, D1, C);
            }
        }
        if (j <= D1 && j != 0)
        {
            if(map[i - 1][j - 1] == 1 && !oldSearch.Contains(id - D1 - 1))
            {
                SearchItem(oldSearch, map, id - D1 - 1, i - 1, j - 1, D1, C);
            }
        }
        if (j <= D1 - 1)
        {
            if(map[i - 1][j] == 1 && !oldSearch.Contains(id - D1))
            {
                SearchItem(oldSearch, map, id - D1, i - 1, j, D1, C);
            }
        }
    }
    if (j != D - 1)
    {
        if(map[i][j + 1] == 1 && !oldSearch.Contains(id + 1))
        {
            SearchItem(oldSearch, map, id + 1, i, j + 1, D, C);
        }
    }
    if (j != 0)
    {
        if(map[i][j - 1] == 1 && !oldSearch.Contains(id - 1))
        {
            SearchItem(oldSearch, map, id - 1, i, j - 1, D, C);
        }
    }    
    if (i < C - 1)
    {
        int D2 = map[i + 1].Length;
        if (j < D2 - 1)
        {
            if(map[i + 1][j + 1] == 1 && !oldSearch.Contains(id + D + 1))
            {
                SearchItem(oldSearch, map, id + D + 1, i + 1, j + 1, D2, C);
            }
        }
        if (j <= D2 && j != 0)
        {
            if(map[i + 1][j - 1] == 1 && !oldSearch.Contains(id + D - 1))
            {
                SearchItem(oldSearch, map, id + D - 1, i + 1, j - 1, D2, C);
            }
        }
        if (j <= D2 - 1)
        {
            if (map[i + 1][j] == 1 && !oldSearch.Contains(id + D))
            {
                SearchItem(oldSearch, map, id + D, i + 1, j, D2, C);
            }
        }
    }
}