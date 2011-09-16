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
    public class Level_1_3 : ScreenAbstract
    {
        public EnemyBaseObject enemyBase1;
        public EnemyBaseObject enemyBase2;
        public EnemyBaseObject enemyBase3;

        public Level_1_3(Game game, SpriteBatch givenSpriteBatch) : base(game,givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 4, 0.85f);
            collisionList.Add(enemyBase1);

            enemyBase2 = new EnemyBaseObject(game, givenSpriteBatch, 6, 0.7f);
            collisionList.Add(enemyBase2);


            enemyBase3 = new EnemyBaseObject(game, givenSpriteBatch, 4, 0.85f);
            collisionList.Add(enemyBase3);

            setInitialValues();

            nextScreenType = typeof(Level_1_4);
        }


        
        protected override void LoadContent()
        {

            base.LoadContent();

            Game.Components.Add(enemyBase1);
            Game.Components.Add(enemyBase2);
            Game.Components.Add(enemyBase3);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(enemyBase1);
            enemyBase1.Dispose();

            Game.Components.Remove(enemyBase2);
            enemyBase2.Dispose();

            Game.Components.Remove(enemyBase3);
            enemyBase3.Dispose();

            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            // check is level is over

            if(enemyBase1.isCompleted && enemyBase2.isCompleted && enemyBase3.isCompleted)
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

        public override void setInitialValues()
        {

            enemyBase1.position = new Vector2(200, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 80f;
            enemyBase1.color = Color.Orange;
            enemyBase1.scale = 0.6f;
            enemyBase1.setUnitsHomingSpeed(0.7f);
            enemyBase1.isAlive = true;
            enemyBase1.isStarted = true;
            enemyBase1.isCompleted = false;
            enemyBase1.currentHP = enemyBase1.initialHP;


            enemyBase2.position = new Vector2(350, 240);
            enemyBase2.spawnInitialExpulsionSpeed = 100f;
            enemyBase2.color = Color.OrangeRed;
            enemyBase2.scale = 0.7f;
            enemyBase2.setUnitsHomingSpeed(0.85f);
            enemyBase2.isAlive = true;
            enemyBase2.isStarted = true;
            enemyBase2.isCompleted = false;
            enemyBase2.currentHP = enemyBase2.initialHP;


            enemyBase3.position = new Vector2(500, 240);
            enemyBase3.spawnInitialExpulsionSpeed = 80f;
            enemyBase3.color = Color.Orange;
            enemyBase3.scale = 0.6f;
            enemyBase3.setUnitsHomingSpeed(0.7f);
            enemyBase3.isAlive = true;
            enemyBase3.isStarted = true;
            enemyBase3.isCompleted = false;
            enemyBase3.currentHP = enemyBase3.initialHP;

            
            
            base.setInitialValues();
        }



    }
}
