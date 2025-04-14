using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CALIMOE;

public abstract class GameScene : IDrawable
{
    protected GameObjects _sceneObjects = new GameObjects();

    public GameScene()
    {
    }

    public virtual void Draw(SpriteBatch sb)
    {
        _sceneObjects.Draw(sb);
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput(InputHelper ih)
    {
    }

    public virtual void Reset()
    {
        _sceneObjects.Reset();
    }

    public virtual void Update(GameTime gt)
    {
        _sceneObjects.Update(gt);
    }



}
