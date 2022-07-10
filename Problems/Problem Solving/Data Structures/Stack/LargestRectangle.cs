namespace Problems.Problem_Solving.Data_Structures.Stack;

public class LargestRectangle
{
    public static long largestRectangle(List<int> h)
    {
        
        OpenedRectangles openedRectangles = OpenedRectangles.GetInstance();

        int previousHeight = 0;
        for (int i = 0; i < h.Count; i++)
        {
            if(h[i]>previousHeight) // is moving up
            {  
                Rectangle oR = new Rectangle(i, h[i]); 
                openedRectangles.AddRectangle(oR);
            }
            
            if(h[i]<previousHeight) // is moving down
            {  
                openedRectangles.CloseHigherOpenedRectangles(i,h[i]); 
            }
            previousHeight = h[i];
        }
        
        openedRectangles.CloseHigherOpenedRectangles(h.Count,0);
        return openedRectangles.MaxSurface;
    }
    
}

class OpenedRectangles
{
    private static OpenedRectangles? _instance;
    public static OpenedRectangles GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OpenedRectangles();
        }

        return _instance;
    }
    private OpenedRectangles()
    {
        _maxSurface = 0;
        this._rectanglesStack = new Stack<Rectangle>();
    }
    
    
    private readonly Stack<Rectangle> _rectanglesStack;
    private long _maxSurface;
    public long MaxSurface => _maxSurface;

    public void CloseHigherOpenedRectangles(int currentPosition, int currentHeight)
    {

        int lastStartedPositionClosed = 0;
        while (_rectanglesStack.Any() && _rectanglesStack.Peek().Height > currentHeight)
        {
            var rect = _rectanglesStack.Pop();
            if (rect.Close(currentPosition) > _maxSurface)
            {
                _maxSurface = rect.Surface;
            }
            lastStartedPositionClosed = rect.StartingPosition;
        }
        this.CreateRectangleIfMissed(lastStartedPositionClosed,currentHeight);
    }

    private void CreateRectangleIfMissed(int startingPosition, int currentHeight)
    {
        if ( !_rectanglesStack.Any() || _rectanglesStack.Peek().Height < currentHeight)
        {
            _rectanglesStack.Push(new Rectangle(startingPosition, currentHeight));
        }
    }
    
    public void AddRectangle(Rectangle oR)
    {
        _rectanglesStack.Push(oR);
    }
}

class Rectangle
{
    
    private int _width;

    public Rectangle(int startingPosition, int height)
    {
        StartingPosition = startingPosition;
        Height = height;
    }

    public int StartingPosition
    {
        get;
    }
    public int Height
    {
        get; 
    }
    public long Surface => _width * Height;

    
    public long Close(int position)
    {
        _width = (position - StartingPosition);
        return Surface;
    }
    
}