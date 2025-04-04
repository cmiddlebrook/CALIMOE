using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CALIMOE;
public class SpriteObject : GameObject
{
    protected Vector2 _origin;
    protected float _rotation;
    protected Vector2 _startOrigin;
    protected Vector2 _startPosition;
    protected float _startRotation;
    protected Vector2 _startVelocity;
    protected Texture2D _texture;
    protected Vector2 _velocity;

    public Vector2 Origin
    {
        get => _origin;
        set => _origin = value;
    }


    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }


    public Vector2 Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }



    public Vector2 Center => new Vector2(_bounds.X + _bounds.Width / 2f, _bounds.Y + _bounds.Height / 2f);


    public SpriteObject(Texture2D texture)
    {
        _texture = texture;
        Reset();
    }
    public SpriteObject(Texture2D texture, Vector2 startPosition, Vector2 startVelocity, float startScale)
	{
        _texture = texture;
        _origin = Vector2.Zero;
        _startPosition = startPosition;
        _startVelocity = startVelocity;
        Scale = startScale;
        Reset();
	}

    public override void Reset()
    {
        _position = _startPosition;
        _velocity = _startVelocity;
        Scale = _startScale;
        _rotation = _startRotation;
        UpdateBounds();
    }

    protected override void UpdateBounds()
    {
        _bounds.X = (int)Math.Round(_position.X - _origin.X);
        _bounds.Y = (int)Math.Round(_position.Y - _origin.Y);
        _bounds.Width = (int)(_texture.Width * Scale);
        _bounds.Height = (int)(_texture.Height * Scale);
    }

    public override void Update(GameTime gt)
    {
        _position += _velocity * (float)gt.ElapsedGameTime.TotalSeconds;

        base.Update(gt);
    }

    public override void Draw(SpriteBatch sb)
    {
        // Round the position before drawing
        _position.X = (float)Math.Round(_position.X);
        _position.Y = (float)Math.Round(_position.Y);
        sb.Draw(_texture, Position, null, Colour, Rotation, Origin, Scale, SpriteEffects.None, 0f);

        base.Draw(sb);
    }

    public void DrawFlippedHorizontally(SpriteBatch sb)
    {
        sb.Draw(_texture, Position, null, Colour, Rotation, Origin, Scale, SpriteEffects.FlipHorizontally, 0f);
    }

    public void DrawFlippedVertically(SpriteBatch sb)
    {
        sb.Draw(_texture, Position, null, Colour, Rotation, Origin, Scale, SpriteEffects.FlipVertically, 0f);
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


}
