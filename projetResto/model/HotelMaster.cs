using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace projetResto.model;

public class HotelMaster : Position
{
    public int tile = 30;
    public List<RangeChief> rangeChiefs;

    public List<RangeChief> RangeChiefs
    {
        get => rangeChiefs;
        set => rangeChiefs = value;
    }
    
     public HotelMaster() : base ()
        {
            this.RangeChiefs = new List<RangeChief>();
            
                this.RangeChiefs.Add(new RangeChief(new Vector2(27*tile,17*tile))); //droite
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(2, new Rectangle(33 * tile, 13 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(2, new Rectangle(31 * tile, 7 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(30 * tile, 4 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(8, new Rectangle(28 * tile, 12 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(32 * tile,  7* tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(34 * tile, 11 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(8, new Rectangle(36 * tile, 4 * tile, 5 * tile, 5 * tile)));

                this.RangeChiefs.Add(new RangeChief(new Vector2(28 * tile, 17 * tile))); //gauche
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(2, new Rectangle(16 * tile, 7 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(4, new Rectangle(9 * tile, 3 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(8, new Rectangle(18 * tile, 11 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(4, new Rectangle(9 * tile, 13 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(8, new Rectangle(16 * tile, 4 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(2, new Rectangle(16 * tile, 11 * tile, 5 * tile, 5 * tile)));

        }

        public HotelMaster(int posX, int posY) : base (posX, posY)
        {
            this.RangeChiefs = new List<RangeChief>();

            this.RangeChiefs.Add(new RangeChief());
            this.RangeChiefs.Add(new RangeChief());

            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(10, new Rectangle(16 * tile, 14 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(10, new Rectangle(4 * tile, 7 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(1 * tile, 14 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(8, new Rectangle(12 * tile, 7 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(12 * tile, 1 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[0].Squares[0].Tables.Add(new Table(4, new Rectangle(18 * tile, 1 * tile, 5 * tile, 5 * tile)));

            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(10, new Rectangle(33 * tile, 20 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(4, new Rectangle(24 * tile, 1 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(8, new Rectangle(32 * tile, 1 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(4, new Rectangle(25 * tile, 13 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(8, new Rectangle(22 * tile, 7 * tile, 5 * tile, 5 * tile)));
            this.RangeChiefs[1].Squares[0].Tables.Add(new Table(10, new Rectangle(30 * tile, 7 * tile, 5 * tile, 5 * tile)));
        }
}