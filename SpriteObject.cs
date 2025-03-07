using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CALIMOE;

public class SpriteObject
{

    protected Texture2D _texture;
    protected Rectangle _bounds;
    protected Vector2 _position;
    protected Vector2 _velocity;
    protected Vector2 _startPosition = Vector2.Zero;
    protected Vector2 _startVelocity = Vector2.Zero;


    public Vector2 Position
    {
        get => _position;
        set
        { 
            _position = value;
            UpdateBounds();
        }
    }
    public Vector2 Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }

    public Rectangle Bounds => _bounds;

    public SpriteObject(Texture2D texture)
    {
        _texture = texture;
        _bounds = _texture.Bounds;
    }
    public SpriteObject(Texture2D texture, Vector2 startPosition, Vector2 startVelocity)
        : this(texture)
	{
        _startPosition = startPosition;
        _startVelocity = startVelocity;
        Reset();
	}

    public void Reset()
    {
        _position = _startPosition;
        _velocity = _startVelocity;
    }

    public void Update(GameTime gt)
    {
        _position += _velocity * (float)gt.ElapsedGameTime.TotalSeconds;
        UpdateBounds();
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, Color.White);
    }

    public void DrawFlippedHorizontally(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
    }

    public void DrawFlippedVertically(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipVertically, 0f);
    }
    public void ReverseXDirection()
    {
        _velocity.X *= -1;
    }

    public void ReverseYDirection()
    {
        _velocity.Y *= -1;
    }
    public void AdjustSpeed(float factor)
    {
        _velocity += Vector2.Normalize(_velocity) * factor;
    }

    protected void UpdateBounds()
    {
        _bounds.X = (int)_position.X;
        _bounds.Y = (int)_position.Y;
    }
}
