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
        private SoundEffect _silentSoundFx;
        private Song _silentSong;
        private Texture2D _missingTexture;
        public AssetManager(ContentManager cm, int fallbackTextureSize)
        {
            _cm = cm;
            _silentSoundFx = _cm.Load<SoundEffect>("Fallback/silent-fx");
            _silentSong = _cm.Load<Song>("Fallback/silent-song");
            _missingTexture = _cm.Load<Texture2D>($"Fallback/missing-tx{fallbackTextureSize}");
        }

        public SpriteFont LoadFont(string name)
        {
            return _cm.Load<SpriteFont>("Fonts/" + name);
        }
        public Texture2D LoadTexture(string name)
        {
            try
            {
                return _cm.Load<Texture2D>("Textures/" + name);
            }
            catch (Exception)
            {
                return _missingTexture;
            }
        }

        public SoundEffect LoadSoundFx(string name)
        {
            try
            {
                return _cm.Load<SoundEffect>("SoundFx/" + name);
            }
            catch (Exception)
            {
                return _silentSoundFx;
            }
        }

        public Song LoadMusic(string name)
        {
            try
            {
                return _cm.Load<Song>("Music/" + name);
            }
            catch (Exception)
            {
                return _silentSong;
            }
        }

    }
}
