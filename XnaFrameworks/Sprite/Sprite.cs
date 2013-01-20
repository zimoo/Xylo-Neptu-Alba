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

namespace XnaFramework.Sprite
{
    public abstract class Sprite
    {
        public GraphicsDeviceManager GraphicsDeviceManager { get; protected set; }

        public GraphicsDevice GraphicsDevice
        { get { return GraphicsDeviceManager.GraphicsDevice; } }

        private SpriteBatch _SpriteBatch;
        public SpriteBatch SpriteBatch
        { get { return _SpriteBatch = _SpriteBatch ?? new SpriteBatch(GraphicsDevice); } }

        private Vector2 _center;
        public Vector2 Center
        {
            get { return _center; }
            set { _center = value; }
        }

        private Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Sprite(GraphicsDeviceManager graphicsDeviceManager)
        {
            GraphicsDeviceManager = graphicsDeviceManager;
        }
    }
}
