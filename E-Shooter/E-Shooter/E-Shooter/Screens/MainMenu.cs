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
        public EnemyBaseObject selectorBase1;
        public EnemyBaseObject selectorBase2;
        

        public MainMenu(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {
            selectorBase1 = new EnemyBaseObject(game, givenSpriteBatch,0,1);
            //enemyBase1.position = new Vector2(400, 240);
            //enemyBase1.spawnInitialExpulsionSpeed = 100f;
            //enemyBase1.isAlive = true;
            //enemyBase1.isStarted = true;

            selectorBase2 = new EnemyBaseObject(game, givenSpriteBatch, 0, 1);

            setInitialValues();
            
            collisionList.Add(selectorBase1);
            collisionList.Add(selectorBase2);

            // putting in abstract LoadContent()
            //foreach(EnemyBaseObject eBase in collisionList)
            //{
            //    foreach (EnemyUnitObject units in eBase.unitsArray)
            //    {
            //        collisionList.Add(units);
            //    }
            //}





            
        }



        protected override void LoadContent()
        {

            base.LoadContent();

            selectorBase1.setUnitsHomingSpeed(0.05f);
            Game.Components.Add(selectorBase1);
            Game.Components.Add(selectorBase2);

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
            if (selectorBase1.isCompleted)
            {
                nextScreenType = typeof(Level_1_1);
                this.isComplete = true;
            }
            else if (selectorBase2.isCompleted)
            {
                nextScreenType = typeof(Level_2_1);
                this.isComplete = true;
            }

            if (this.isComplete)
            {
                foreach (GameObjectAbstract obj in collisionList)
                    obj.isAlive = false;

            }

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
            selectorBase1.position = new Vector2(200, 240);
            selectorBase1.spawnInitialExpulsionSpeed = 100f;
            selectorBase1.isAlive = true;
            selectorBase1.isStarted = true;
            selectorBase1.currentHP = selectorBase1.initialHP;
            selectorBase1.isCompleted = false;
            selectorBase1.color = Color.Red;

            selectorBase2.position = new Vector2(600, 240);
            selectorBase2.isAlive = true;
            selectorBase2.isStarted = true;
            selectorBase2.currentHP = selectorBase2.initialHP;
            selectorBase2.isCompleted = false;
            selectorBase2.color = Color.Blue;

            base.setInitialValues();
        }


    }
}
