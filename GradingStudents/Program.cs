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
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> resultGrades = new List<int>();
        for(int i = 0; i < grades.Count; i++)
        {
            GradingStrategy gradingStrategy;
            if (grades[i] < 38)
            {
                gradingStrategy = new LowerThan38();
            }
            else
            {
                gradingStrategy = new HigherThan37();
            }
            resultGrades.Add(gradingStrategy.GetGrade(grades[i]));
        }

        return resultGrades;
    }

}

abstract class GradingStrategy
{
    public abstract int GetGrade(int grade);
}

class LowerThan38 : GradingStrategy
{
    public override int GetGrade(int grade)
    {
        return grade;
    }
}
class HigherThan37 : GradingStrategy
{
    public override int GetGrade(int grade)
    {
        int nextMultiple = this.getNext5Multiple(grade);
        if ((nextMultiple - grade ) <= 2)
        {
            return nextMultiple;
        }
        else
        {
            return grade;
        }
    }

    private int getNext5Multiple(int grade)
    {
        int result = grade;
        while ( (result % 5) != 0)
        {
            result++;
        }

        return result;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
       
     /*   int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }
*/
        List<int> grades = new List<int>(){ 73, 67, 38, 33 };
        
        List<int> result = Result.gradingStudents(grades);

        Console.WriteLine(String.Join("\n", result));

    }
}