namespace Problems.GradingStudents;

public class GradingStudents
{
    /*
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        var resultGrades = new List<int>();
        for (var i = 0; i < grades.Count; i++)
        {
            GradingStrategy gradingStrategy;
            if (grades[i] < 38)
                gradingStrategy = new LowerThan38();
            else
                gradingStrategy = new HigherThan37();
            resultGrades.Add(gradingStrategy.GetGrade(grades[i]));
        }

        return resultGrades;
    }
}

internal abstract class GradingStrategy
{
    public abstract int GetGrade(int grade);
}

internal class LowerThan38 : GradingStrategy
{
    public override int GetGrade(int grade)
    {
        return grade;
    }
}

internal class HigherThan37 : GradingStrategy
{
    public override int GetGrade(int grade)
    {
        var nextMultiple = getNext5Multiple(grade);
        if (nextMultiple - grade <= 2)
            return nextMultiple;
        return grade;
    }

    private int getNext5Multiple(int grade)
    {
        var result = grade;
        while (result % 5 != 0) result++;

        return result;
    }
}