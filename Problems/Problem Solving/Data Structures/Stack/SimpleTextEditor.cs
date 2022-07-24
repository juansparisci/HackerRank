namespace Problems.Problem_Solving.Data_Structures.Stack;

public static class SimpleTextEditor
{

    public static List<char> GetOutputs(List<string> ops)
    {
        TextEditor oTE = new TextEditor();
        ops.ForEach(ops =>
        {
            oTE.ExecuteOperation(ops);
        });
        return oTE.Outputs;
    }
}

public class TextEditor
{
    private string _currentState;
    private Stack<string> _states;
    private List<char> _outputs;
    public TextEditor()
    {
        _states = new Stack<string>();
        _outputs = new List<char>();
        _currentState = "";
    }

    public void ExecuteOperation(string op)
    {
        int opType = Convert.ToInt32(op[0].ToString());
        
        switch (opType)
        {
            case 1:
                string text = op.Substring(1).Trim();
                append(text);
                break;
            case 2:
                int k = Convert.ToInt32(op.Substring(1).Trim());
                delete(k);
                break;
            case 3:
                int j =Convert.ToInt32(op.Substring(1));
                print(j);
                break;
            case 4:
                undo();
                break;
        }
    }

    private void append(string text)
    {
        _states.Push(_currentState);
        _currentState += text;
       
    }

    private void delete(int k)
    {
        _states.Push(_currentState);
        _currentState = _currentState.Remove(_currentState.Length - k);
    }

    private void print(int k)
    {
        _outputs.Add(_currentState[k-1]);
    }
    private void undo()
    {
        _currentState = _states.Pop();
    }
    public List<char> Outputs => _outputs;
}

