namespace Problems.AppleAndOrange;

public class AppleAndOrange
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

    public static Tuple<int, int> countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        var applesInSamsHouse = CountFruitsInSamsHouse(s, t, a, apples);
        var orangesInSamsHouse = CountFruitsInSamsHouse(s, t, b, oranges);
        return new Tuple<int, int>(applesInSamsHouse, orangesInSamsHouse);
    }

    private static int CountFruitsInSamsHouse(int s, int t, int plantLocation, List<int> fruits)
    {
        var result = 0;

        fruits.ForEach(fruitDistance =>
        {
            var fruitLocation = plantLocation + fruitDistance;
            result += fruitLocation >= s && fruitLocation <= t ? 1 : 0;
        });
        return result;
    }
}