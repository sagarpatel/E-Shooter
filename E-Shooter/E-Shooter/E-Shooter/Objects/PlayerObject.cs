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


        SimpleStraight_BulletObject[] weapon1;
        int maxWeapon1;

        SimpleStraightBounce_BulletObject[] weapon2;
        int maxWeapon2;

        int currentWeaponIndex;
        int maxWeaponIndex;

        public PlayerObject(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {

        }


        protected override void LoadContent()
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
         
            position = new Vector2(0, 0);
            facing = new Vector2(0, 0);
            isAlive = true;
            isWallBounce = false;

            maxWeapon1 = 50;
            weapon1 = new SimpleStraight_BulletObject[maxWeapon1];
            for (int i = 0; i < maxWeapon1; ++i)
            {
                weapon1[i] = new SimpleStraight_BulletObject(game, spriteBatch);
                Game.Components.Add(weapon1[i]);
            }

            maxWeapon2 = 20;
            weapon2 = new SimpleStraightBounce_BulletObject[maxWeapon2];
            for (int i = 0; i < maxWeapon2; i++)
            {
                weapon2[i] = new SimpleStraightBounce_BulletObject(game, spriteBatch);
                Game.Components.Add(weapon2[i]);
            }

            currentWeaponIndex = 0;
            maxWeaponIndex = 1;
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.isAlive)
            {
                //Update position
                Vector2 actualPosition = InputManager.sharedInputManager.getTouchPosition();
                Rectangle phoneFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                position = getEdgePosition_setFacing(actualPosition, phoneFrame);


                //Handle weapons
                if (InputManager.sharedInputManager.getIsDoubleTap())
                {
                    currentWeaponIndex++;
                    if (currentWeaponIndex > maxWeaponIndex)
                        currentWeaponIndex = 0;
                }

                HandleWeapons(gameTime);

            }
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

           
            base.Draw(gameTime);
        }


        //Custom functions

        private Vector2 getEdgePosition_setFacing(Vector2 inputPosition, Rectangle frameRectangle)
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
                    {
                        facing = new Vector2(1, 0);
                        return new Vector2(frameRectangle.Left, inputPosition.Y);
                    }
                    //closer to top edge 
                    else
                    {
                        facing = new Vector2(0, 1);
                        return new Vector2(inputPosition.X, frameRectangle.Top);
                    }
                }

                // Bottom Left Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)inputPosition.Y;
                    //closer to left edge
                    if (deltaX < deltaY)
                    {
                        facing = new Vector2(1, 0);
                        return new Vector2(frameRectangle.Left, inputPosition.Y);
                    }
                    //closer to bottom edge
                    else
                    {
                        facing = new Vector2(0, -1);
                        return new Vector2(inputPosition.X, frameRectangle.Bottom);
                    }
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
                    {
                        facing = new Vector2(-1, 0);
                        return new Vector2(frameRectangle.Right, inputPosition.Y);
                    }
                    //closer to top edge
                    else
                    {
                        facing = new Vector2(0, 1);
                        return new Vector2(inputPosition.X, frameRectangle.Top);
                    }
                }

                //Bottom Right Quadrant
                else
                {
                    deltaY = frameRectangle.Bottom - (int)inputPosition.Y;
                    //closer to right edge
                    if (deltaX < deltaY)
                    {
                        facing = new Vector2(-1, 0);
                        return new Vector2(frameRectangle.Right, inputPosition.Y);
                    }
                    //closer to bottom edge
                    else
                    {
                        facing = new Vector2(0, -1);
                        return new Vector2(inputPosition.X, frameRectangle.Bottom);
                    }
                }

            }

        }


        private void HandleWeapons(GameTime gameTime)
        {
            int intTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            BulletObjectAbstract.fireRateCounter += gameTime.ElapsedGameTime.Milliseconds;

            switch (currentWeaponIndex)
            {
                case 0:
                    // for weapon 1
                    if (SimpleStraight_BulletObject.fireRateCounter >= SimpleStraight_BulletObject.fireCooldown)
                    {
                        SimpleStraight_BulletObject.fireRateCounter = 0;
                        foreach (SimpleStraight_BulletObject bullet in weapon1)
                        {
                            if (!bullet.isAlive)
                            {
                                bullet.FireBullet(this);

                                break;
                            }
                        }
                    }
                    break;

                case 1:
                    // for weapon2
                    if (SimpleStraightBounce_BulletObject.fireRateCounter >= SimpleStraightBounce_BulletObject.fireCooldown)
                    {
                        SimpleStraightBounce_BulletObject.fireRateCounter = 0;
                        foreach (SimpleStraightBounce_BulletObject bullet in weapon2)
                        {
                            if (!bullet.isAlive)
                            {
                                bullet.isAlive = true;
                                bullet.facing = facing;
                                bullet.position = position + (this.texture.Width*scale/2 )*facing;
                                bullet.velocity = SimpleStraightBounce_BulletObject.speed * this.facing;
                                break;
                            }

                        }
                    }
                    break;
            }
   

        }

        
          


    }




}
