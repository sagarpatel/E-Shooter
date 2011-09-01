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

        List<ScreenAbstract> screenList;
        int currentScreenIndex;

        private GameFlowManager(Game game, SpriteBatch mySpriteBatch): base(game)
        {
            screenList = new List<ScreenAbstract>();
            currentScreenIndex = 0;
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
           

        }


        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            ScreenAbstract currentScreen = screenList[currentScreenIndex];
            if ( currentScreen.isComplete == true)
            {
                myGame.Components.Remove(currentScreen);
                currentScreen.Dispose();

                currentScreenIndex ++;

                ScreenAbstract newScreen = screenList[currentScreenIndex];
                newScreen.isActive = true;
                myGame.Components.Add(newScreen);
            }

            base.Update(gameTime);
        }

    }
}
