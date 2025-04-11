using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CALIMOE;

public class GameScene
{
    protected SceneManager _sm;
    protected InputHelper _ih;

    protected string _name = "";
    public string Name => _name;

    protected Color _clearColour = Color.Transparent;
    public Color ClearColour => _clearColour;
    public GameScene(SceneManager sm, InputHelper ih)
    {
        _sm = sm;
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

    public virtual void HandleInput()
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
