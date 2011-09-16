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
    public class MainMenu: ScreenAbstract
    {
        public EnemyBaseObject enemyBase1;
        

        public MainMenu(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch,5,1);
            //enemyBase1.position = new Vector2(400, 240);
            //enemyBase1.spawnInitialExpulsionSpeed = 100f;
            //enemyBase1.isAlive = true;
            //enemyBase1.isStarted = true;

            setInitialValues();
            
            collisionList.Add(enemyBase1);

            // putting in abstract LoadContent()
            //foreach(EnemyBaseObject eBase in collisionList)
            //{
            //    foreach (EnemyUnitObject units in eBase.unitsArray)
            //    {
            //        collisionList.Add(units);
            //    }
            //}





            nextScreenType = typeof(Level_2_1);
        }



        protected override void LoadContent()
        {

            base.LoadContent();

            enemyBase1.setUnitsHomingSpeed(0.05f);
            Game.Components.Add(enemyBase1);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
           // enemyBase1.Dispose();
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


        public override void setInitialValues()
        {
            enemyBase1.position = new Vector2(400, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 100f;
            enemyBase1.isAlive = true;
            enemyBase1.isStarted = true;
            enemyBase1.currentHP = enemyBase1.initialHP;
            enemyBase1.isCompleted = false;
            
            base.setInitialValues();
        }


    }
}
