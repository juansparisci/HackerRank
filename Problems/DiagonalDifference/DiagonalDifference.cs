namespace Problems.DiagonalDifference;

public class DiagonalDifference
{
    public static int diagonalDifference(List<List<int>> arr)
    {
        int diff = 0;
        int matrixSize = arr.Count;
        int sumDiagA = 0;
        int sumDiagB = 0;
        
        for (int row = 0; row < matrixSize; row++)
        {
            int colDiagA = row;
            int colDiagB = matrixSize - 1 - row;

            sumDiagA += arr[row][colDiagA];
            sumDiagB += arr[row][colDiagB];
        }
        
        diff = Math.Abs((sumDiagA-sumDiagB));
        
        return diff;
    }
}