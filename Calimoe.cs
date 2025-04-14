using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CALIMOE;

public abstract class Calimoe : Game
{
    // Graphics
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected int _fallbackTextureSize = 128;
    protected Matrix _spriteScale = Matrix.Identity;
    protected Point _windowSize = new Point(1280, 720);
    protected Point _worldSize = new Point(1280, 720);

    // Systems
    protected InputHelper _ih = new InputHelper();

    // FPS
    protected int _fps = 0;
    protected TimeSpan _fpsTimer;
    protected TextObject _fpsFont;

    // statics
    public static AssetManager AssetManager { get; protected set; }
    protected static SceneManager _sm = new SceneManager();

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

        Content.RootDirectory = "Content";

        IsMouseVisible = true;
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
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _spriteScale);

        if (ShowFPS)
        {
            _fpsFont.Text = $"FPS: {_fps}";
            _fpsFont.Draw(_spriteBatch);
        }

        _sm.Draw(_spriteBatch);

        _spriteBatch.End();
    }

    protected virtual void HandleInput()
    {
        _ih.Update();

        if (_ih.KeyPressed(Keys.F5)) FullScreen = !FullScreen;

        _sm.HandleInput(_ih);
    }


    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        AssetManager = new AssetManager(Content);
        FullScreen = false;
        _fpsFont = new TextObject(AssetManager.LoadFont("FPS"), "");
        _fpsFont.LocalPosition = new Vector2(4, 4);
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
        HandleInput();

        if (ShowFPS)
        {
            _fpsTimer += gt.ElapsedGameTime;
            if (_fpsTimer >= TimeSpan.FromSeconds(1))
            {
                _fpsTimer = TimeSpan.Zero;
                UpdateFPS(gt);
            }
        }

        _sm.Update(gt);
    }


    protected void UpdateFPS(GameTime gt)
    {
        _fps = (int)Math.Round(1 / gt.ElapsedGameTime.TotalSeconds);
    }
}
