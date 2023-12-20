using System.Collections.Generic;

namespace projetResto.model;

public class Client
{
    public Recette entry;
    public Recette plate;
    public Recette dessert;
    public Dictionary<string, int> strategy;

    public Recette Entry
    {
        get => entry;
        set => entry = value;
    }

    public Recette Plate
    {
        get => plate;
        set => plate = value;
    }

    public Recette Dessert
    {
        get => dessert;
        set => dessert = value;
    }

    public Dictionary<string, int> Strategy
    {
        get => strategy;
        set => strategy = value;
    }

    public Client()
    {
        this.entry = null;
        this.plate = null;
        this.dessert = null;
        this.strategy = new Dictionary<string, int>();
    }
}