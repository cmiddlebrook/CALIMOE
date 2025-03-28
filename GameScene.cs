﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CALIMOE;

public class GameScene
{
    protected SceneManager _sm;
    protected AssetManager _am;
    protected InputHelper _ih;

    protected string _name = "";
    public string Name => _name;

    protected Color _clearColour = Color.Transparent;
    public Color ClearColour => _clearColour;
    public GameScene(SceneManager sm, AssetManager am, InputHelper ih)
    {
        _sm = sm;
        _am = am;
        _ih = ih;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LoadContent()
    {
    }

    public virtual void HandleInput(GameTime gt)
    {
    }

    public virtual void Update(GameTime gt)
    {
        _ih.Update();
    }

    public virtual void Draw(SpriteBatch sb)
    {
    }

}
