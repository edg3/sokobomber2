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
            _spriteBatch.Draw("mSokobomber", 0, 0);
            _spriteBatch.Draw("mOptions", 550, 0);

            _spriteBatch.Draw("mButtonPlay", 604, 25);
            _spriteBatch.Draw("mButtonAbout", 604, 105);

            _spriteBatch.Draw("mTwo", 165, 370);
        }

        public void Load(IContentManager _content)
        {
            _content.Load("mOptions");
            _content.Load("mButtonAbout");
            _content.Load("mButtonPlay");
            _content.Load("mSokobomber");
            _content.Load("mTwo");

            _content.Load("mDiamond");
            _content.Load("mQuit");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
