using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using projetResto.model;

namespace projetResto.controller;

public class CommisSalleController
{
        public int tile = 32;
        public Vector2 Position;
        public Texture2D Texture;
        public bool isMoving = false;
        private List<Vector2> diffpos; //liste de position de tables ou le commis doit se rendre 
        int randomNumber = 0;

        public CommisSalleController()
        {
            this.Position = new Vector2(26 * tile, 16 * tile);
        }

        public void moveTo(Vector2 finalpos)
        {
            if (Position.X > finalpos.X)
            {
                Position.X -= 1 * Parameters.SPEED;
            }
            if (Position.X < finalpos.X)
            {
                Position.X += 1 * Parameters.SPEED;
            }
            if (Position.Y > finalpos.Y)
            {
                Position.Y -= 1 * Parameters.SPEED;
            }
            if (Position.Y < finalpos.Y)
            {
                Position.Y += 1 * Parameters.SPEED;
            }

            if (Position.Y == finalpos.Y && Position.X == finalpos.X)
            {
                isMoving = false;
            }

        }


        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }


        public void Update(GameTime _gametime, bool inTable, List<Table> tables) //on verifie si le commis se deplace pour une table ou est en mouvement
        {
            if (isMoving) //si mouvement
            {
                moveTo(diffpos[randomNumber]); //on definit la prochaine position du commis
            }
            else  //sinon
            {
                diffpos = new List<Vector2>(); ; //on instancie une nouvelle liste de position
                
                foreach (Table t in tables) 
                {
                    if(t.GroupClient != null)
                    {
                        diffpos.Add(rectToVect(t.Source)); //pour les groupes contenant des groupe de clients , on les ajoute dans la liste 
                    }
                
                }
                if (diffpos.Count > 0) //si la liste contient toujours des elements 
                {
                Random random = new Random();
                randomNumber = random.Next(0, (diffpos.Count)); //on choisit au hasard la position d'une table
                isMoving = true; // on commence le deplacement du commis
                }
                

            }
        }

        public void Draw(SpriteBatch _spriteBash)
        {
            _spriteBash.Draw(Texture, Position, Color.White);
        }
    
}