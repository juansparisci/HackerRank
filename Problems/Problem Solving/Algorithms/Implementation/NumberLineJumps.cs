namespace Problems.Problem_Solving.Algorithms.Implementation;

public class NumberLineJumps
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
        var velA = x1 < x2 ? v1 - v2 : v2 - v1;

        return velA > 0 && Math.Abs(x1 - x2) % velA == 0 ? "YES" : "NO";
    }

    public static string kangarooWhenAndWhere(int x1, int v1, int x2, int v2)
    {
        var t = (x2 - x1) / (double) (v1 - v2);
        if (double.IsNaN(t)) return x1 == x2 ? "YES" : "NO";
        var where = x1 + t * v1;
        return t > 0 && t % 1 == 0 ? "YES" : "NO";
    }
}