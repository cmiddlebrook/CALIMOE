using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CALIMOE;

public class Calimoe : Game
{
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected int _fps = 0;

    public Calimoe()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // this was the hack to create a 1 pixel texture for drawing simple shapes
        //Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
        //Globals.pixel.SetData<Color>([Color.White]);

        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gt)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        UpdateFPS(gt);

        base.Update(gt);
    }

    protected override void Draw(GameTime gt)
    {
        base.Draw(gt);
    }

    protected void UpdateFPS(GameTime gt)
    {
        _fps = (int)Math.Round(1 / gt.ElapsedGameTime.TotalSeconds);
    }
}
