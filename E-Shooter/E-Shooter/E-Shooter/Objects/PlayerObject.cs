using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;



namespace E_Shooter
{

    public class PlayerObject : GameObjectAbstract
    {

        public PlayerObject(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {

        }


        protected override void LoadContent()
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            position = new Vector2(0, 0);
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            Vector2 actualPosition = InputManager.sharedInputManager.getTouchPosition();

            Rectangle phoneFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            
            position = getEdgePosition(actualPosition, phoneFrame);


            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

           
            spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);

            base.Draw(gameTime);
        }


        //Custom functions

        private Vector2 getEdgePosition(Vector2 playerPosition, Rectangle frameRectangle)
        {

            int deltaX;
            int deltaY;

            //Left half 
            if (playerPosition.X < frameRectangle.Right / 2)
            {
                deltaX = (int)playerPosition.X - frameRectangle.Left;

                // Top left Quadrant
                if (playerPosition.Y < frameRectangle.Bottom / 2)
                {
                    deltaY = (int)playerPosition.Y - frameRectangle.Top;
                    //closer to left edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Left, playerPosition.Y);
                    //closer to top edge 
                    else
                        return new Vector2(playerPosition.X, frameRectangle.Top);
                }

                // Bottom Left Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)playerPosition.Y;
                    //closer to left edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Left, playerPosition.Y);
                    //closer to bottom edge
                    else
                        return new Vector2(playerPosition.X, frameRectangle.Bottom);
                }
            }

            //Right half
            else
            {
                deltaX = frameRectangle.Right - (int)playerPosition.X;

                //Top Right Quadrant
                if (playerPosition.Y > frameRectangle.Bottom / 2)
                {
                    deltaY = (int)playerPosition.Y - frameRectangle.Top;
                    //closer to right edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Right, playerPosition.Y);
                    //closer to top edge
                    else
                        return new Vector2(playerPosition.X, frameRectangle.Top);
                }

                //Bottom Right Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)playerPosition.Y;
                    //closer to right edge
                    if(deltaX < deltaY)
                        return new Vector2(frameRectangle.Right, playerPosition.Y);
                    //closer to bottom edge
                    else
                        return new Vector2(playerPosition.X, frameRectangle.Bottom);
                }

            }

        }


    }




}
