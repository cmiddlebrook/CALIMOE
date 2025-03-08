using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;


namespace CALIMOE
{
    public class AssetManager
    {
        private ContentManager _cm;
        public AssetManager(ContentManager cm)
        {
            _cm = cm;
        }

        public SpriteFont LoadFont(string name)
        {
            return _cm.Load<SpriteFont>("Fonts/" + name);
        }
        public Texture2D LoadTexture(string name)
        {
            return _cm.Load<Texture2D>("Textures/" + name);
        }

        public SoundEffect LoadSoundFx(string name)
        {
            return _cm.Load<SoundEffect>("SoundFx/" + name);
        }

        public Song LoadMusic(string name)
        {
            return _cm.Load<Song>("Music/" + name);
        }
    }
}
