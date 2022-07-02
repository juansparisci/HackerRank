namespace Problems.QueensAttack2;

public class QueensAttack2
{
    public static int QueensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        var queen = new Queen(new Position(r_q, c_q));
        var pieces = new List<Piece> {queen};
        var obstaclesDic = new Dictionary<int, HashSet<int>>();
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

        var board = new Board(n, pieces, obstaclesDic);
        return board.GetNumberOfSquaresCanBeAttacked();
        
    }

    private class Board
    {
        private readonly Dictionary<int, HashSet<int>> _obstacles;
        private readonly List<Piece> _pieces;
        private readonly int _size;

        public Board(int size, List<Piece> pieces, Dictionary<int, HashSet<int>> obstacles)
        {
            _size = size;
            _pieces = pieces;
            _obstacles = obstacles;
        }

        public int GetNumberOfSquaresCanBeAttacked()
        {
            var numberOfSquaresCanBeAttacked = 0;
            _pieces.ForEach(piece =>
            {
                piece.Movements.ForEach(movement =>
                {
                    piece.NextPosition = piece.CurrentPosition;
                    bool obstaclePresent;
                    do
                    {
                        piece.NextPosition = movement.GetFuturePosition(piece.NextPosition);
                        obstaclePresent = ObstaclePresent(piece.NextPosition);
                        if (piece.FuturePositionInsideTheBoard(_size) && !obstaclePresent)
                            numberOfSquaresCanBeAttacked++;
                    } while (piece.FuturePositionInsideTheBoard(_size) && !obstaclePresent);
                });
            });

            return numberOfSquaresCanBeAttacked;
        }

        private bool ObstaclePresent(Position obsPosition)
        {
            if (_obstacles.TryGetValue(obsPosition.Row, out var columns))
                if (columns.TryGetValue(obsPosition.Column, out _))
                    return true;
            return false;
        }
    }


    public abstract class Piece
    {
        protected Piece(Position position)
        {
            CurrentPosition = position;
            NextPosition = position;
            Movements = new List<Movement>();
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
            LoadQueenMovements();
        }

        private void LoadQueenMovements()
        {
            Movements.Add(new DiagonalMovement(VerticalDirection.Up, HorizontalDirection.Right));
            Movements.Add(new DiagonalMovement(VerticalDirection.Down, HorizontalDirection.Right));
            Movements.Add(new DiagonalMovement(VerticalDirection.Down, HorizontalDirection.Left));
            Movements.Add(new DiagonalMovement(VerticalDirection.Up, HorizontalDirection.Left));
            Movements.Add(new HorizontalMovement(HorizontalDirection.Left));
            Movements.Add(new HorizontalMovement(HorizontalDirection.Right));
            Movements.Add(new VerticalMovement(VerticalDirection.Up));
            Movements.Add(new VerticalMovement(VerticalDirection.Down));
        }
    }

    public abstract class Movement
    {
        public abstract Position GetFuturePosition(Position positionFrom);
    }

    private class DiagonalMovement : Movement
    {
        private readonly HorizontalDirection _horizontalDirection;
        private readonly VerticalDirection _verticalDirection;

        public DiagonalMovement(VerticalDirection verticalDirection, HorizontalDirection horizontalDirection)
        {
            _verticalDirection = verticalDirection;
            _horizontalDirection = horizontalDirection;
        }

        public override Position GetFuturePosition(Position positionFrom)
        {
            switch (_verticalDirection, _horizontalDirection)
            {
                case (VerticalDirection.Up, HorizontalDirection.Right):
                    return new Position(positionFrom.Row + 1, positionFrom.Column + 1);

                case (VerticalDirection.Down, HorizontalDirection.Right):
                    return new Position(positionFrom.Row - 1, positionFrom.Column + 1);

                case (VerticalDirection.Down, HorizontalDirection.Left):
                    return new Position(positionFrom.Row - 1, positionFrom.Column - 1);

                case (VerticalDirection.Up, HorizontalDirection.Left):
                    return new Position(positionFrom.Row + 1, positionFrom.Column - 1);

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
                    return new Position(positionFrom.Row - 1, positionFrom.Column);

                case VerticalDirection.Up:
                    return new Position(positionFrom.Row + 1, positionFrom.Column);

                default:
                    throw new Exception("positionFrom is not valid");
            }
        }
    }

    private enum VerticalDirection
    {
        Up,
        Down
    }

    private enum HorizontalDirection
    {
        Left,
        Right
    }

    public class Position
    {
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}