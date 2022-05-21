using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Runtime.CompilerServices;

class Result
{

    /*
     * Complete the 'countApplesAndOranges' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER s
     *  2. INTEGER t
     *  3. INTEGER a
     *  4. INTEGER b
     *  5. INTEGER_ARRAY apples
     *  6. INTEGER_ARRAY oranges
     */

    public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        int applesInSamsHouse = 0, orangesInSamsHouse = 0;
        Console.WriteLine(CountFruitsInSamsHouse(s,t,a,apples));
        Console.WriteLine(CountFruitsInSamsHouse(s,t,b,oranges));
        
    }

    private static int CountFruitsInSamsHouse(int s, int t, int plantLocation, List<int> fruits)
    {
        int result = 0;

        fruits.ForEach((fruitDistance) =>
        {
            int fruitLocation = plantLocation + fruitDistance;
            result += (fruitLocation >= s && fruitLocation <= t) ? 1 : 0;
        });
        return result;
    }
  

}

class Solution
{
    public static void Main(string[] args)
    {
        int s = 7, t = 11, a = 5, b = 15;

        List<int> apples = new List<int>() {-2, 2, 1};
        List<int> oranges  = new List<int>(){5, -6};

       
        Result.countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}