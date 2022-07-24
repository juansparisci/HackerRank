using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Data_Structures.Stack.PoisonousPlants;
using Tests.Services;

namespace Tests.Problem_Solving.Data_Structures.Stack;
// https://www.hackerrank.com/challenges/poisonous-plants/problem
public class PoisonousPlantsTest : TestBase
{
    [SetUp]
    public void Setup()
    {
    }

    
    [TestCase(2, "6 5 8 4 7 10 9")]
    [TestCase(3, "4 3 7 5 6 4 2")]
    [TestCase(3, "6 5 10 4 9 12 10 7 1")]
    [TestCase(3, "3 1 10 7 3 5 6 6")]
    //                            4 3 5 4 2
    //                            4 3 4 2
    //                            4 3 2
    public void Test1(int expectedResult, string pp)
    {
        var h = ParseAll<int>(pp).ToList();
        var ret = PoisonousPlants.poisonousPlants(h.ToList());

        ret.Should().Be(expectedResult);
    }
    [TestCase(49999, "PoisonousPlantTextCase.txt")]
    public void TestFromFile(int expectedResult, string fileName)
    {
        var readedFromFile = ReadFromFile(fileName)[0];
        
        var h = ParseAll<int>( readedFromFile);
        var ret = PoisonousPlants.poisonousPlants(h.ToList());

        ret.Should().Be(expectedResult);
    }
}