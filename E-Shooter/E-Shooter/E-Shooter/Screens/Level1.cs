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


    public class Level1 :  ScreenAbstract
    {

        public EnemyBaseObject enemyBase1;

        public Level1(Game game, SpriteBatch givenSpriteBatch) : base(game, givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 30);
            enemyBase1.position = new Vector2(300, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 150f;
            enemyBase1.color = Color.Blue;

            collisionList.Add(enemyBase1);

        }



        protected override void LoadContent()
        {

            base.LoadContent();

            enemyBase1.setUnitsHomingSpeed(0.2f);
            Game.Components.Add(enemyBase1);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(enemyBase1);
            enemyBase1.Dispose();
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            // check is level is over
            if (enemyBase1.isCompleted)
                this.isComplete = true;

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            if (isLoaded)
            {
                base.Draw(gameTime);
            }
        }



    }


}
