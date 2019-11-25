int crossingSum(int[][] matrix, int a, int b) {
    int sumA = matrix[a].Sum();
    int sumB = 0;
    for(int i = 0 ; i <= matrix.Length - 1; i++)
    {
        sumB += matrix[i][b];
    }
    
    return sumA + sumB - matrix[a][b];
}
