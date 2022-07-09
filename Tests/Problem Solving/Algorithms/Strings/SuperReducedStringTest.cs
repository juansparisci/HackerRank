using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Strings;

namespace Tests.Problem_Solving.Algorithms.Strings;
// https://www.hackerrank.com/challenges/reduced-string/problem
public class SuperReducedStringTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("abd","aaabccddd")]
    [TestCase("Empty String","aa")]
    [TestCase("Empty String","baab")]
    public void Test1(string expectedResult, string s)
    {
       SuperReducedString.superReducedString(s).Should().Be(expectedResult);
    }
}