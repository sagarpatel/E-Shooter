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
    public class Level_2_1 : ScreenAbstract
    {

        public EnemyBaseObject movingEnemyBase1;

        public Level_2_1(Game game, SpriteBatch givenSpriteBatch) : base(game,givenSpriteBatch)
        {


            movingEnemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 3, 0.75f);
            movingEnemyBase1.position = new Vector2(300, 240);
            movingEnemyBase1.spawnInitialExpulsionSpeed = 150f;
            movingEnemyBase1.color = Color.IndianRed;
            movingEnemyBase1.scale = 0.7f;
            movingEnemyBase1.setUnitsHomingSpeed(0.5f);
            movingEnemyBase1.isAlive = true;
            movingEnemyBase1.isStarted = true;

            movingEnemyBase1.velocity = new Vector2(1, 0);
            movingEnemyBase1.isWallBounce = true;

            collisionList.Add(movingEnemyBase1);




        }


        protected override void LoadContent()
        {

            base.LoadContent();

            Game.Components.Add(movingEnemyBase1);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(movingEnemyBase1);
            movingEnemyBase1.Dispose();

          
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            // check is level is over

            if (movingEnemyBase1.isCompleted)
                this.isComplete = true;

            if (movingEnemyBase1.isAlive)
            {
                updateMovingBasePV(gameTime, movingEnemyBase1);
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


        private void updateMovingBasePV(GameTime gameTime, EnemyBaseObject movingBase)
        {
            movingBase.position += movingBase.velocity * (float)gameTime.ElapsedGameTime.Milliseconds;
            
        }


    }
}
