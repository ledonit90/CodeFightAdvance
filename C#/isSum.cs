bool isSum(int value) {
    double n=(Math.Sqrt(1+8*value) - 1)/2;
    return n==Math.Floor(n);
}