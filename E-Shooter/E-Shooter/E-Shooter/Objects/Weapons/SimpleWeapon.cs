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

    public class SimpleWeapon : WeaponObjectAbstract
    {


        public SimpleWeapon(Game game, SpriteBatch givenSpriteBatch, int MaxBulletCount) : base(game, givenSpriteBatch, MaxBulletCount)
        {

            maxBullets = MaxBulletCount;
            bulletsArray = new SimpleStraight_BulletObject[maxBullets];

            originalColor = Color.LawnGreen;
            bounceColor = Color.DeepSkyBlue;
            
            for (int i = 0; i < maxBullets; ++i)
            {
                bulletsArray[i] = new SimpleStraight_BulletObject(game, givenSpriteBatch);
                bulletsArray[i].color = originalColor;
                Game.Components.Add(bulletsArray[i]);
            }

            currentFireType = fireTypes.Single;
            fireCooldown = 200;

        }



        public override void Update(GameTime gameTime)
        {
                   
            
            
            
            base.Update(gameTime);
        }


        public void FireWeapon(GameTime gameTime, PlayerObject player)
        {
            int intTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            fireRateCounter += gameTime.ElapsedGameTime.Milliseconds;


     

            if (this.fireRateCounter >= this.fireCooldown)
            {
                this.fireRateCounter = 0;

                switch (currentFireType)
                {

                    case fireTypes.Single:

                        foreach (SimpleStraight_BulletObject bullet in bulletsArray)
                        {
                            if (bullet.isAlive == false)
                            {
                                bullet.isAlive = true;
                                bullet.facing = player.facing;
                                bullet.position = player.position + (player.texture.Width * player.scale / 2) * player.facing;
                                bullet.velocity = this.speed * player.facing;

                                break;
                            }
                        }
                        break;
                }
            }


        }

        public void setWallBounce(bool setWallBounce)
        {
            foreach (SimpleStraight_BulletObject bullet in bulletsArray)
            {
                bullet.isWallBounce = setWallBounce;
                if (setWallBounce == true)
                {
                    bullet.color = bounceColor;
                    isWallBouncing = true;
                }
                else
                {
                    bullet.color = originalColor;
                    isWallBouncing = false;
                }
            }

        }



    }

}
