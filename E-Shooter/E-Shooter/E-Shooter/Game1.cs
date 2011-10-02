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
  

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int screenWidth;
        public static int screenHeight;
        public static Rectangle screenRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            screenWidth = 800;
            screenHeight = 480;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;


            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight; 

        }

    

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Add texture to texture manager here
            TextureManager.sharedTextureManager.addTexture("Player1Sprite", Content.Load<Texture2D>("Sprites/FullCircle1"));
            TextureManager.sharedTextureManager.addTexture("EnemyUnit1", Content.Load<Texture2D>("Sprites/tempTri3"));
            

            InputManager.myGame = this;

            GameFlowManager.myGame = this;
            GameFlowManager.mySpriteBatch = spriteBatch;
            GameFlowManager.sharedGameFlowManager.manualInit();


      
            Components.Add(InputManager.sharedInputManager);
            Components.Add(GameFlowManager.sharedGameFlowManager);
      

            base.Initialize();
        }



        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }




        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }




        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            //if (InputManager.sharedInputManager.getFlickDelta().Length() > 0)
            //    this.Exit();


            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
          //  GameFlowManager.sharedGameFlowManager.player1.spriteBatch = spriteBatch;

           // spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);



            //goes through all component's respective Draw() methods 
            base.Draw(gameTime);

            spriteBatch.End();

        }


    }
}
