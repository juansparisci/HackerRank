namespace Problems.Problem_Solving.Algorithms.Dynamic_Programming.TheCoinChangeProblem;

public class TheCoinChangeProblem
{
    private static Dictionary<Tuple<long, long>, long>? _calculatedWays;
    

    public static ulong GetWays(int n, List<long> c)
    {
        _calculatedWays = new Dictionary<Tuple<long, long>, long>();
        ulong result = 0;
        var coinsOrdered = c.Where(w => w <= n).OrderByDescending(x => x).ToArray();

        for (var i = 0; i < coinsOrdered.Length; i++)
        {
            var coin = coinsOrdered[i];
            result += (ulong)WaysToGetChange(n, coin, i, coinsOrdered);
        }


        return result;
    }

    //returns the number of ways to get change for a total given and specific coins
    private static long WaysToGetChange(long total, long currentCoin, int currentCoinIndex, long[] coins)
    {
        // if the coin is higher than it is not possible to provide change using it
        // so returns 0
        if (currentCoin > total)
        {
            return 0;
        }


        //check if the value has been calculated to avoid doing the same task more than once
        if (_calculatedWays.TryGetValue(new Tuple<long, long>(currentCoin, total),
                out var valueAlreadyCalculated))
        {
            return valueAlreadyCalculated;
        }

        // define ways at 0
        long ways = 0;
        //quantity of the coin that fits in the total amount
        var quantityOfCurrentCoin = total / currentCoin;
        //remainder after using the current coin
        var remainder = total % currentCoin;


        //One case found! remained is 0 and uses at least 1 coin
        if (remainder == 0 && quantityOfCurrentCoin > 0) ways++;


        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (quantityOfCurrentCoin > 1 || remainder >= 1)
        {
            for (var i = currentCoin * (quantityOfCurrentCoin - 1); i >= currentCoin; i -= currentCoin)
            {
                var newTotal = total - i;
                var tempCurrentCoinIndex = currentCoinIndex;
                while (tempCurrentCoinIndex < coins.Length - 1)
                {
                    tempCurrentCoinIndex++;
                    ways += WaysToGetChange(newTotal, coins[tempCurrentCoinIndex], tempCurrentCoinIndex, coins);
                }
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (remainder >= 1)
            {
                var tempCurrentCoinIndex = currentCoinIndex;
                while (tempCurrentCoinIndex < coins.Length - 1)
                {
                    tempCurrentCoinIndex++;
                    ways += WaysToGetChange(remainder, coins[tempCurrentCoinIndex], tempCurrentCoinIndex, coins);
                }
            }
        }


        _calculatedWays.TryAdd(new Tuple<long, long>(currentCoin, total), ways);
        return ways;
    }
}