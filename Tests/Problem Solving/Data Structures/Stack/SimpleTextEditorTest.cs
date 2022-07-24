using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Problems.Problem_Solving.Data_Structures.Stack;
using Tests.Services;

namespace Tests.Problem_Solving.Data_Structures.Stack;

// https://www.hackerrank.com/challenges/simple-text-editor/problem
public class SimpleTextEditorTest : TestBase
{
    [SetUp]
    public void Setup()
    {
    }

 
    [TestCase("c y a", 8,
        "1 abc", "3 3", "2 3", "1 xy", "3 2","4", "4", "3 1")]
    public void Test1(string expectedResult, int Q, params string[] operations)
    {
        List<char> expRes = ParseAll<char>(expectedResult).ToList();
        
        var ret = SimpleTextEditor.GetOutputs(operations.ToList());

        ret.Should().BeEquivalentTo(expRes);
    }
}