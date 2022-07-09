using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Dynamic_Programming.TheCoinChangeProblem;

namespace Tests.Problem_Solving.Algorithms.Dynamic_Programming;

// https://www.hackerrank.com/challenges/coin-change/problem
public class TheCoinChangeProblemTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase((ulong)3, 3, 8, 3, 1, 2)]
    [TestCase((ulong)4, 4, 1, 2, 3)]
    [TestCase((ulong)5, 10, 2, 5, 3, 6)]
    [TestCase((ulong)10, 15, 49, 22, 45, 6, 11, 20, 30, 10, 46, 8, 32, 48, 2, 41, 43, 5, 39, 16, 28, 44, 14, 4, 27, 36)]
    [TestCase((ulong)96190959, 166, 5, 37, 8, 39, 33, 17, 22, 32, 13, 7, 10, 35, 40, 2, 43, 49, 46, 19, 41, 1, 12, 11, 28)]
    [TestCase((ulong)64027917156, 245, 16, 30, 9, 17, 40, 13, 42, 5, 25, 49, 7, 23, 1, 44, 4, 11, 33, 12, 27, 2, 38, 24, 28,
        32, 14, 50)]
    [TestCase((ulong)4, 15, 5, 4, 2)]
    [TestCase((ulong)11369893182620127430, 5450, 16, 30, 9, 17, 40, 13, 42, 5, 25, 49, 7, 23, 1, 44, 4, 11, 33, 12, 27, 2, 38, 24, 28,
        32, 14, 50, 100)]
    public void Test1(ulong expectedResult, int n, params long[] c)
    {
        Stopwatch st = new Stopwatch();
        st.Start();
        TheCoinChangeProblem2.GetWays(n, c.ToList()).Should().Be(expectedResult);
        st.Stop();
        Console.WriteLine("elapse ms: "+st.ElapsedMilliseconds);
    }
}