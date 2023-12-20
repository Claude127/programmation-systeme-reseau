namespace projetResto.model;

public class Server: Position, IMove
{
    public Server(int x, int y) : base(x, y)
    {
        
    }

    public Server() : base()
    {
        
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}