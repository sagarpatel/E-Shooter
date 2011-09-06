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

        public EnemyBaseObject(Game game, SpriteBatch givenSpriteBatch, int maximumUnitCount):base(game, givenSpriteBatch)
        {
            maxUnits = maximumUnitCount;
            spawnCooldown = 200;

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2((texture.Width / 2) * scale, (texture.Height / 2) * scale);
            color = Color.HotPink;
            isAlive = true;

            unitsArray = new EnemyUnitObject[maxUnits];
            for (int i = 0; i < maxUnits; ++i)
            {
                unitsArray[i] = new EnemyUnitObject(game, spriteBatch);
                unitsArray[i].isAlive = false;
                unitsArray[i].position = position;
                unitsArray[i].isHoming = true;
                //  unitsArray[i].homingSpeed = 0.05f;
                unitsArray[i].scale = 0.5f;
                
                Game.Components.Add(unitsArray[i]);
            }

            initialHP = 100;
            currentHP = initialHP;
        }


        protected override void LoadContent()
        {

            

            for (int i=0; i< maxUnits ; ++i)
                GameFlowManager.sharedGameFlowManager.getCurrentScreen().collisionList.Add(unitsArray[i]);
            


            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
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
            }

            base.Update(gameTime);
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
            for (int i = 0; i < maxUnits; ++i)
            {
                if (unitsArray[i].isAlive == false)
                {
                    unitsArray[i].position = this.position;
                    unitsArray[i].velocity = GameFlowManager.sharedGameFlowManager.getRandomVector(0, 360) * spawnInitialExpulsionSpeed;
                    unitsArray[i].isAlive = true;
                    unitsArray[i].isHoming = true;
                    break;
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
