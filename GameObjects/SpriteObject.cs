using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CALIMOE;
public class SpriteObject : GameObject
{

    protected Vector2 Origin;
    protected Texture2D _texture;

    public int Height => _texture?.Height ?? 0;

    public int Width => _texture?.Width ?? 0;



    public SpriteObject(string texturePath)
    {
        LoadTexture(texturePath);
        Reset();
    }
 //   public SpriteObject(string texturePath, Vector2 startPosition, Vector2 startVelocity, float startScale)
	//{
 //       LoadTexture(texturePath);
 //       _origin = Vector2.Zero;
 //       _startPosition = startPosition;
 //       _startScale = startScale;
 //       _startVelocity = startVelocity;
 //       Reset();
	//}


    public override void Draw(SpriteBatch sb)
    {
        if (Visible)
        {
            Debug.Assert(_texture != null);

            sb.Draw(_texture, GlobalPosition, null, Colour, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }

        base.Draw(sb);
    }

    protected void LoadTexture(string path)
    {
        if (string.IsNullOrEmpty(path)) return;
        _texture = Calimoe.AssetManager.LoadTexture(path);
    }

    public override void Reset()
    {
        Rotation = 0f;
        Scale = 1f;
        //_position = _startPosition;
        //_scale = _startScale;
        //_rotation = _startRotation;
        //_velocity = _startVelocity;
        //UpdateBounds();
    }

    public void SetOriginToCenter()
    {
        Origin = new Vector2(Width / 2f, Height / 2f);
    }

    //protected override void UpdateBounds()
    //{
    //    if (_texture == null) return;

    //    _bounds.X = (int)(LocalPosition.X - (Origin.X * Scale));
    //    _bounds.Y = (int)(LocalPosition.Y - (Origin.Y * Scale));
    //    _bounds.Width = (int)(_texture.Width * Scale);
    //    _bounds.Height = (int)(_texture.Height * Scale);
    //}

}
