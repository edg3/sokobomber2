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
        private Rectangle TexRect;
        public ESpriteBatch(EContentManager _eContentManager, SpriteBatch _spriteBatch)
        {
            ContentManager = _eContentManager;
            SpriteBatch = _spriteBatch;

            DrawRect = new Rectangle();
            TexRect = new Rectangle(0, 0, 32, 32);
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

        public void Draw(string _what, int _x, int _y)
        {
            if (ContentManager.Textures.ContainsKey(_what))
            {
                DrawRect.X = _x;
                DrawRect.Y = _y;

                var sprite = ContentManager.Textures[_what];
                DrawRect.Width = sprite.Width;
                DrawRect.Height = sprite.Height;

                SpriteBatch.Draw(ContentManager.Textures[_what], DrawRect, Color.White);
            }
        }

        public void Draw(int _t_x, int _t_y, string _what, int _x, int _y)
        {
            if (ContentManager.Textures.ContainsKey(_what))
            {
                TexRect.X = _t_x * 32;
                TexRect.Y = _t_y * 32;

                DrawRect.X = _x;
                DrawRect.Y = _y;

                DrawRect.Width = 32;
                DrawRect.Height = 32;

                SpriteBatch.Draw(ContentManager.Textures[_what], DrawRect, TexRect, Color.White);
            }
        }
    }
}
