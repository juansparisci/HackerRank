using System;
using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Problems.FibonacciModified;

namespace Tests;

public class FibonacciModifiedTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(27, 0,1,6)]
    [TestCase(5, 0,1,5)]
    public void Test1(int expectedResult, int t1, int t2, int n)
    {
      
           
        
        var ret = FibonacciModified.fibonacciModified(t1,t2,n);

        ret.Should().Be(((BigInteger)expectedResult));
    }
}