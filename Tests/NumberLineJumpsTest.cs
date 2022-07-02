using FluentAssertions;
using NUnit.Framework;
using Problems.NumberLineJumps;

namespace Tests;

// https://www.hackerrank.com/challenges/kangaroo/problem
public class NumberLineJumpsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("NO", 0, 2, 5, 3)]
    [TestCase("YES", 2, 1, 1, 2)]
    [TestCase("YES", 0, 3, 4, 2)]
    public void Test1(string expectedResult, int x1, int v1, int x2, int v2)
    {
        NumberLineJumps.kangarooWhenAndWhere(x1, v1, x2, v2).Should().Be(expectedResult);
    }
}