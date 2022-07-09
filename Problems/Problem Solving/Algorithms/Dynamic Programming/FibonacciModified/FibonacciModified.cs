using System.Numerics;

namespace Problems.Problem_Solving.Algorithms.Dynamic_Programming.FibonacciModified;

public class FibonacciModified
{
    
    public static BigInteger fibonacciModified(int t1, int t2, int n)
    {
        BigInteger[] calculatedValues =  new BigInteger[n];
        calculatedValues[0] = t1;
        calculatedValues[1] = t2;
        for (int i = 2; i < n; i++)
        {
            calculatedValues[i] = calculatedValues[i - 2] + (calculatedValues[i-1]*calculatedValues[i-1]);
        }
        
        return calculatedValues[n - 1];
    }
}