using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace CALIMOE;

public abstract class GameObject
{
    protected Vector2 _position;
    protected Rectangle _bounds;
    protected bool _drawBounds = false;

    public Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
            UpdateBounds();
        }
    }

    public Rectangle Bounds
    {
        get
        {
            UpdateBounds();
            return _bounds;
        }
        protected set {  _bounds = value; }        
    }

    protected abstract void UpdateBounds();
    public abstract void Update(GameTime gt);
    public virtual void Draw(SpriteBatch sb)
    {
        if (_drawBounds)
        {
            Primitives.DrawRectangle(sb, Bounds, Color.Red, 1);
        }
    }

}
