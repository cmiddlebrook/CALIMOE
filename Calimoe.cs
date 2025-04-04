﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CALIMOE;

public class Calimoe : Game
{
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected AssetManager _am;
    protected SceneManager _sm;
    protected InputHelper _ih;
    protected Random _rand = new Random();
    protected int _fallbackTextureSize = 128;

    protected TimeSpan _fpsTimer;
    protected int _fps = 0;
    protected TextObject _fpsFont;
    protected bool _showFPS = true;

    public Color ClearColour {  get; set; }

    public Calimoe()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.SynchronizeWithVerticalRetrace = true;
        ClearColour = Color.Transparent;

        Content.RootDirectory = "Content";
        _am = new AssetManager(Content, _fallbackTextureSize);
        _sm = new SceneManager(this);
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
        _fpsFont = new TextObject(_am.LoadFont("FPS"), "");
        _fpsFont.Position = new Vector2(4, 4);
    }

    protected override void Update(GameTime gt)
    {
        base.Update(gt);
        _fpsTimer += gt.ElapsedGameTime;
        if (_fpsTimer >= TimeSpan.FromSeconds(1))
        {
            _fpsTimer = TimeSpan.Zero;
            UpdateFPS(gt);
        }
    }

    protected override void Draw(GameTime gt)
    {
        base.Draw(gt);

        _spriteBatch.Begin();
        if (_showFPS)
        {
            _fpsFont.Text = $"FPS: {_fps}";
            _fpsFont.Draw(_spriteBatch);
        }
        _spriteBatch.End();
    }


    protected void UpdateFPS(GameTime gt)
    {
        _fps = (int)Math.Round(1 / gt.ElapsedGameTime.TotalSeconds);
    }
}
