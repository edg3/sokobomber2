using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBomber2.CrossPlatform.EngineInterfaces
{
    class EContentManager : IContentManager
    {
        public ContentManager Content { get; private set; }
        public EContentManager(ContentManager _content)
        {
            Content = _content;
            Textures = new Dictionary<string, Texture2D>();
        }

        public Dictionary<string, Texture2D> Textures { get; private set; }
        public void Load(string _name)
        {
            if (!Textures.ContainsKey(_name))
            {
                Textures.Add(_name, Content.Load<Texture2D>(_name));
            }
        }
    }
}
