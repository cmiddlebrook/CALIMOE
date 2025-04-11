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
    protected List<GameObject> _gameWorld = new List<GameObject>();


    protected string _name = "";
    public string Name => _name;

    protected Color _clearColour = Color.Transparent;
    public Color ClearColour => _clearColour;
    public GameScene(SceneManager sm, InputHelper ih)
    {
        _sm = sm;
        _ih = ih;
    }

    public virtual void Draw(SpriteBatch sb)
    {
        foreach (GameObject obj in _gameWorld)
        {
            obj.Draw(sb);
        }
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    protected virtual void LoadContent()
    {
    }

    public virtual void Update(GameTime gt)
    {
        _ih.Update();

        foreach (GameObject obj in _gameWorld)
        {
            obj.Update(gt);
        }
    }



}
