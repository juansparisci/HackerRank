using System.Collections;
using System.Runtime.CompilerServices;

namespace Problems.Problem_Solving.Algorithms.Graph_Theory;

public class JourneyToTheMoon
{
    public static int journeyToMoon(int n, List<List<int>> astronaut)
    {
        int numberOfCombinations = 0;
        var astByCount = GetAstronautsByCountry(n, astronaut);
        int totalAstInPairs = astByCount.Item1;
        Dictionary<int,List<int>> astronautsByCountry = astByCount.Item2;
        int countriesWithOnly1Astronaut = n-totalAstInPairs;
        
        
        for (int i = 0; i < countriesWithOnly1Astronaut; i++)
        {
            astronautsByCountry.Add(astronautsByCountry.Count,new List<int>{-1});
        }
        
        for (int i = 0; i < astronautsByCountry.Count; i++)
        {
            var ci = astronautsByCountry[i].Count;
            for (int j = i + 1; j < astronautsByCountry.Count; j++)
            {
                var cj = astronautsByCountry[j].Count;
                numberOfCombinations += ci * cj;
            }

            if (astronautsByCountry.Count < 2)
            {
                numberOfCombinations = 2 + (countriesWithOnly1Astronaut + 1);
            }
            
        }
      

        
        return numberOfCombinations;
    }

    private static Tuple<int,Dictionary<int,int>> GetAstronautsByCountry(int n, List<List<int>> astronauts)
    {
        //astrId,countryId
        Dictionary<int,int> totalAst = new Dictionary<int, int>();
        
        //countryId,astrList
        Dictionary<int,List<int>> countries = new Dictionary<int, List<int>>();

        int newCountryId = 0;
        for (int i = 0; i < astronauts.Count; i++)
        {
            var pair = astronauts[i];

            var ast1Found = totalAst.TryGetValue(pair[0], out var countryAst1);
            var ast2Found = totalAst.TryGetValue(pair[1], out var countryAst2);
            
            if (ast1Found && ast2Found) continue;
            
            if (ast1Found && !ast2Found)
            {
                if (totalAst.TryAdd(pair[1], countryAst1))
                {
                    if (countries.TryGetValue(countryAst1, out var astronautsInCountry))
                    {
                        astronautsInCountry.Add(pair[1]);
                    }
                }
            }
            if (ast2Found && !ast1Found  ) 
            {
                if (totalAst.TryAdd(pair[0], countryAst2))
                {
                        if (countries.TryGetValue(countryAst2, out var astronautsInCountry))
                        {
                            astronautsInCountry.Add(pair[0]);
                        }
                }
            }

            if (ast1Found || ast2Found) continue;
            
            totalAst.Add(pair[0],newCountryId);
            totalAst.Add(pair[1],newCountryId);
            countries.Add(newCountryId,new List<int>(){pair[0],pair[1]});
            newCountryId++;
        }


        return new Tuple<int, Dictionary<int, List<int>>>(totalAst.Count, countries);

    }
}