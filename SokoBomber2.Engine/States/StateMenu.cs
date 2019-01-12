using SokoBomber2.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBomber2.Engine.States
{
    public class StateMenu : IState
    {
        public void Draw(ISpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw("mOptions", 0, 0, 100, 100);
        }

        public void Load(IContentManager _content)
        {
            _content.Load("mOptions");
            _content.Load("mButtonAbout");
            _content.Load("mButtonPlay");
            _content.Load("mDiamond");
            _content.Load("mQuit");
            _content.Load("mSokobomber");
            _content.Load("mTwo");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
