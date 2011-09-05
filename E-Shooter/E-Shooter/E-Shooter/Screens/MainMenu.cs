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
    public class MainMenu: ScreenAbstract
    {
        public EnemyBaseObject enemyBase1;
        

        public MainMenu(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {
            enemyBase1 = new EnemyBaseObject(game, givenSpriteBatch,20);
            enemyBase1.position = new Vector2(400, 240);
            enemyBase1.spawnInitialExpulsionSpeed = 50f;
            collisionList.Add(enemyBase1);
        }



        protected override void LoadContent()
        {

            base.LoadContent();

            
            Game.Components.Add(enemyBase1);

            isLoaded = true;
        }


        public override void Draw(GameTime gameTime)
        {
            if (isLoaded)
            {
                base.Draw(gameTime);
            }
        }



    }
}
