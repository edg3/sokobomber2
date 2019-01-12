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
        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Load(IContentManager _content)
        {
            _content.Load("mOptions");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
