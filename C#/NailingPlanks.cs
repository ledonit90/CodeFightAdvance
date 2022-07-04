public static int solution(int[] A, int[] B, int[] C)
        {
            // two dimension array to save the original index of array C
            int[][] sortedNail = new int[C.Length][];
            for (int i = 0; i < C.Length; i++)
            {
                sortedNail[i] = new int[2] { C[i], i };
            }

            Array.Sort(sortedNail, (int[] x, int[] y) => x[0] - y[0]);

            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result = getMinIndex(A[i], B[i], sortedNail, result);
                if (result == -1) return -1;
            }
            return result + 1;
        }

        private static int getMinIndex(int startValue, int endValue, int[][] sortedList, int preIndex)
        {
            int min = 0;
            int max = sortedList.Length - 1;
            int minIndex = -1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (sortedList[mid][0] > endValue)
                {
                    max = mid - 1;
                }
                else if (sortedList[mid][0] < startValue)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                    minIndex = mid;
                }
            }

            if (minIndex == -1)
            {
                return -1;
            }
            int originMinIndex = sortedList[minIndex][1];
            for(int i = minIndex; i < sortedList.Length; i++)
            {
                if (sortedList[i][0] > endValue) break;
                if (originMinIndex > sortedList[i][1]) originMinIndex = sortedList[i][1];
                if (preIndex >= originMinIndex) return preIndex;
            }
            return originMinIndex;
        }