using CALIMOE;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace CALIMOE;

public class GameObjects : GameObject
{
    List<GameObject> _children = new List<GameObject>();

    public GameObjects()
    {

    }

    public void AddChild(GameObject obj)
    {
        obj.Parent = this;
        _children.Add(obj);
    }

    public override void Draw(SpriteBatch sb)
    {
        foreach (var child in _children)
        {
            child.Draw(sb);
        }
    }
    public override void HandleInput(InputHelper ih)
    {
        foreach (var child in _children)
        {
            child.HandleInput(ih);
        }
    }

    public override void Update(GameTime gt)
    {
        foreach(var child in _children)
        { 
            child.Update(gt); 
        }
    }


    public override void Reset()
    {
        foreach (var child in _children)
        {
            child.Reset();
        }
    }
}
