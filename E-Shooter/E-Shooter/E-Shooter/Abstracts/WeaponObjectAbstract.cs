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


    public abstract class WeaponObjectAbstract : Microsoft.Xna.Framework.GameComponent
    {

        public BulletObjectAbstract[] bulletsArray;
        public int maxBullets;
        
        public enum fireTypes
        {
            Single,
            Double
        };
        public fireTypes currentFireType;

        public int fireCooldown;
        public int fireRateCounter;


        public WeaponObjectAbstract(Game game, SpriteBatch givenSpriteBatch, int MaxBulletCount) : base(game)
        {

        }


        public override void Initialize()
        {
            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }


    }










}
