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
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string superReducedString(string s)
    {
        for (int i = 0; i < s.Length-1; i++)
        {
            if (s[i] == s[i + 1])
            {
                s = s.Remove(i, 2);
                i= i - (( i >= 1 ) ? 2 : 1 );
            }
        }

        return (s.Length > 0) ? s : "Empty String";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
     
          string result = Result.superReducedString("abba");

       Console.WriteLine(result);
    }
}