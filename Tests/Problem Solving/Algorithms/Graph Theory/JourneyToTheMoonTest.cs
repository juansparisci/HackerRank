using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Graph_Theory;
using Tests.Services;

namespace Tests.Problem_Solving.Algorithms.Graph_Theory;

public class JourneyToTheMoonTest : TestBase
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("5 3", 
        "0 1", "2 3", "0 4",
        TestName = "Sample 0",
        ExpectedResult = 6)]
    [TestCase("7 4", 
        "0 1",
            "2 3",
            "4 5",
            "6 1",
        TestName = "Sample 1",
        ExpectedResult = 16)]
    [TestCase("4 1",
        "0 2",
        TestName = "Sample 2",
        ExpectedResult = 5)]
    public int InputTests(string header, params string[] astronauts)
    {
        int n = Parse<int>(header, 0);
        List<List<int>> astronaut = astronauts
            .Select(x => ParseAll<int>(x).ToList()).ToList();

        return JourneyToTheMoon.journeyToMoon(n, astronaut);
    }
}