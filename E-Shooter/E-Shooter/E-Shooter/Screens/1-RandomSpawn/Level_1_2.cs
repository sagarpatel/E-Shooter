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
    public class Level_1_2 : ScreenAbstract
    {
        public EnemyBaseObject enemyBase1;
        public EnemyBaseObject enemyBase2;

        public Level_1_2(Game game, SpriteBatch givenSpriteBatch) : base(game,givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 5, 0.85f,1);
            

            collisionList.Add(enemyBase1);

            enemyBase2 = new EnemyBaseObject(game, givenSpriteBatch, 4, 0.75f,1);
            

            collisionList.Add(enemyBase2);

            setInitialValues();

            nextScreenType = typeof(Level_1_3);

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

            if(enemyBase1.isCompleted && enemyBase2.isCompleted)
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

            enemyBase1.position = new Vector2(150, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 150f;
            enemyBase1.color = Color.Beige;
            enemyBase1.scale = 0.6f;
            enemyBase1.setUnitsHomingSpeed(0.2f);
            enemyBase1.isAlive = true;
            enemyBase1.isStarted = true;
            enemyBase1.currentHP = enemyBase1.initialHP;
            enemyBase1.isCompleted = false;

            enemyBase2.position = new Vector2(450, 240);
            enemyBase2.spawnInitialExpulsionSpeed = 100f;
            enemyBase2.color = Color.BlanchedAlmond;
            enemyBase2.scale = 0.6f;
            enemyBase2.setUnitsHomingSpeed(0.8f);
            enemyBase2.isAlive = true;
            enemyBase2.isStarted = true;
            enemyBase2.currentHP = enemyBase2.initialHP;
            enemyBase2.isCompleted = false;
            
            base.setInitialValues();
        }



    }
}
