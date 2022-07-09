using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Dynamic_Programming;
using Problems.Problem_Solving.Algorithms.Dynamic_Programming.FibonacciModified;

namespace Tests.Problem_Solving.Algorithms.Dynamic_Programming;

// https://www.hackerrank.com/challenges/fibonacci-modified/
public class FibonacciModifiedTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(27, 0,1,6)]
    [TestCase(5, 0,1,5)]
    public void Test1(int expectedResult, int t1, int t2, int n)
    {
      
           
        
        var ret = FibonacciModified2.fibonacciModified(t1,t2,n);

        ret.Should().Be(((BigInteger)expectedResult));
    }
}