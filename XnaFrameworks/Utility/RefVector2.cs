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

namespace XnaFrameworks.Utility
{
    public class RefVector2
    {
        public Vector2 Vector2;

        public RefVector2()
        {
            Vector2 = default(Vector2);
        }

        public RefVector2(Vector2 vector2)
        {
            Vector2 = vector2;
        }

    }
}
