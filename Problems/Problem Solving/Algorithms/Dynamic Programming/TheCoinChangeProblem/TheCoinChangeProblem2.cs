namespace Problems.Problem_Solving.Algorithms.Dynamic_Programming.TheCoinChangeProblem;

//Better solution. Faster and neater code
public class TheCoinChangeProblem2
{
    public static ulong GetWays(int n, List<long> c)
    {
        ulong ways = 0;
        var coinsOrdered = c.Where(w => w <= n).OrderBy(x => x).ToArray();
        List<Coin> coins = new List<Coin>(); 
        
        for (var i = 0; i < coinsOrdered.Length; i++)
        {
            var coinValue = coinsOrdered[i];
            Coin coin = new Coin(coinValue,coins);
            coins.Add(coin);
            ways += coin.WaysToGetChange(n);
        }

        
        return ways;
    }
}

public class Coin
{
    private readonly long _value;
    private readonly List<Coin> _smallerCoins;
    private Dictionary<long, ulong> _calculatedWays;
    public Coin(long value, List<Coin> coins)
    {
        _calculatedWays = new Dictionary<long, ulong>();
        _smallerCoins = new List<Coin>();
        _value = value;
        _smallerCoins.AddRange(coins.Where(c=> c._value < _value ));
    }

    public long Value
    {
        get
        {
            return _value;
        }
    }

    public ulong WaysToGetChange(long amount)
    {
        //if the coin is bigger than the amount, it is not possible giving change using this coin
        if (amount < _value)
        {
            return 0;
        }
        
        //if the change giving an amount was already calculated, returns the calculated value
        //to avoid doing more than one time the same calculation.
        if (_calculatedWays.TryGetValue(amount, out var ways))
        {
            return ways;
        }
        
        //if the ways to give change has not been calculated yet, call the method to calculate them
        return calculateWays(amount);
    }

    private ulong calculateWays(long amount)
    {
        ulong ways = 0;
        var remainder = amount % _value;
        var quantityOfThis = amount / _value;
        
        if (quantityOfThis > 0 && remainder == 0)
        {
            ways++;
        }

        for (int i = 0; i < quantityOfThis; i++)
        {
            long newAmount = i * _value + remainder;
            _smallerCoins.ForEach(coin =>
            {
                ways += coin.WaysToGetChange(newAmount);
            } );
        }
        


        _calculatedWays.TryAdd(amount, ways);
        return ways;
    }
    
}

public class CoinsList
{
    private static CoinsList _instance;
    private CoinsList(){}

    public static CoinsList GetInstance()
    {
        return _instance ?? (_instance = new CoinsList());
    } 
}