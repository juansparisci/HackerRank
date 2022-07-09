namespace Problems.Problem_Solving.Algorithms.Strings;

public class SuperReducedString
{
    /*
 * Complete the 'superReducedString' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts STRING s as parameter.
 */

    public static string superReducedString(string s)
    {
        for (var i = 0; i < s.Length - 1; i++)
            if (s[i] == s[i + 1])
            {
                s = s.Remove(i, 2);
                i = i - (i >= 1 ? 2 : 1);
            }

        return s.Length > 0 ? s : "Empty String";
    }
}