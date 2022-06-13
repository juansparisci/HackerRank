class Result
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */


    
    
    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
       
        Queen queen = new Queen(new Position(r_q,c_q));
        List<Piece> pieces = new List<Piece>() {queen};
        Dictionary<int, HashSet<int>> obstaclesDic = new Dictionary<int, HashSet<int>>();
        foreach (var o in obstacles)
        {
            if (obstaclesDic.TryGetValue(o[0], out var columns))
            {
                columns.Add(o[1]);
            }
            else
            {
                obstaclesDic.TryAdd(o[0], new HashSet<int> {o[1]});
            }
        }
            
        Board board = new Board(n,pieces,obstaclesDic);
        
        return  board.GetNumberOfSquaresCanBeAttacked();

    }

    private class Board
    {
        private readonly List<Piece> _pieces;
        private readonly int _size;
        private readonly Dictionary<int, HashSet<int>> _obstacles;
        public Board(int size, List<Piece> pieces, Dictionary<int, HashSet<int>> obstacles)
        {
            _size = size;
            _pieces = pieces;
            _obstacles = obstacles;
        }

        public int GetNumberOfSquaresCanBeAttacked()
        {
            int numberOfSquaresCanBeAttacked = 0;
            _pieces.ForEach(piece =>
            {
                piece.Movements.ForEach(movement =>
                {
                    piece.NextPosition = piece.CurrentPosition;
                    bool obstaclePresent;
                    do
                    {
                        piece.NextPosition = movement.GetFuturePosition(piece.NextPosition);
                        obstaclePresent = this.ObstaclePresent(piece.NextPosition);
                        if (piece.FuturePositionInsideTheBoard(_size) && !obstaclePresent)
                        {
                            numberOfSquaresCanBeAttacked++;
                        }
                    } while (piece.FuturePositionInsideTheBoard(_size) && !obstaclePresent);
                });
            });
                
            return numberOfSquaresCanBeAttacked;
        }

        private bool ObstaclePresent(Position obsPosition)
        {
            if (_obstacles.TryGetValue(obsPosition.Row, out var columns))
            {
                if (columns.TryGetValue(obsPosition.Column, out _))
                {
                    return true;
                }
            }
            return false;
        }
    }
    

    public abstract class Piece
    {
        protected Piece(Position position)
        {
            CurrentPosition = position;
            this.NextPosition = position;
            this.Movements = new List<Movement>();
        }

        public List<Movement> Movements { get; }

        public Position NextPosition { get; set; }

        public Position CurrentPosition { get; set; }

        public bool FuturePositionInsideTheBoard(int boardSize)
        {
            return NextPosition.Row >= 1 && NextPosition.Row <= boardSize && NextPosition.Column >= 1 &&
                   NextPosition.Column <= boardSize;
        }
    }


    private class Queen : Piece
    {
        public Queen(Position position) : base(position)
        {
            this.LoadQueenMovements();
        }

        private void LoadQueenMovements()
        {
            this.Movements.Add(new DiagonalMovement(VerticalDirection.Up,HorizontalDirection.Right));
            this.Movements.Add(new DiagonalMovement(VerticalDirection.Down,HorizontalDirection.Right));
            this.Movements.Add(new DiagonalMovement(VerticalDirection.Down,HorizontalDirection.Left));
            this.Movements.Add(new DiagonalMovement(VerticalDirection.Up,HorizontalDirection.Left));
            this.Movements.Add(new HorizontalMovement(HorizontalDirection.Left));
            this.Movements.Add(new HorizontalMovement(HorizontalDirection.Right));
            this.Movements.Add(new VerticalMovement(VerticalDirection.Up));
            this.Movements.Add(new VerticalMovement(VerticalDirection.Down));
            
        }
    }

    public abstract class Movement
    {
        public abstract Position GetFuturePosition(Position positionFrom);
    }

    private class DiagonalMovement : Movement
    {
        private readonly VerticalDirection _verticalDirection;
        private readonly HorizontalDirection _horizontalDirection;
        public DiagonalMovement(VerticalDirection verticalDirection, HorizontalDirection horizontalDirection)
        {
            _verticalDirection = verticalDirection;
            _horizontalDirection = horizontalDirection;
        }

        public override Position GetFuturePosition(Position positionFrom)
        {
            switch (_verticalDirection, _horizontalDirection)
            {
                case ( VerticalDirection.Up, HorizontalDirection.Right ):
                    return new Position(positionFrom.Row+1, positionFrom.Column + 1);
                   
                case ( VerticalDirection.Down, HorizontalDirection.Right ):
                    return new Position(positionFrom.Row-1, positionFrom.Column + 1);
                  
                case ( VerticalDirection.Down, HorizontalDirection.Left ):
                    return new Position(positionFrom.Row-1, positionFrom.Column - 1);
                
                case ( VerticalDirection.Up, HorizontalDirection.Left ):
                    return new Position(positionFrom.Row+1, positionFrom.Column - 1);
                 
                default:
                    throw new Exception("positionFrom is not valid");
            }
        }
    }

    private class HorizontalMovement : Movement
    {
        private readonly HorizontalDirection _direction;

        public HorizontalMovement(HorizontalDirection direction)
        {
            _direction = direction;
        }

        public override Position GetFuturePosition(Position positionFrom)
        {
            switch (_direction)
            {
                case HorizontalDirection.Left:
                    return new Position(positionFrom.Row, positionFrom.Column - 1);
                    
                case HorizontalDirection.Right:
                    return new Position(positionFrom.Row, positionFrom.Column + 1);
                    
                default:
                    throw new Exception("positionFrom is not valid");
            }
        }
    }

    private class VerticalMovement : Movement
    {
        private readonly VerticalDirection _direction;

        public VerticalMovement(VerticalDirection direction)
        {
            _direction = direction;
        }


        public override Position GetFuturePosition(Position positionFrom)
        {
            switch (_direction)
            {
                case VerticalDirection.Down:
                    return new Position(positionFrom.Row-1, positionFrom.Column);
                   
                case VerticalDirection.Up:
                    return new Position(positionFrom.Row+1, positionFrom.Column);
                    
                default:
                    throw new Exception("positionFrom is not valid");
            }
        }
    }

    private enum VerticalDirection
    {
        Up, Down
    }

    private enum HorizontalDirection
    {
        Left, Right
    }
    public class Position
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        
    }


}






class Solution
{
    public static void Main(string[] args)
    {
       
      
        int n = 5;
        
        int k = 3;
        
        
        int r_q = 4;
        
        int c_q = 3;
        // int n = 100000;
        //
        // int k = 0;
        //  
        //  
        //
        // int r_q = 4187;
        //
        // int c_q = 5068;
        List<List<int>> obstacles = new List<List<int>>();

        
            obstacles.Add(new List<int>(){ 5, 5});
            obstacles.Add(new List<int>(){ 4, 2});
            obstacles.Add(new List<int>(){ 2, 3});
        

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

            Console.WriteLine(result);

    }
}