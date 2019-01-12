using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBomber2
{
    public interface ISpriteBatch
    {
        void Draw(string _what, int _x, int _y, int _width, int _height);
        void Draw(string _what, int _x, int _y);
        void Draw(int _t_x, int _t_y, string what, int x, int y);
    }
}
