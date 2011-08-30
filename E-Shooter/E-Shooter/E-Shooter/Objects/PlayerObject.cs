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

        private Vector2 getEdgePosition(Vector2 inputPosition, Rectangle frameRectangle)
        {

            int deltaX;
            int deltaY;

            //Left half 
            if (inputPosition.X < frameRectangle.Right / 2)
            {
                deltaX = (int)inputPosition.X - frameRectangle.Left;

                // Top left Quadrant
                if (inputPosition.Y < frameRectangle.Bottom / 2)
                {
                    deltaY = (int)inputPosition.Y - frameRectangle.Top;
                    //closer to left edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Left, inputPosition.Y);
                    //closer to top edge 
                    else
                        return new Vector2(inputPosition.X, frameRectangle.Top);
                }

                // Bottom Left Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)inputPosition.Y;
                    //closer to left edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Left, inputPosition.Y);
                    //closer to bottom edge
                    else
                        return new Vector2(inputPosition.X, frameRectangle.Bottom);
                }
            }

            //Right half
            else
            {
                deltaX = frameRectangle.Right - (int)inputPosition.X;

                //Top Right Quadrant
                if (inputPosition.Y < frameRectangle.Bottom / 2)
                {
                    deltaY = (int)inputPosition.Y - frameRectangle.Top;
                    //closer to right edge
                    if (deltaX < deltaY)
                        return new Vector2(frameRectangle.Right, inputPosition.Y);
                    //closer to top edge
                    else
                        return new Vector2(inputPosition.X, frameRectangle.Top);
                }

                //Bottom Right Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)inputPosition.Y;
                    //closer to right edge
                    if(deltaX < deltaY)
                        return new Vector2(frameRectangle.Right, inputPosition.Y);
                    //closer to bottom edge
                    else
                        return new Vector2(inputPosition.X, frameRectangle.Bottom);
                }

            }

        }


    }




}
