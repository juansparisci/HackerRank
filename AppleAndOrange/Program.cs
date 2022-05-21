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
        Console.WriteLine(countApples(s,t,a,apples));
        Console.WriteLine(countOranges(s,t,b,oranges));
        
    }

    private static int countApples(int s, int t, int a, List<int> apples)
    {
        int result = 0;

        apples.ForEach((appleDistance) =>
        {
            int appleLocation = a + appleDistance;
            result += (appleLocation >= s && appleLocation <= t) ? 1 : 0;
        });
        return result;
    }
    private static int countOranges(int s, int t, int b, List<int> oranges)
    {
        int result = 0;

        oranges.ForEach((orangeDistance) =>
        {
            int orangeLocation = b + orangeDistance;
            result += (orangeLocation >= s && orangeLocation <= t) ? 1 : 0;
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