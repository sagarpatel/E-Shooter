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
    public class Level_2_5 : ScreenAbstract
    {

        public EnemyBaseObject movingEnemyBase1;
        public EnemyBaseObject movingEnemyBase2;

        public int originalTargetAngle1;
        public int originalTargetAngle2;

        public Level_2_5(Game game, SpriteBatch givenSpriteBatch): base(game, givenSpriteBatch)
        {
            movingEnemyBase1 = new EnemyBaseObject(game, givenSpriteBatch, 10, 0.5f, 3);
            movingEnemyBase2 = new EnemyBaseObject(game, givenSpriteBatch, 10, 0.5f, 3);

            originalTargetAngle1 = 90;
            originalTargetAngle2 = 0;

            setInitialValues();

            collisionList.Add(movingEnemyBase1);
            collisionList.Add(movingEnemyBase2);


            nextScreenType = typeof(MainMenu);

        }


        protected override void LoadContent()
        {

            base.LoadContent();

            Game.Components.Add(movingEnemyBase1);
            Game.Components.Add(movingEnemyBase2);

            isLoaded = true;
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(movingEnemyBase1);
            movingEnemyBase1.Dispose();

            Game.Components.Remove(movingEnemyBase2);
            movingEnemyBase2.Dispose();


            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            // check is level is over

            if (movingEnemyBase1.isCompleted && movingEnemyBase2.isCompleted)
                this.isComplete = true;

            if (movingEnemyBase1.isAlive)
                updateMovingBasePV(gameTime, movingEnemyBase1);

            if (movingEnemyBase2.isAlive)
                updateMovingBasePV(gameTime, movingEnemyBase2);

            if (movingEnemyBase1.velocity.Y > 0)
                movingEnemyBase1.spawnTargetAngle = 0;
            else
                movingEnemyBase1.spawnTargetAngle = 180;


            if (movingEnemyBase2.velocity.Y > 0)
                movingEnemyBase2.spawnTargetAngle = 0;
            else
                movingEnemyBase2.spawnTargetAngle = 180;


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
            movingEnemyBase1.spawnTargetAngle = originalTargetAngle1;
            movingEnemyBase1.spawnConeArc = 90;
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


            movingEnemyBase2.position = new Vector2(400, 100);
            movingEnemyBase2.speed = 0.15f;
            movingEnemyBase2.spawnInitialExpulsionSpeed = 200f;
            movingEnemyBase2.spawnTargetAngle = originalTargetAngle2;
            movingEnemyBase2.spawnConeArc = 90;
            movingEnemyBase2.color = Color.IndianRed;
            movingEnemyBase2.scale = 0.7f;
            movingEnemyBase2.setUnitsHomingSpeed(0.5f);
            movingEnemyBase2.isAlive = true;
            movingEnemyBase2.isStarted = true;
            movingEnemyBase2.initialHP = 200;
            movingEnemyBase2.currentHP = movingEnemyBase1.initialHP;
            movingEnemyBase2.isCompleted = false;
            movingEnemyBase2.spawnCooldown = 400;

            movingEnemyBase2.velocity = new Vector2(0, 1);
            movingEnemyBase2.isWallBounce = true;


            base.setInitialValues();
        }

    }
}
