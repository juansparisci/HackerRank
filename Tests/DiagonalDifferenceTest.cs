using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Problems.DiagonalDifference;

namespace Tests;
// https://www.hackerrank.com/challenges/diagonal-difference/problem
public class DiagonalDifferenceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(15)]
    public void Test1(int expectedResult)
    {
        List<List<int>> arr = new List<List<int>>()
        {
            new List<int>(){11, 2, 4},
            new List<int>(){ 4, 5, 6},
            new List<int>(){10, 8, -12}
        };
        
        DiagonalDifference.diagonalDifference(arr).Should().Be(expectedResult);
    }
}