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

            _spriteBatch.Draw("mButtonPlay", 604 + hoverPlay, 25 - hoverPlay);
            _spriteBatch.Draw("mButtonAbout", 604 + hoverAbout, 105 - hoverAbout);

            _spriteBatch.Draw("mTwo", 165, 370);

            _spriteBatch.Draw("mouse", SokoBomber2Engine.Instance.MouseX, SokoBomber2Engine.Instance.MouseY);
        }

        public void Load(IContentManager _content)
        {
            _content.Load("mouse");

            _content.Load("mOptions");
            _content.Load("mButtonAbout");
            _content.Load("mButtonPlay");
            _content.Load("mSokobomber");
            _content.Load("mTwo");

            _content.Load("mDiamond");
            _content.Load("mQuit");
        }

        int hoverPlay = 0;
        int hoverAbout = 0;
        public void Update()
        {
            var mouseX = SokoBomber2Engine.Instance.MouseX;
            var mouseY = SokoBomber2Engine.Instance.MouseY;

            if ((mouseX > 604) && (mouseX < 704) &&
                (mouseY > 20) && (mouseY < 80))
            {
                hoverPlay = 2;
            }
            else
            {
                hoverPlay = 0;
            }

            if ((mouseX > 604) && (mouseX < 704) &&
                (mouseY > 105) && (mouseY < 165))
            {
                hoverAbout = 2;
            }
            else
            {
                hoverAbout = 0;
            }

            if ((hoverPlay != 0) && (SokoBomber2Engine.Instance.MouseLeftClicked))
            {
                SokoBomber2Engine.Instance.AddState(new StatePlay());
            }
            else if ((hoverAbout != 0) && (SokoBomber2Engine.Instance.MouseLeftClicked))
            {
                throw new Exception("About state not implemented.");
            }


        }
    }
}
