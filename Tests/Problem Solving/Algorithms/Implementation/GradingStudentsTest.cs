using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Algorithms.Implementation;

namespace Tests.Problem_Solving.Algorithms.Implementation;

// https://www.hackerrank.com/challenges/grading/problem
public class GradingStudentsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("75 67 40 33", 73, 67, 38, 33)]
    public void Test1(string expectedResult, params int[] grades)
    {
        string.Join(' ', GradingStudents.gradingStudents(grades.ToList())).Should().Be(expectedResult);
    }
}