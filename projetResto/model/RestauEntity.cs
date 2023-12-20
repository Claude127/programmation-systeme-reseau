using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace projetResto.model;


/* cette classe represente les entites completes du restaurant*/
public class RestauEntity
{
    public Rectangle Rect;
    public Texture2D Texture;
    
    
    
    public void Draw(SpriteBatch spriteBatch) // fonction pour dessiner les sprites
    {
        spriteBatch.Draw(Texture, Rect, Color.White);
    }
}