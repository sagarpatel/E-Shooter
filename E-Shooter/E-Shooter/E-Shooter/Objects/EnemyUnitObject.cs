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
    public class EnemyUnitObject : GameObjectAbstract
    {
        public bool isHoming;
        public float homingSpeed;

        public int damageToPlayer;

        public EnemyUnitObject(Game game, SpriteBatch givenSpriteb):base(game, givenSpriteb)
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2((texture.Width / 2) * scale, (texture.Height / 2) * scale);
            position = new Vector2(-100, -100);
            color = Color.Yellow;
            isAlive = false;
            isHoming = false;
            initialHP = 10;
            currentHP = initialHP;

            damageToPlayer = 10;

        }

        protected override void LoadContent()
        {
            

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                updatePV(gameTime);


                if(GameFlowManager.sharedGameFlowManager.player1.isCollidingOtherObject(this.getRect()))
                {
                    GameFlowManager.sharedGameFlowManager.player1.currentHP -= damageToPlayer;
                    this.isAlive = false;
                }
                

            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void updatePV(GameTime gameTime)
        {
            if (isHoming)
            {
                Vector2 playerPosition = GameFlowManager.sharedGameFlowManager.player1.position;
                Vector2 deltaPosition = playerPosition - position;
                velocity += deltaPosition * homingSpeed * gameTime.ElapsedGameTime.Milliseconds / 1000;

                position += velocity * gameTime.ElapsedGameTime.Milliseconds / 1000;

            }
            else
            {
                position += velocity * gameTime.ElapsedGameTime.Milliseconds/ 1000;
            }

        }
    }
}
