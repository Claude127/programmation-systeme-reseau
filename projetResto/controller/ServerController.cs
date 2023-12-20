using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using projetResto.model;

namespace projetResto.controller;

public class ServerController
{
    
        public int tile = 32;
        public Vector2 Position;
        private Vector2 Spawn;
        private Vector2 Clients;
        private GroupClient lastGroup= null;
        public Texture2D Texture;
        public bool isMoving = false;
        public bool isCleaning = false;
        public bool toSpawn = false;
        private List<Table> tablesInUse;
        int rdtable;


        public ServerController(Vector2 fpos)
        {
            this.Position = fpos;
            Spawn = fpos;




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
                toSpawn = false;
            }

        }

        private void cleanTable(List<Table> tables)
        {
            foreach(Table t in tables)
            {
                if(t.State == UtilsState.Dirty)
                {
                    isCleaning = true;
                    moveTo(rectToVect(t.Source));
                    if(Position == rectToVect(t.Source))
                    {
                        t.State = UtilsState.Available;
                        toSpawn = true;
                        isCleaning = false;
                    }
                    break;
                }
            }
        }
        
        


        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }

        public void Update(GameTime _gametime,List<Table> tables)
        {
            tablesInUse = new List<Table>();
            foreach (Table t in tables)
            {
                if (t.GroupClient != null)
                {
                    tablesInUse.Add(t);

                }
            }



            if (toSpawn)
            {
                moveTo(Spawn);
            }
            else
            {
                cleanTable(tables);

                if (!isCleaning)
                {
                    
                      if (isMoving)
                    {
                        moveTo(Clients);
                        if(Position == Clients)
                        {
                            toSpawn = true;
                        }
                    }
                    else
                    {
                        if (tablesInUse.Count>0)
                        {
                        Random random = new Random();
                        rdtable = random.Next(0, tablesInUse.Count);
                        Clients = rectToVect(tablesInUse[rdtable].Source);
                        isMoving = true;
                        }
                        
                    }   
                }
                
            }

        }

        

        public void Draw(SpriteBatch _spriteBash)
        {
            _spriteBash.Draw(Texture, Position, Color.White);
        }
        
}