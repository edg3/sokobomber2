using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBomber2
{
    public interface ISpriteBatch
    {
        void Draw(string _what, int _x, int _y, int _width, int _height);
        void Draw(string _what, int _x, int _y);
    }
}
