namespace projetResto.model;

public class Position:IPosition
{
    public int x;
    public int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Position()
    {
        this.x = 0;
        this.y = 0;
    }

    public int X //on recupere les coordonees des elements(getters, setters)
    {
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }
}