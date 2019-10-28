int largestIsland(int[][] map)
{
    int C = map.Length;
    HashSet<int> oldSearch = new HashSet<int>();
    int maxvalue = 0;
    int id = 0;
    for (int i = 0; i < C; i++)
    {
        int D = map[i] != null && map[i].Length != 0? map[i].Length : 0;
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
    if(j<= D-1 && j >= 0 && i >= 0 && i <= C -1  && !oldSearch.Contains(id))
    {
        if (map[i][j] == 1)
        {
            oldSearch.Add(id);
            SearchItem(oldSearch, map, id - 1, i, j - 1, D, C);
            SearchItem(oldSearch, map, id + 1, i, j + 1, D, C);

            if (i > 0 && map[i-1] != null)
            {
                int D1 = map[i - 1].Length;
                SearchItem(oldSearch, map, id - D1 - 1, i - 1, j - 1, D1, C);
                SearchItem(oldSearch, map, id - D1, i - 1, j, D1, C);
                SearchItem(oldSearch, map, id - D1 + 1, i - 1, j + 1, D1, C);
            }
            if (i < C - 1 && map[i+1] != null)
            {
                int D2 = map[i + 1].Length;
                SearchItem(oldSearch, map, id + D - 1, i + 1, j - 1, D2, C);
                SearchItem(oldSearch, map, id + D, i + 1, j, D2, C);
                SearchItem(oldSearch, map, id + D + 1, i + 1, j + 1, D2, C);
            }
        }
    }   
}