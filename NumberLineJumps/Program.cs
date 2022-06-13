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

class Result
{

    /*
     * Complete the 'kangaroo' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER v1
     *  3. INTEGER x2
     *  4. INTEGER v2
     */

    public static string kangaroo(int x1, int v1, int x2, int v2)
    {
        int velA = (x1 < x2) ? (v1 - v2) : (v2 - v1);

        return ( (velA>0) && (Math.Abs(x1 - x2) % velA == 0) ) ? "YES" : "NO";
    }

    public static string kangarooWhenAndWhere(int x1, int v1, int x2, int v2)
    {
        
            double t = (double)(x2 - x1) / (double)(v1 - v2);
            if (Double.IsNaN(t))
            {
                return (x1 == x2) ? "YES" : "NO";
            }
            double where = x1 + t * v1;
            return t > 0 && t % 1 == 0 ? "YES" : "NO";
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int x1 = 1;

        int v1 = 1;

        int x2 = 2;

        int v2 = 1;

        string result = Result.kangarooWhenAndWhere(x1, v1, x2, v2);

        Console.WriteLine(result);

    }
}