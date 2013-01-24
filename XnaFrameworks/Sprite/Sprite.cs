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
        public GraphicsDevice GraphicsDevice { get; protected set; }

        private SpriteBatch _SpriteBatch;
        public SpriteBatch SpriteBatch
        { get { return _SpriteBatch = _SpriteBatch ?? new SpriteBatch(GraphicsDevice); } }

        private List<Sprite> _sprites;
        public List<Sprite> Sprites { get { return _sprites.AsReadOnly().ToList(); } }

        public RuntimeAsset<Texture2D> RuntimeAsset { get; protected set; }

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

        private Vector2 _size;
        public Vector2 Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private Vector2 _velocity;
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        protected Sprite(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }
    }
}
