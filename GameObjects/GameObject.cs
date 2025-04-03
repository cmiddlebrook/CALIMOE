using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace CALIMOE;

public abstract class GameObject
{
    protected Rectangle _bounds;
    protected Color _colour = Color.White;
    protected bool _drawBounds = false;
    protected Vector2 _position;


    public Rectangle Bounds
    {
        get => _bounds;
        protected set {  _bounds = value; }        
    }

    public Color Colour
    {
        get => _colour;
        set => _colour = value;
    }

    public bool DrawBounds
    {
        get => _drawBounds;
        set => _drawBounds = value;
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    protected abstract void UpdateBounds();
    public virtual void Update(GameTime gt)
    {
        UpdateBounds();
    }
    public virtual void Draw(SpriteBatch sb)
    {
        if (_drawBounds)
        {
            Primitives.DrawRectangle(sb, _bounds, Color.Red, 1);
        }
    }

    public virtual void Reset()
    {
        _position = Vector2.Zero;
        _bounds = Rectangle.Empty;
    }

}
