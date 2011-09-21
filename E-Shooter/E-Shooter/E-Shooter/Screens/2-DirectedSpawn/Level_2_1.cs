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

        public int originalTargetAngle;

        public Level_2_1(Game game, SpriteBatch givenSpriteBatch) : base(game,givenSpriteBatch)
        {


            movingEnemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 15, 0.75f,3);

            originalTargetAngle = 90;

            setInitialValues();

            collisionList.Add(movingEnemyBase1);


            nextScreenType = typeof(MainMenu);

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

            if (movingEnemyBase1.velocity.X > 0)
                movingEnemyBase1.spawnTargetAngle = originalTargetAngle;
            else
                movingEnemyBase1.spawnTargetAngle = -originalTargetAngle;

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
            movingBase.position += movingBase.velocity * movingBase.speed * (float)gameTime.ElapsedGameTime.Milliseconds;
            
        }

        public override void setInitialValues()
        {
            movingEnemyBase1.position = new Vector2(100, 240);
            movingEnemyBase1.speed = 0.15f;
            movingEnemyBase1.spawnInitialExpulsionSpeed = 200f;
            movingEnemyBase1.spawnTargetAngle = originalTargetAngle;
            movingEnemyBase1.spawnConeArc = 120;
            movingEnemyBase1.color = Color.IndianRed;
            movingEnemyBase1.scale = 0.7f;
            movingEnemyBase1.setUnitsHomingSpeed(0.5f);
            movingEnemyBase1.isAlive = true;
            movingEnemyBase1.isStarted = true;
            movingEnemyBase1.initialHP = 200;
            movingEnemyBase1.currentHP = movingEnemyBase1.initialHP;
            movingEnemyBase1.isCompleted = false;
            movingEnemyBase1.spawnCooldown = 400;

            movingEnemyBase1.velocity = new Vector2(1, 0);
            movingEnemyBase1.isWallBounce = true;

            base.setInitialValues();
        }

    }
}
