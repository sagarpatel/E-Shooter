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
    public sealed class GameFlowManager : Microsoft.Xna.Framework.GameComponent
    {

        public static Game myGame;
        public static SpriteBatch mySpriteBatch;
        private static readonly GameFlowManager instance = new GameFlowManager(myGame,mySpriteBatch);

        public PlayerObject player1;
        public MainMenu mainMenu;
        public Level_1_1 level_1_1;
        public Level_1_2 level_1_2;
        public Level_1_3 level_1_3;
        public Level_1_4 level_1_4;
        public Level_1_5 level_1_5;
        //simple levels end

        //targeted spawning levels begin
        public Level_2_1 level_2_1;
        


        List<ScreenAbstract> screenList;
        ScreenAbstract currentScreen;

        Random rand;

        private GameFlowManager(Game game, SpriteBatch mySpriteBatch): base(game)
        {
            screenList = new List<ScreenAbstract>();
            rand = new Random();
        }

        public static GameFlowManager sharedGameFlowManager
        {
            get
            {
                return instance;
            }

        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public void manualInit()
        {

            player1 = new PlayerObject(myGame, mySpriteBatch);
            player1.scale = 0.75f;
            player1.position = new Vector2(400, 450);
            myGame.Components.Add(player1);

            mainMenu = new MainMenu(myGame, mySpriteBatch);
            mainMenu.isActive = true;
            screenList.Add(mainMenu);
            myGame.Components.Add(mainMenu);

            level_1_1 = new Level_1_1(myGame, mySpriteBatch);
            level_1_1.isActive = false;
            screenList.Add(level_1_1);

            level_1_2 = new Level_1_2(myGame, mySpriteBatch);
            level_1_2.isActive = false;
            screenList.Add(level_1_2);

            level_1_3 = new Level_1_3(myGame, mySpriteBatch);
            level_1_3.isActive = false;
            screenList.Add(level_1_3);

            level_1_4 = new Level_1_4(myGame, mySpriteBatch);
            level_1_4.isActive = false;
            screenList.Add(level_1_4);

            level_1_5 = new Level_1_5(myGame, mySpriteBatch);
            level_1_5.isActive = false;
            screenList.Add(level_1_5);

            level_2_1 = new Level_2_1(myGame, mySpriteBatch);
            level_2_1.isActive = false;
            screenList.Add(level_2_1);

            currentScreen = mainMenu;
           

        }


        public override void Update(GameTime gameTime)
        {

            if ( currentScreen.isComplete == true)
            {
                myGame.Components.Remove(currentScreen);
              //  currentScreen.Dispose();
                

                foreach(ScreenAbstract screen in screenList)
                {
                    if (screen.GetType() == currentScreen.nextScreenType)
                    {
                        screen.isActive = true;
                        screen.setInitialValues();
                        myGame.Components.Add(screen);
                        currentScreen = screen;
                        break;
                    }
                }

                
            }

            base.Update(gameTime);
        }



        //Custom functions

        public ScreenAbstract getCurrentScreen()
        {
            return currentScreen;
        }

        public Vector2 getRandomVector(int targetAngle, int coneArc)
        {
            int maxAngle = targetAngle + coneArc / 2;
            int minAngle = targetAngle - coneArc / 2;
            int randomAngle = rand.Next(minAngle, maxAngle);
            Vector2 randomVector = new Vector2(1, 0);
            randomVector = Vector2.Transform(randomVector, Matrix.CreateRotationZ(MathHelper.ToRadians((float)randomAngle)));
            return randomVector;
        }

    }
}
