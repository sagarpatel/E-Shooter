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

        public EnemyBaseObject(Game game, SpriteBatch givenSpriteBatch):base(game, givenSpriteBatch)
        {

        }


        protected override void LoadContent()
        {

            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            origin = new Vector2((texture.Width / 2 )* scale, (texture.Height / 2) * scale);
            position = new Vector2(0, 0);
            color = Color.HotPink;
            isAlive = true;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            position = new Vector2(200, 200);

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
        
            base.Draw(gameTime);
        }



    }
}
