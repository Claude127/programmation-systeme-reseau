using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace projetResto.model;

public class RangeChief: Position, IMove
{
    public List<Square> squares;
    public Vector2 Terminus; // represente sa position habituelle(qu'il a avant de commencer ses taches )
    public Vector2 Position; // position actuelle
    public bool available = true;
    public int rate = 32;
    public Texture2D Texture;
    public bool isMoving = false;
    public bool toSpawn = false;

    public List<Square> Squares
    {
        get => squares;
        set => squares = value;

    }

    public bool Available
    {
        get => available;
        set => available = value;
    }

    public RangeChief()
    {
        this.squares = new List<Square>();
        this.squares.Add(new Square());
    }

    public RangeChief(Vector2 position)
    {
        this.Terminus = position;
        this.Position = position;
        this.squares = new List<Square>();
        this.squares.Add(new Square());
    }

    public RangeChief(int x, int y) : base(x, y)
    {
        this.squares = new List<Square>();
        this.squares.Add(new Square());
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int findRightTables(int nbpers) // pour attribuer des tables , l'on doit s'assurer qu'elles soient vides 
    {
        foreach (Table table in this.squares[0].tables)
        {
            if (table.state == UtilsState.Available)
            {
                
            }
        }

        return 0;
    }

    public void Update(GameTime _gametime, Vector2 termpos) // mettre les informations a jour vis a vis des interactions avec le clavier et la position finale 
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Space) && Position.Y == 16 * rate)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            available = false;
            moveTo(termpos);
        }

        if (toSpawn)
        {
            available = false;
            moveTo(Terminus);
        }
    }

    public void moveTo(Vector2 termpos) // deplacer en fonction d'une destination finale
    {
        if (Position.X > termpos.X)
        {
            Position.X -= 1 * Parameters.SPEED;
        }

        if (Position.X < termpos.X)
        {
            Position.X += 1 * Parameters.SPEED;
            
        }
        
        if (Position.Y > termpos.Y)
        {
            Position.Y -= 1 * Parameters.SPEED;
        }

        if (Position.Y < termpos.Y)
        {
            Position.Y += 1 * Parameters.SPEED;
            
        }

        if (Position == termpos)
        {
            isMoving = false;
            toSpawn = true;
        }

        if (Position == Terminus)
        {
            toSpawn = false;
            available = true;
        }
    }
    
    public void Draw(SpriteBatch _spriteBash) //pour afficher le sprite du chef de rang 
    {
        _spriteBash.Draw(Texture, Position, Color.White);
    }
}