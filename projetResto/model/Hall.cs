using System.Collections.Generic;

namespace projetResto.model;

public class Hall 
{
    public HotelMaster hotelMaster;
    public static Commis commis;
    public List<Square> squares;

    public Hall()
    {
        squares = new List<Square> { }; //pour un nouveau hall on instancie des carres

        hotelMaster = new HotelMaster();
        commis = new Commis();
    }
    
    

    public HotelMaster HotelMaster
    {
        get => hotelMaster;
        set => hotelMaster = value;
    }
    public static Commis Commis
    {
        get => commis;
        set => commis = value;
    }
}