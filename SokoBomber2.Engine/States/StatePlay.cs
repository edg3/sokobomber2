using SokoBomber2.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBomber2.Engine.States
{
    class StatePlay : IState
    {
        public void Draw(ISpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw("mouse", SokoBomber2Engine.Instance.MouseX, SokoBomber2Engine.Instance.MouseY);
        }

        public void Load(IContentManager _content)
        {
            // Art
            _content.Load("tBomb");
            _content.Load("tDiamond");
            _content.Load("tFragments");
            _content.Load("tFuseLit");
            _content.Load("tGround");
            _content.Load("tIce");
            _content.Load("tPlayerDead");
            _content.Load("tPlayerDown");
            _content.Load("tPlayerIdle");
            _content.Load("tPlayerLeft");
            _content.Load("tPlayerUp");
            _content.Load("tTriggerPosition");
            _content.Load("tWall");

            // Level
        }
        
        public void Update()
        {

        }
    }
}
