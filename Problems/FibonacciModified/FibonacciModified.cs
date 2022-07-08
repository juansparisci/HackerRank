using System.Numerics;

namespace Problems.FibonacciModified;

public class FibonacciModified
{
    // https://www.hackerrank.com/challenges/fibonacci-modified/
    public static BigInteger fibonacciModified(int t1, int t2, int n)
    {
        BigInteger[] calculatedValues =  new BigInteger[n];
        calculatedValues[0] = t1;
        calculatedValues[1] = t2;
        for (int i = 2; i < n; i++)
        {
            // 0 + 1 ^ 2 = 1 (i2)
            // 1 + 1 ^ 2 = 2 (i3)
            // 1 + 2 ^ 2 = 5 (i4)
            
            calculatedValues[i] = calculatedValues[i - 2] + (calculatedValues[i-1]*calculatedValues[i-1]);
        }
        
        return calculatedValues[n - 1];
    }
}