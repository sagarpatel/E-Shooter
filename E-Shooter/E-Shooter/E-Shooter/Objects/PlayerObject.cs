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

    public class PlayerObject : GameObjectAbstract
    {

        public PlayerObject(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {

        }


        protected override void LoadContent()
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            position = new Vector2(0, 0);
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            position = InputManager.sharedInputManager.getTouchPosition();

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

           
            spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);

            base.Draw(gameTime);
        }


    }




}
