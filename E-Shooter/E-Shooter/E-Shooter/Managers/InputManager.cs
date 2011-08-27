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
using Microsoft.Xna.Framework.Input.Touch;


namespace E_Shooter
{

    public sealed class InputManager : Microsoft.Xna.Framework.GameComponent
    {
        public static Game myGame;
        private static readonly InputManager instance = new InputManager(myGame);

        private Vector2 flickDelta;
        private Vector2 tapPosition;

        private InputManager(Game game): base(game)
        {
            TouchPanel.EnabledGestures = GestureType.Flick | GestureType.Tap;
        }

        public static InputManager sharedInputManager
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


        public override void Update(GameTime gameTime)
        {

            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gs = TouchPanel.ReadGesture();
                switch (gs.GestureType)
                {
                    case GestureType.Flick:
                        handleFlick(gs.Delta);
                        break;

                    case GestureType.Tap:
                        handleTap(gs.Position);
                        break;

                }
            }


            base.Update(gameTime);
        }


        #region Custom functions



        #region Private variable handlers
        private void handleFlick(Vector2 deltaF)
        {
            flickDelta = deltaF;
        }
        private void handleTap(Vector2 position)
        {
            tapPosition = position;
        }
        #endregion



        #region Public variable getter functions
        public Vector2 getFlickDelta()
        {
            Vector2 temp = flickDelta;
            flickDelta = new Vector2(0, 0);

            return temp;
        }
        public Vector2 getTapPosition()
        {
            Vector2 temp = tapPosition;
            tapPosition = new Vector2(0, 0);

            return temp;
        }
        #endregion



        #endregion



    }



}
