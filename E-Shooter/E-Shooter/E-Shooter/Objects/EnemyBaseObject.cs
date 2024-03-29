using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;



namespace E_Shooter
{
    public class EnemyBaseObject : GameObjectAbstract
    {

        public int maxUnits;
        public EnemyUnitObject[] unitsArray;
        public float spawnInitialExpulsionSpeed;
        public int spawnCounter;
        public int spawnCooldown;
        public bool isCompleted;

        public int spawnTargetAngle;
        public int spawnConeArc;
        public Vector2 spawnTargetVector;

        public int spawnBatchCount;

        public bool isStarted;

        public EnemyBaseObject(Game game, SpriteBatch givenSpriteBatch, int maximumUnitCount, float wbDampFact, int spawnBC):base(game, givenSpriteBatch)
        {
            maxUnits = maximumUnitCount;
            spawnCooldown = 200;

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            
            color = Color.HotPink;
            isAlive = true;

            unitsArray = new EnemyUnitObject[maxUnits];
            for (int i = 0; i < maxUnits; ++i)
            {
                unitsArray[i] = new EnemyUnitObject(game, spriteBatch);
                unitsArray[i].isAlive = false;
                unitsArray[i].position = this.position;
                unitsArray[i].isHoming = true;
                //  unitsArray[i].homingSpeed = 0.05f;
            
                unitsArray[i].wallBounceDampningFactor = wbDampFact;
                
                Game.Components.Add(unitsArray[i]);
            }

            initialHP = 100;
            currentHP = initialHP;

            spawnTargetAngle = 0;
            spawnConeArc = 360;
            spawnTargetVector = new Vector2(0, 0);

            spawnBatchCount = spawnBC;

            isStarted = false;

            scale = 0.5f;

        }


        protected override void LoadContent()
        {

            

            //for (int i=0; i< maxUnits ; ++i)
            //    GameFlowManager.sharedGameFlowManager.getCurrentScreen().collisionList.Add(unitsArray[i]);
            


            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (isStarted)
            {

                if (this.isAlive)
                    handleSpawning(gameTime);

                if (this.isAlive == false)
                {
                    for (int i = 0; i < maxUnits; ++i)
                    {
                        if (unitsArray[i].isAlive)
                        {
                            this.isCompleted = false;
                            break;
                        }
                        else
                        {
                            this.isCompleted = true;
                            
                        }

                    }

                    if (maxUnits == 0)
                        this.isCompleted = true;

                    if(this.isCompleted)
                        this.isStarted = false;
                }

                base.Update(gameTime);
            }

            
        }


        public override void Draw(GameTime gameTime)
        {
        
            base.Draw(gameTime);
        }

        public void setUnitsHomingSpeed(float homingSpeedToSet)
        {
            for (int i = 0; i < maxUnits; i++)
            {
                unitsArray[i].homingSpeed = homingSpeedToSet;
            }
        }

        public void spawnUnit()
        {
            int spawnCounter = 0;

            for (int i = 0; i < maxUnits; ++i)
            {
                if (unitsArray[i].isAlive == false)
                {
                    unitsArray[i].position = this.position;
                    unitsArray[i].isAlive = true;
                    unitsArray[i].isHoming = true;

                    if (this.spawnTargetVector.Length() == 0)
                        unitsArray[i].velocity = GameFlowManager.sharedGameFlowManager.getRandomVector(spawnTargetAngle, spawnConeArc) * spawnInitialExpulsionSpeed;
                    else
                        unitsArray[i].velocity = spawnTargetVector * spawnInitialExpulsionSpeed;

                    unitsArray[i].rotation = GameFlowManager.sharedGameFlowManager.getAngleFromVector(unitsArray[i].velocity);

                    spawnCounter++;

                    if (spawnCounter >= spawnBatchCount)
                        break;
                    else
                        continue;
                }

            }
        }

        private void handleSpawning(GameTime gameTime)
        {
            int intTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            spawnCounter += gameTime.ElapsedGameTime.Milliseconds;

            if (spawnCounter >= spawnCooldown)
            {
                spawnCounter = 0;

                spawnUnit();

            }

        }


    }
}
