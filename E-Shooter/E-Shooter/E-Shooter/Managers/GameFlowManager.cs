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
        public Level_2_2 level_2_2;
        public Level_2_3 level_2_3;
        public Level_2_4 level_2_4;
        public Level_2_5 level_2_5;

        //hmoing bases begin
        public Level_3_1 level_3_1;


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

            level_2_2 = new Level_2_2(myGame, mySpriteBatch);
            level_2_2.isActive = false;
            screenList.Add(level_2_2);

            level_2_3 = new Level_2_3(myGame, mySpriteBatch);
            level_2_3.isActive = false;
            screenList.Add(level_2_3);

            level_2_4 = new Level_2_4(myGame, mySpriteBatch);
            level_2_4.isActive = false;
            screenList.Add(level_2_4);


            level_2_5 = new Level_2_5(myGame, mySpriteBatch);
            level_2_5.isActive = false;
            screenList.Add(level_2_5);


            level_3_1 = new Level_3_1(myGame, mySpriteBatch);
            level_3_1.isActive = false;
            screenList.Add(level_3_1);

            setInitialValues();

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


            //  erset to main menu if player dies
            if (player1.isAlive == false)
            {
                currentScreen.isActive = false;
                currentScreen.isComplete = true;
                myGame.Components.Remove(currentScreen);
                mainMenu.isActive = true;
                mainMenu.setInitialValues();
                myGame.Components.Add(mainMenu);
                currentScreen = mainMenu;
                setInitialValues();
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
            Vector2 randomVector = new Vector2(-1, 0);
            randomVector = Vector2.Transform(randomVector, Matrix.CreateRotationZ(MathHelper.ToRadians((float)randomAngle)));
            return randomVector;
        }

        public void setInitialValues()
        {
            player1.scale = 1f;
            player1.position = new Vector2(400, 450);
            player1.initialHP = 200;
            player1.currentHP = player1.initialHP;
            player1.isAlive = true;

        }


    }
}
