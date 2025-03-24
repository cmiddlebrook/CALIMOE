

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CALIMOE;

public class AnimatedSprite : SpriteObject
{
    protected int _width;
    protected int _height;
    protected Rectangle _sourceRect;
    protected int _currentFrame;
    protected int _nrFrames;
    protected double _totalElapsedTime;
    protected float _timePerFrame;
    protected float _framesPerSecond;
    protected bool _isLooping = true;

    public AnimatedSprite(Texture2D texture, Vector2 offset, int width, int height, int nrFrames, float fps)
        : base(texture)
    {
        _width = width;
        _height = height;
        _sourceRect = new Rectangle((int)offset.X, (int)offset.Y, _width, _height);
        _nrFrames = nrFrames;
        _framesPerSecond = fps;
        _timePerFrame = 1.0f / fps;
        _totalElapsedTime = 0;
        _isLooping = true;
    }

    public override void Update(GameTime gt)
    {
        base.Update(gt);
        _totalElapsedTime += gt.ElapsedGameTime.TotalSeconds;

        if (!_isLooping) return;

        if (_totalElapsedTime > _timePerFrame)
        {
            _currentFrame++;
            _currentFrame %= _nrFrames;
            _totalElapsedTime = 0;
        }
    }

    public override void Draw(SpriteBatch sb)
    {
        // Round the position before drawing
        _position.X = (float)Math.Round(_position.X);
        _position.Y = (float)Math.Round(_position.Y);

        _sourceRect.X += _width * _currentFrame;
        _sourceRect.Y += _height * _currentFrame;
        sb.Draw(_texture, _position, _sourceRect, _colour, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0);
    }
}
