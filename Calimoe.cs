using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CALIMOE;

public class Calimoe : Game
{
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected AssetManager _am;
    protected StateManager _sm;
    protected InputHelper _ih;
    protected Random _rand = new Random();
    protected int _fallbackTextureSize = 128;

    protected int _fps = 0;
    protected TextObject _fpsFont;
    protected bool _showFPS = false;

    public Calimoe()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        _am = new AssetManager(Content, _fallbackTextureSize);
        _sm = new StateManager();
        _ih = new InputHelper();

        IsMouseVisible = true;
    }

    protected void StartFullScreen()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();
    }

    protected void SetTargetFPS(int fps)
    {
        this.TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / fps);
    }

    protected override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // this was the hack to create a 1 pixel texture for drawing simple shapes
        //Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
        //Globals.pixel.SetData<Color>([Color.White]);

        _am.LoadContent();
        _fpsFont = new TextObject(_am.LoadFont("FPS"), "", new Vector2(4, 4));
    }

    protected override void Update(GameTime gt)
    {
        base.Update(gt);
        UpdateFPS(gt);
    }

    protected override void Draw(GameTime gt)
    {
        base.Draw(gt);

        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        if (_showFPS)
        {
            _fpsFont.DrawText(_spriteBatch, $"FPS: {_fps}");
        }
        _spriteBatch.End();
    }

    protected void UpdateFPS(GameTime gt)
    {
        _fps = (int)Math.Round(1 / gt.ElapsedGameTime.TotalSeconds);
    }
}
