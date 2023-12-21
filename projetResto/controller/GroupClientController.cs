using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using projetResto.model;

namespace projetResto.controller;

public class GroupClientController
{
        public int rate =32;
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 PosTable;
        public bool isMoving = false;
        public bool start = true;
        public GroupClient group;
        public bool inTable = false;

        public GroupClientController(GroupClient groupe)
        {
            Position = new Vector2(21*rate,20*rate);
            group = groupe;
        }
        
        public void moveToTable(Vector2 finalpos)
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
                inTable = true;
            }

        }
        public void Start(GameTime _gametime)
        {
            if (Position.Y > 16 * rate)
            {
                Position.Y -= 1 * Parameters.SPEED;
            }
            if(Position.Y == 16 * rate)
            {
                start = false;
            }
            
        }

        public void Update(GameTime _gametime, Vector2 finalpos)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Position.Y == 16 * rate)
            {
                isMoving = true;
                    
            }
            if (isMoving)
            {
                moveToTable(finalpos);
            }
        }

        public void Draw(SpriteBatch _spriteBash)
        {
            _spriteBash.Draw(Texture, Position, Color.White);
        }

        public static void ChangeGroupState(GroupClient group, GroupState state)
        {
            if ((group != null) && (group.State != state))
                group.State = state;
        }

        public void toto()
        {
            switch (this.group.State)
            {
                case GroupState.WaitTableAttribution:
                    this.start = true;
                    break;

                case GroupState.WaitRankChief:

                    break;

                case GroupState.Ordering:

                    break;

                case GroupState.Ordered:

                    break;

                case GroupState.WaitEntree:

                    break;

                case GroupState.WaitPlate:

                    break;

                case GroupState.WaitDessert:

                    break;

                case GroupState.WaitBill:

                    break;
            }
        }
}

