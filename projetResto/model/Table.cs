using Microsoft.Xna.Framework;

namespace projetResto.model;

public class Table : Utils, IPosition
{
    public int nbPlaces;
    public GroupClient groupC;
    public bool entry = false;
    public bool plate = false;
    public bool dessert = false;
    public int x = 0;
    public int y = 0;
    private Rectangle source; // rectangle permettant de definir la zone de l'image a fficher 

    public Table(int nbPlaces)
    {
        this.nbPlaces = nbPlaces;
    }

    public Table(int nbPlaces, int x, int y)
    {
        this.nbPlaces = nbPlaces;
        this.x = x;
        this.y = y;
    }

    public Table(int nbPlaces, Rectangle source)
    {
        this.nbPlaces = nbPlaces;
        this.source = source;
    }

    public int NbPlaces
    {
        get => nbPlaces;
        set => nbPlaces = value;
    }
    public GroupClient GroupClient
    {
        get => groupC;
        set => groupC = value;
    }

  

    public bool Entry
    {
        get => entry;
        set => entry = value;
    }
    
    public bool Plate
    {
        get => plate;
        set => plate = value;
    }
    
    public bool Dessert
    {
        get => dessert;
        set => dessert= value;
    }
    
    public int X
    {
        get => x;
        set => x = value;
    }
    
    public int Y
    {
        get => y;
        set => y = value;
    }
    
    public Rectangle Source
    {
        get => source;
        set => source = value;
    }
    
}

