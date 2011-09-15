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


    public class ScreenAbstract: Microsoft.Xna.Framework.DrawableGameComponent
    {
        public bool isActive;
        public bool isLoaded;
        public bool isComplete;

        protected SpriteBatch spriteBatch;

        public List<GameObjectAbstract> collisionList;

        public Type nextScreenType;

        public ScreenAbstract(Game game, SpriteBatch givenSpriteBatch):base(game)
        {
            spriteBatch = givenSpriteBatch;
            isActive = false;
            isLoaded = false;
            isComplete = false;
            collisionList = new List<GameObjectAbstract>();

        }


        public override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {

            List<GameObjectAbstract> tempList = new List<GameObjectAbstract>(collisionList);

            foreach (EnemyBaseObject ebase in tempList)
            {
                foreach (EnemyUnitObject units in ebase.unitsArray)
                {
                    collisionList.Add(units);
                }
            }

                       
            base.LoadContent();
            isLoaded = true;
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
