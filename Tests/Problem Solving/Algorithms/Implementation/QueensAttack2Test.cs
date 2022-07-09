using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Implementation;

namespace Tests.Problem_Solving.Algorithms.Implementation;

// https://www.hackerrank.com/challenges/queens-attack-2/problem
public class QueensAttack2Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(10, 5, 3, 4, 3)]
    public void Test1(int expectedResult, int n, int k, int r_q, int c_q)
    {
        var obstacles = new List<List<int>> {new() {5, 5}, new() {4, 2}, new() {2, 3}};
        QueensAttack2.QueensAttack(n, k, r_q, c_q, obstacles).Should().Be(expectedResult);
    }
}