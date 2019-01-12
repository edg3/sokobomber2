using SokoBomber2.States;
using System;
using System.Collections.Generic;

namespace SokoBomber2
{
    public class SokoBomber2Engine
    {
        public ISpriteBatch SpriteBatch { get; }
        public IContentManager Content { get; }
        public SokoBomber2Engine(ISpriteBatch _spriteBatch, IContentManager _content)
        {
            SpriteBatch = _spriteBatch;
            Content = _content;
        }

        private List<IState> States { get; set; }
        public void AddState(IState _state)
        {
            if (States == null) States = new List<IState>();

            _state.Load(Content);
            States.Add(_state);
        }

        public void Update()
        {

        }

        public void Draw()
        {
            try
            {
                States[States.Count - 1].Draw(SpriteBatch);
            }
            catch { }
        }
    }
}
