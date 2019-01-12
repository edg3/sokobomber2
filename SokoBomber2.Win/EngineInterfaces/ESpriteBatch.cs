using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SokoBomber2;

namespace SokoBomber2.Win.EngineInterfaces
{
    class ESpriteBatch : ISpriteBatch
    {
        private EContentManager ContentManager;
        public SpriteBatch SpriteBatch { get; private set; }
        private Rectangle DrawRect;
        public ESpriteBatch(EContentManager _eContentManager, SpriteBatch _spriteBatch)
        {
            ContentManager = _eContentManager;
            SpriteBatch = _spriteBatch;

            DrawRect = new Rectangle();
        }

        public void Draw(string _what, int _x, int _y, int _width, int _height)
        {
            if (ContentManager.Textures.ContainsKey(_what))
            {
                DrawRect.X = _x;
                DrawRect.Y = _y;
                DrawRect.Width = _width;
                DrawRect.Height = _height;

                SpriteBatch.Draw(ContentManager.Textures[_what], DrawRect, Color.White);
            }
        }
    }
}
