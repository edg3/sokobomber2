using SokoBomber2.States;
using System;
using System.Collections.Generic;

namespace SokoBomber2
{
    public class SokoBomber2Engine
    {
        private static SokoBomber2Engine _instance;
        public static SokoBomber2Engine Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }

        public ISpriteBatch SpriteBatch { get; }
        public IContentManager Content { get; }
        public SokoBomber2Engine(ISpriteBatch _spriteBatch, IContentManager _content)
        {
            SpriteBatch = _spriteBatch;
            Content = _content;
            Instance = this;
        }

        public int MouseX { get; private set; }
        public int MouseY { get; private set; }
        public bool MouseLeftClicked { get; private set; }
        public bool MouseLeftHeld { get; private set; }
        public bool MouseRightClicked { get; private set; }
        public bool MouseRightHeld { get; private set; }
        public void TrackMouse(int _x, int _y, bool _leftClick, bool _previousLeftClick, bool _rightClick, bool _previousRightClick)
        {
            MouseX = _x;
            MouseY = _y;

            if (_leftClick)
            {
                if (!_previousLeftClick)
                {
                    MouseLeftClicked = true;
                    MouseLeftHeld = false;
                }
                else
                {
                    MouseLeftHeld = true;
                    MouseLeftClicked = false;
                }
            }
            else
            {
                MouseLeftHeld = false;
                MouseLeftClicked = false;
            }

            if (_rightClick)
            {
                if (!_previousLeftClick)
                {
                    MouseRightClicked = true;
                    MouseRightHeld = false;
                }
                else
                {
                    MouseRightHeld = true;
                    MouseRightClicked = false;
                }
            }
            else
            {
                MouseRightHeld = false;
                MouseRightClicked = false;
            }
        }

        public bool KeyLeftPressed { get; private set; }
        public bool KeyRightPressed { get; private set; }
        public bool KeyUpPressed { get; private set; }
        public bool KeyDownPressed { get; private set; }
        public void KeyboardInput(bool _leftPressed, bool _rightPressed, bool _upPressed, bool _downPressed)
        {
            KeyLeftPressed = _leftPressed;
            KeyRightPressed = _rightPressed;
            KeyUpPressed = _upPressed;
            KeyDownPressed = _downPressed;
        }

        private List<IState> States { get; set; }
        public void AddState(IState _state)
        {
            if (States == null) States = new List<IState>();

            _state.Load(Content);
            States.Add(_state);
        }

        public void Update()
        {
            if (States != null)
            {
                States[States.Count - 1].Update();
            }
        }

        public void Draw()
        {
            try
            {
                States[States.Count - 1].Draw(SpriteBatch);
            }
            catch { }
        }
    }
}
