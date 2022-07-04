using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var dcFibonaccies = FibonacciArray(A.Length + 2);
            Dictionary<int, List<int>> StepWithPosition = new Dictionary<int, List<int>>();

            StepWithPosition.Add(0, new List<int>() { -1 });

            int count = 1;
            while (StepWithPosition.ContainsKey(count - 1) && StepWithPosition[count - 1].Count > 0)
            {
                foreach (int i in StepWithPosition[count - 1])
                {
                    foreach (var k in dcFibonaccies.Keys)
                    {
                        if (i + dcFibonaccies[k] == A.Length)
                        {
                            return count;
                        }
                        else if (i + dcFibonaccies[k] > A.Length)
                        {
                            break;
                        }
                        else if (i + dcFibonaccies[k] < A.Length && A[i + dcFibonaccies[k]] == 1)
                        {
                            if (StepWithPosition.ContainsKey(count))
                            {
                                StepWithPosition[count].Add(i + dcFibonaccies[k]);
                            }
                            else
                            {
                                StepWithPosition.Add(count, new List<int>() { i + dcFibonaccies[k] });
                            }
                        }
                    }
                }
                count++;
            }

            return -1;
        }

        public Dictionary<int, int> FibonacciArray(int maxValue)
        {
            int currentValue = 0;
            var result = new Dictionary<int, int>();
            result.Add(1, 1);
            result.Add(2, 1);
            int count = 2;
            while (currentValue < maxValue)
            {
                count++;
                currentValue = result[count - 1] + result[count - 2];
                if(currentValue <= maxValue) result.Add(count, currentValue);
            }
            return result;
        }
}