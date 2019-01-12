using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SokoBomber2.Engine.States;
using SokoBomber2.Win.EngineInterfaces;

namespace SokoBomber2.Win
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public SokoBomber2Engine SokoBomber2Engine { get; private set; }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var eContentManage = new EContentManager(Content);
            var eSpriteBatch = new ESpriteBatch(eContentManage, spriteBatch);
            SokoBomber2Engine = new SokoBomber2Engine(eSpriteBatch, eContentManage);

            SokoBomber2Engine.AddState(new StateMenu());
        }

        KeyboardState PreviousKeyboardState;
        KeyboardState _currentKeyboardState;
        KeyboardState CurrentKeyboardState {
            get {
                return _currentKeyboardState;
            }
            set {
                PreviousKeyboardState = _currentKeyboardState;
                _currentKeyboardState = value;
            }
        }
        MouseState PreviousMouseState;
        MouseState _currentMouseState;
        MouseState CurrentMouseState
        {
            get
            {
                return _currentMouseState;
            }
            set
            {
                PreviousMouseState = _currentMouseState;
                _currentMouseState = value;
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            CurrentKeyboardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();

            SokoBomber2Engine.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            SokoBomber2Engine.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent() { }
    }
}
