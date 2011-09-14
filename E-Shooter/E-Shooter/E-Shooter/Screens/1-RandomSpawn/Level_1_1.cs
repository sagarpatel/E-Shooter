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


    public class Level_1_1 :  ScreenAbstract
    {

        public EnemyBaseObject enemyBase1;
        public EnemyBaseObject enemyBase2;

        public Level_1_1(Game game, SpriteBatch givenSpriteBatch) : base(game, givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 10,0.85f);
            enemyBase1.position = new Vector2(300, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 150f;
            enemyBase1.color = Color.Blue;
            enemyBase1.scale = 0.7f;
            enemyBase1.setUnitsHomingSpeed(0.2f);
            enemyBase1.isAlive = true;
            enemyBase1.isStarted = true;

            collisionList.Add(enemyBase1);

            enemyBase2 = new EnemyBaseObject(game, givenSpriteBatch, 10,0.80f);
            enemyBase2.position = new Vector2(250, 240);
            enemyBase2.spawnInitialExpulsionSpeed = 150f;
            enemyBase2.color = Color.BlueViolet;
            enemyBase2.scale = 0.7f;
            enemyBase2.setUnitsHomingSpeed(0.8f);
            enemyBase2.isAlive = false;
            enemyBase2.isStarted = false;

            collisionList.Add(enemyBase2);

            

        }



        protected override void LoadContent()
        {

            base.LoadContent();

            Game.Components.Add(enemyBase1);
            Game.Components.Add(enemyBase2);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(enemyBase1);
            enemyBase1.Dispose();

            Game.Components.Remove(enemyBase2);
            enemyBase2.Dispose();
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            // check is level is over
            if (enemyBase1.isCompleted && enemyBase2.isStarted == false && enemyBase2.isCompleted == false)
            {
                enemyBase2.isAlive = true;
                enemyBase2.isStarted = true;
            }

            if(enemyBase2.isCompleted)
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
