using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Implementation;

namespace Tests.Problem_Solving.Algorithms.Implementation;

// https://www.hackerrank.com/challenges/apple-and-orange/problem
public class AppleAndOrangeTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("1 1", 7, 11, 5, 15)]
    public void Test1(string expectedResult, int s, int t, int a, int b)
    {
        var apples = new List<int> {-2, 2, 1};
        var oranges = new List<int> {5, -6};


        var ret = AppleAndOrange.countApplesAndOranges(s, t, a, b, apples, oranges);

        (ret.Item1 + " " + ret.Item2).Should().Be(expectedResult);
    }
}