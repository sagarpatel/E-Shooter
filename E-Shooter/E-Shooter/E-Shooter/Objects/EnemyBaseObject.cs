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

        public EnemyBaseObject(Game game, SpriteBatch givenSpriteBatch, int maximumUnitCount):base(game, givenSpriteBatch)
        {
            maxUnits = maximumUnitCount;
        }


        protected override void LoadContent()
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2((texture.Width / 2 )* scale, (texture.Height / 2) * scale);
            position = new Vector2(200, 200);
            color = Color.HotPink;
            isAlive = true;

            unitsArray = new EnemyUnitObject[maxUnits];
            for (int i = 0; i < maxUnits; ++i)
            {
                unitsArray[i] = new EnemyUnitObject(game, spriteBatch);
                unitsArray[i].isAlive = false;
                unitsArray[i].position = position;
                unitsArray[i].isHoming = true;
                unitsArray[i].homingSpeed = 0.1f;
                GameFlowManager.sharedGameFlowManager.getCurrentScreen().collisionList.Add(unitsArray[i]);
                Game.Components.Add(unitsArray[i]);
            }


            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            spawnUnits();

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
        
            base.Draw(gameTime);
        }


        public void spawnUnits()
        {
            for (int i = 0; i < maxUnits; ++i)
            {
                if (unitsArray[i].isAlive == false)
                {
                    unitsArray[i].position = new Vector2(400,200);
                    unitsArray[i].isAlive = true;
                    unitsArray[i].isHoming = true;
                    break;
                }

            }
        }

    }
}
