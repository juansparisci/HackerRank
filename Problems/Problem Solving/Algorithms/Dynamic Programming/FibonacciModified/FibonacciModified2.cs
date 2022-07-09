using System.Numerics;

namespace Problems.Problem_Solving.Algorithms.Dynamic_Programming.FibonacciModified;

// A second solution for the problem, using a recursive function instead of a loop
public class FibonacciModified2
{
    public static BigInteger fibonacciModified(int t1, int t2, int n)
    {
        return getCalculateFibonacci(3,t1,t2,n);
    }

    public static BigInteger getCalculateFibonacci(int currentPosition, BigInteger t1, BigInteger t2, int n)
    {
        
        
        BigInteger result =  t1 + (t2 * t2);
        
        
        if (currentPosition < n)
        {
            currentPosition++;
            result = getCalculateFibonacci(currentPosition, t2,result, n);
        }
        
        return result;
    }
}