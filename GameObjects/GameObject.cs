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
    protected float _scale = 1.0f;
    protected float _startScale = 1.0f;



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

    public float Scale
    {
        get => _scale;
        set => _scale = value;
    }

    protected abstract void UpdateBounds();

    /// <summary>
    /// Every derived class MUST call base.Update(gt) to ensure the bounds are updated.
    /// </summary>
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
        _bounds = Rectangle.Empty;
        _position = Vector2.Zero;
        _scale = 1.0f;
    }

}
