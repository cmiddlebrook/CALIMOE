﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace CALIMOE;

public abstract class GameObject
{
    protected Rectangle _bounds;
    protected Color _colour = Color.White;
    protected bool _drawBounds = false;
    protected Vector2 _origin;
    protected Vector2 _startOrigin;
    protected Vector2 _position;
    protected Vector2 _startPosition;
    protected float _rotation;
    protected float _startRotation;
    protected float _scale = 1.0f;
    protected float _startScale = 1.0f;
    protected Vector2 _velocity;
    protected Vector2 _startVelocity;



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

    public Vector2 Origin
    {
        get => _origin;
        set
        {
            _origin = value;
            UpdateBounds();
        }
    }

    public Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
            UpdateBounds();
        }
    }

    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }

    public float Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            UpdateBounds();
        }
    }

    public Vector2 Velocity
    {
        get => _velocity;
        set
        {
            _velocity = value;
            UpdateBounds();
        }
    }

    public bool Visible { get; set; }

    protected abstract void UpdateBounds();

    /// <summary>
    /// Every derived class MUST call base.Update(gt) to ensure the bounds are updated.
    /// </summary>
    public virtual void Update(GameTime gt)
    {
        _position += _velocity * (float)gt.ElapsedGameTime.TotalSeconds;
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
        _origin = Vector2.Zero;
        _position = Vector2.Zero;
        _rotation = 0.0f;
        _scale = 1.0f;
        _velocity = Vector2.Zero;
    }

}
