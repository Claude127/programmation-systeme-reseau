namespace projetResto.model;

public class Commis : Position, IMove
{
    public Commis(int x, int y) : base(x, y) { }
    
    public Commis() : base() { }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}