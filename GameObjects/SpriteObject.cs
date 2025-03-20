using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CALIMOE;
public class SpriteObject : GameObject
{

    protected Texture2D _texture;
    protected Rectangle _bounds;
    protected Vector2 _position;
    protected Vector2 _velocity;
    protected Vector2 _scale;
    protected Vector2 _startPosition = Vector2.Zero;
    protected Vector2 _startVelocity = Vector2.Zero;
    protected Vector2 _startScale = Vector2.One;
    protected Color _colour = Color.White;


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

    public Vector2 Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            UpdateBounds();
        }
    }

    public Color Colour
    {
        get => _colour;
        set => _colour = value;
    }

    public Rectangle Bounds => _bounds;

    public Vector2 Origin => new Vector2(_bounds.Width / 2f, _bounds.Height / 2f);
    public Vector2 Center => new Vector2(_bounds.X + _bounds.Width / 2f, _bounds.Y + _bounds.Height / 2f);


    public SpriteObject(Texture2D texture)
    {
        _texture = texture;
        _bounds = _texture.Bounds;
    }
    public SpriteObject(Texture2D texture, Vector2 startPosition, Vector2 startVelocity, Vector2 startScale)
        : this(texture)
	{
        _startPosition = startPosition;
        _startVelocity = startVelocity;
        _startScale = startScale;
        Reset();
	}

    public void Reset()
    {
        _position = _startPosition;
        _velocity = _startVelocity;
        _scale = _startScale;
        UpdateBounds();
    }

    public override void Update(GameTime gt)
    {
        _position += _velocity * (float)gt.ElapsedGameTime.TotalSeconds;
        UpdateBounds();
    }

    public override void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Colour, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
    }

    public void DrawFlippedHorizontally(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Colour, 0f, new Vector2(0, 0), _scale, SpriteEffects.FlipHorizontally, 0f);
    }

    public void DrawFlippedVertically(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Colour, 0f, new Vector2(0, 0), _scale, SpriteEffects.FlipVertically, 0f);
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
        _bounds.X = (int)Math.Round(_position.X);
        _bounds.Y = (int)Math.Round(_position.Y);
        _bounds.Width = (int)(_texture.Width * _scale.X);
        _bounds.Height = (int)(_texture.Height * _scale.Y);
    }

}
