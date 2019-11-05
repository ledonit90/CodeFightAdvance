struct ToaDo
{
    public int i;
    public int j;
    public int id;
    public int D;
}
int largestIsland(int[][] map)
{
    int C = 0;
    if (map != null) C = map.Length;
    HashSet<int> oSe = new HashSet<int>();
    Queue<ToaDo> q = new Queue<ToaDo>();
    int mvl = 0;
    int id = 0;
    for (int i = 0; i < C; i++)
    {
        int D = map[i] != null && map[i].Length != 0 ? map[i].Length : 0;
        for (int j = 0; j < D; j++)
        {
            id = id + 1;
            if (map[i][j] == 1 && !oSe.Contains(id))
            {
                q.Enqueue(new ToaDo { i = i, j = j,id = id , D = D });
                int oldCount = oSe.Count;
                while (q.Count() != 0)
                {
                    var x = q.Dequeue();
                    if(x.j <= x.D - 1 && x.j >= 0 && x.i >= 0 && x.i <= C - 1)
                    {
                        if (!oSe.Contains(x.id) && map[x.i][x.j] == 1)
                        {
                            oSe.Add(x.id);
                            q.Enqueue(new ToaDo { i = x.i, j = x.j - 1, id = x.id - 1,D = x.D});
                            q.Enqueue(new ToaDo { i = x.i, j = x.j + 1, id = x.id + 1, D = x.D });
                            if (x.i < C - 1)
                            {
                                int D1 = map[x.i + 1].Length;
                                q.Enqueue(new ToaDo { i = x.i + 1, j = x.j + 1, id = x.id + x.D + 1, D = D1 });
                                q.Enqueue(new ToaDo { i = x.i + 1, j = x.j,     id = x.id + x.D    , D = D1 });
                                q.Enqueue(new ToaDo { i = x.i + 1, j = x.j - 1, id = x.id + x.D - 1, D = D1 });
                            }
                            if (x.i > 0)
                            {
                                int D2 = map[x.i - 1].Length;
                                q.Enqueue(new ToaDo { i = x.i - 1, j = x.j + 1, id = x.id - D2 + 1, D = D2 });
                                q.Enqueue(new ToaDo { i = x.i - 1, j = x.j    , id = x.id - D2,     D = D2 });
                                q.Enqueue(new ToaDo { i = x.i - 1, j = x.j - 1, id = x.id - D2 - 1, D = D2 });
                            }
                        }
                    }
                }
                int newsCount = oSe.Count;
                int nel = newsCount - oldCount;
                mvl = nel > mvl ? nel : mvl;
            }
        }
    }
    return mvl;
}