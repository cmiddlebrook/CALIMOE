using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CALIMOE;

public class Calimoe : Game
{
    // Graphics
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected int _fallbackTextureSize = 128;
    protected Matrix _spriteScale = Matrix.Identity;
    protected Point _windowSize;
    protected Point _worldSize;

    // Systems
    protected InputHelper _ih;
    protected SceneManager _sm;

    // FPS
    protected int _fps = 0;
    protected TimeSpan _fpsTimer;
    protected TextObject _fpsFont;

    // Properties
    public static AssetManager AssetManager { get; private set; }
    public static Color NoColour => Color.White;
    public static Random Random { get; private set; } = new Random();

    public Color ClearColour {  get; set; }

    protected bool FullScreen
    {
        get { return _graphics.IsFullScreen; }
        set { ApplyResolution(value); }
    }

    protected bool ShowFPS { get; set; } = true;

    public Calimoe()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.SynchronizeWithVerticalRetrace = true;
        ClearColour = Color.Transparent;

        Content.RootDirectory = "Content";
        _sm = new SceneManager();
        _ih = new InputHelper();

        IsMouseVisible = true;
        FullScreen = false;
    }

    protected void ApplyResolution(bool fullScreen)
    {
        _graphics.IsFullScreen = fullScreen;

        Point screenSize;
        if (fullScreen)
        {
            screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
        }
        else
        {
            screenSize = _windowSize;
        }

        _graphics.PreferredBackBufferWidth = screenSize.X;
        _graphics.PreferredBackBufferHeight = screenSize.Y;
        _graphics.ApplyChanges();

        GraphicsDevice.Viewport = CalculateViewport(screenSize);
        _spriteScale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / _worldSize.X,
            (float)GraphicsDevice.Viewport.Height / _worldSize.Y, 1.0f);
        _sm.SetSpriteScale(_spriteScale);
    }

    protected Viewport CalculateViewport(Point windowSize)
    {
        Viewport viewport = new Viewport();
        float gameAspectRatio = (float)_worldSize.X / _worldSize.Y;
        float windowAspectRatio = (float)windowSize.X / windowSize.Y;

        if (windowAspectRatio > gameAspectRatio)
        {
            viewport.Width = (int)(windowSize.Y * gameAspectRatio);
            viewport.Height = windowSize.Y;
        }
        else
        {
            viewport.Width = windowSize.X;
            viewport.Height = (int)(windowSize.X / gameAspectRatio);
        }

        viewport.X = (windowSize.X - viewport.Width) / 2;
        viewport.Y = (windowSize.Y - viewport.Height) / 2;

        return viewport;
    }

    protected override void Draw(GameTime gt)
    {
        base.Draw(gt);

        // this _spritescale needs to be applied to my SCENE Draw code!

        _spriteBatch.Begin();
        if (ShowFPS)
        {
            _fpsFont.Text = $"FPS: {_fps}";
            _fpsFont.Draw(_spriteBatch);
        }
        _spriteBatch.End();
    }

    protected override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        AssetManager = new AssetManager(Content);
        _fpsFont = new TextObject(AssetManager.LoadFont("FPS"), "");
        _fpsFont.Position = new Vector2(4, 4);
    }

    protected Vector2 ScreenToWorld(Vector2 screenPosition)
    {
        Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
        Vector2 adjusted = screenPosition - viewportTopLeft;
        Matrix inverse = Matrix.Invert(_spriteScale);
        return Vector2.Transform(adjusted, inverse);
    }

    protected void SetTargetFPS(int fps)
    {
        this.TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / fps);
    }


    protected override void Update(GameTime gt)
    {
        base.Update(gt);

        if (ShowFPS)
        {
            _fpsTimer += gt.ElapsedGameTime;
            if (_fpsTimer >= TimeSpan.FromSeconds(1))
            {
                _fpsTimer = TimeSpan.Zero;
                UpdateFPS(gt);
            }
        }

    }


    protected void UpdateFPS(GameTime gt)
    {
        _fps = (int)Math.Round(1 / gt.ElapsedGameTime.TotalSeconds);
    }
}
