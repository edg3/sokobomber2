using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBomber2.States
{
    public interface IState
    {
        void Load(IContentManager _content);
        void Update();
        void Draw(ISpriteBatch _spriteBatch);
    }
}
