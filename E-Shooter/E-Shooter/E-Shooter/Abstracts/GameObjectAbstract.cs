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
    public abstract class GameObjectAbstract : Microsoft.Xna.Framework.DrawableGameComponent
    {

        protected SpriteBatch spriteBatch;
        protected Game game;
        public Texture2D texture;

        public bool isAlive;

        public Vector2 position;
        public Vector2 velocity;

        public Vector2 facing;

        public Vector2 origin;

        public float rotation;
        public float scale;
        public Color color;

        public bool isWallBounce;
        public float wallBounceDampningFactor;

        public int currentHP;
        public int initialHP;

        public float speed;

        public GameObjectAbstract(Game givenGameame, SpriteBatch givenSpriteBatch):base(givenGameame)
        {

            spriteBatch = givenSpriteBatch;
            game = givenGameame;

            isAlive = false;
            position = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
            facing = new Vector2(0, 0);

            color = Color.White;
            origin = new Vector2(0, 0);
            rotation = 0f;
            scale = 1f;

            isWallBounce = true;

            initialHP = 100;
            currentHP = initialHP;

            wallBounceDampningFactor = 1f;

            speed = 1.0f;
        }


        public override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            origin = new Vector2((texture.Width / 2) * scale, (texture.Height / 2) * scale);

            base.LoadContent();
        }


        protected override void Dispose(bool disposing)
        {
            texture.Dispose();
            spriteBatch.Dispose();
            game.Dispose();
            base.Dispose(disposing);
        }



        public override void Update(GameTime gameTime)
        {
            if (this.isAlive)
            {
                if (isWallBounce)
                    wallBounce();


                if (currentHP <= 0)
                    this.isAlive = false;
            }

            if (isAlive == false)
                this.reset();

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            if (isAlive)
                spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, SpriteEffects.None, 0f);

            base.Draw(gameTime);
        }

        // Custom functions

        public Rectangle getRect()
        {
            Rectangle myRect = new Rectangle((int)(position.X - origin.X), (int)(position.Y - origin.Y), (int)(texture.Width * scale), (int)(texture.Height * scale));
            return myRect;
        }

        public bool isInsideScreen()
        {
            Rectangle myRect = getRect();
            return (Game1.screenRectangle.Contains(myRect));
        }

        public bool isIntersectingScreen()
        {
            Rectangle myRect = getRect();
            return (Game1.screenRectangle.Intersects(myRect));
        }

        // smaller object must passed as otherObjRect
        public bool isCollidingOtherObject(Rectangle otherObjRect)
        {
            Rectangle myRect = getRect();
            if (myRect.Intersects(otherObjRect) || myRect.Contains(otherObjRect))
                return true;
            else
                return false;
                        
        }

        public void reset()
        {
            this.position = new Vector2(0, 0);
            this.velocity = new Vector2(0, 0);
            this.speed = 1.0f;
            this.rotation = 0f;
            this.currentHP = this.initialHP;
            this.isAlive = false;

        }

        private void wallBounce()
        {
            float leftBound = this.position.X - this.texture.Width*this.scale/2;
            float rightBound = this.position.X + this.texture.Width*this.scale/2;
            float topBound = this.position.Y - this.texture.Height*this.scale/2;
            float bottomBound = this.position.Y + this.texture.Height*this.scale/2;

            if (leftBound <= 0 || rightBound >= Game1.screenWidth)
                this.velocity.X = -this.velocity.X * wallBounceDampningFactor;
            if (topBound <= 0 || bottomBound >= Game1.screenHeight)
                this.velocity.Y = -this.velocity.Y * wallBounceDampningFactor;
        }
    }

}