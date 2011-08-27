using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace E_Shooter
{


    class ScreenAbstract: Microsoft.Xna.Framework.DrawableGameComponent
    {
        public bool isActive;
        public bool isLoaded;

        protected SpriteBatch spriteBatch;


        public ScreenAbstract(Game game, SpriteBatch givenSpriteBatch):base(game)
        {
            spriteBatch = givenSpriteBatch;
            isActive = false;
            isLoaded = false;

        }


        public override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected virtual void UnloadContent()
        {

        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }




}
