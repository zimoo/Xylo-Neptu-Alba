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

namespace XnaFramework.Demos.InputDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class InputDemoGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private KeyboardState _keyState;
        private Keys[] _keys;
        private MouseState _mouseState;
        private GamePadState _gamePadState;

        public InputDemoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("SegoeUIMono");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            _keyState = Keyboard.GetState();
            if (_keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            UpdateKeyboard();
            UpdateMouse();
            UpdateGamePad();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateKeyboard()
        {
            _keys = _keyState.GetPressedKeys();

            int x = 20;
            int y = 180;
            const int offset = 20;

            Print(x, y, "KEYBOARD STATE");
            y += offset;

            Print(x, y, "Keys being pressed: ");
            y += offset;

            foreach (Keys key in _keys)
            {
                Print(x + 10, y, key.ToString());
                y += offset;
            }
        }

        private void UpdateMouse()
        {
            var x = 20;
            var y = 20;
            const int offset = 20;

            Print(x, y, "MOUSE STATE");
            y += offset;

#if WINDOWS
            _mouseState = Mouse.GetState();

            Print(x, y, "Left Button: " + _mouseState.LeftButton.ToString());
            y += offset;

            Print(x, y, "Right Button: " + _mouseState.RightButton.ToString());
            y += offset;

            Print(x, y, "Middle Button: " + _mouseState.MiddleButton.ToString());
            y += offset;

            Print(x, y, "Scroll Wheel: " + _mouseState.ScrollWheelValue.ToString());
            y += offset;

            Print(x, y, "Position: " + _mouseState.X.ToString() + ", " + _mouseState.Y.ToString());
            y += offset;
#else
            Print(x, y, "Mouse Not Supported on XBOX 360");
#endif
        }

        private void UpdateGamePad()
        {
            var x = 400;
            var y = 20;
            const int offset = 20;

            Print(x, y, "CONTROLLER STATE");
            y += offset;

            GamePadCapabilities capabilities;
            for (PlayerIndex p = PlayerIndex.One; p <= PlayerIndex.Four; p++)
            {
                capabilities = GamePad.GetCapabilities(p);
                Print(x, y, "GamePad " + p.ToString() + " : " + capabilities.IsConnected.ToString());
                y += offset;
            }

            _gamePadState = GamePad.GetState(PlayerIndex.One);

            Print(x, y, "Buttons: " + _gamePadState.Buttons.ToString());
            y += offset;

            Print(x, y, "DPad: " + _gamePadState.DPad.ToString());
            y += offset;

            Print(x, y, "Triggers: " + _gamePadState.Triggers.ToString());
            y += offset;

            Print(x, y, "Left Thumb: " + _gamePadState.ThumbSticks.Left.ToString());
            y += offset;

            Print(x, y, "Right Thumb: " + _gamePadState.ThumbSticks.Right.ToString());
            y += offset;
        }

        private void Print(int x, int y, string text)
        {
            Print(x, y, text, Color.White);
        }

        private void Print(int x, int y, string text, Color color)
        {
            _spriteBatch.DrawString(
                _font,
                text,
                new Vector2(x, y),
                color
            );
        }
    }
}
