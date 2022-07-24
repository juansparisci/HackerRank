namespace Problems.Problem_Solving.Data_Structures.Stack.PoisonousPlants;

public class PoisonousPlants
{
    
    public static int poisonousPlants(List<int> p)
    {
        
        int maxDays = 0;
        //keyvaluePair = 0|plantPoison  1|days
        Stack<KeyValuePair<int, int>> daysSurvivedPerPlant = new Stack<KeyValuePair<int, int>>();
        
        
        
        for (int i = 0; i < p.Count; i++)
        {
            int tempDays = 0;
            
            while (daysSurvivedPerPlant.Any() && daysSurvivedPerPlant.Peek().Key >= p[i])
            {
                var lastPlantAdded = daysSurvivedPerPlant.Pop();
                tempDays = lastPlantAdded.Value > tempDays ? lastPlantAdded.Value : tempDays;
            }

            if (daysSurvivedPerPlant.Any())
            {
                tempDays += 1;
            }
            else
            {
                tempDays = 0;
            }

            maxDays = maxDays < tempDays ? tempDays : maxDays;
            
            daysSurvivedPerPlant.Push(new KeyValuePair<int, int>(p[i],tempDays));
            
        }
        
        return maxDays;

    }



    public static int poisonousPlants2(List<int> p)
    {
        int totalDays = 0;
        bool plantRemovedToday = false;
        List<int> tempDeathPlantsIndexes = new List<int>();
        do
        {
            plantRemovedToday = false;
            for (int i = 0; i < p.Count - 1; i++)
            {
                if (p[i] < p[i + 1])
                {
                    tempDeathPlantsIndexes.Add(i+1);
                }
            }

            if (tempDeathPlantsIndexes.Any())
            {
                int tempIndex=0;
                tempDeathPlantsIndexes.ForEach(tdpi =>
                {
                    p.RemoveAt(tdpi-tempIndex);
                    tempIndex++;
                });
                plantRemovedToday = true;
                totalDays++;
                tempDeathPlantsIndexes.Clear();
            }
        } while (plantRemovedToday);

        return totalDays;

    }
}
// 6 5 8 4 7 10 9
// 6 5 x 4 x  x 9