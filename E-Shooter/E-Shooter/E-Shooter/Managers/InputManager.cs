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
        private Vector2 touchPosition;
        private bool isDoubleTap;

        private InputManager(Game game): base(game)
        {
            TouchPanel.EnabledGestures = GestureType.Flick | GestureType.Tap | GestureType.DoubleTap;
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

            // Handle Gestures

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

                    case GestureType.DoubleTap:
                        handleDoubleTap();
                        break;

                }
            }

            // Handle touch locations

            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation thisTouchLocation in touchCollection)
            {
                if (thisTouchLocation.State == TouchLocationState.Pressed || thisTouchLocation.State == TouchLocationState.Moved)
                {
                    handleTouch(thisTouchLocation.Position);
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
        private void handleTouch(Vector2 position)
        {
            touchPosition = position;
        }
        private void handleDoubleTap()
        {
            isDoubleTap = true;
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
            return tapPosition;
        }
        public Vector2 getTouchPosition()
        {
            return touchPosition;
        }
        public bool getIsDoubleTap()
        {
            if (isDoubleTap)
            {
                isDoubleTap = false;
                return true;
            }
            else
                return false;
        }
        #endregion



        #endregion



    }



}
