using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Data_Structures.Stack;
using Problems.Problem_Solving.Data_Structures.Stack.LargestRectangle;

namespace Tests.Problem_Solving.Data_Structures.Stack;

// https://www.hackerrank.com/challenges/largest-rectangle/problem
public class LargestRectangleTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(9,
        1, 2, 3, 4, 5)]
    [TestCase(6,
        2, 3, 1, 2, 1, 3)]
    [TestCase(12,
        12, 3, 2, 2, 4, 4, 1, 1, 1)]
    [TestCase(38,
        9, 8, 8, 2, 3, 2, 1, 6, 4, 5, 1, 2, 4, 5, 7, 7, 7, 3, 7, 7, 2, 1, 1, 1, 1, 1, 1, 1, 2, 4, 5, 9, 9, 9, 3, 7, 7, 2)]
    public void Test1(long expectedResult, params int[] h)
    {
        var ret = LargestRectangle.largestRectangle(h.ToList());

        ret.Should().Be(expectedResult);
    }
}