using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CALIMOE;
public class SpriteObject : GameObject
{

    protected Vector2 Origin;
    protected SpriteSheet _sprite;

    public int Height => _sprite?.Height ?? 0;

    public int Width => _sprite?.Width ?? 0;



    public SpriteObject(string texturePath)
    {
        _sprite = new SpriteSheet(texturePath);
        Reset();
    }


    public override void Draw(SpriteBatch sb)
    {
        if (Visible)
        {
            _sprite.Draw(sb, GlobalPosition, Origin);
            //sb.Draw(_texture, GlobalPosition, null, Colour, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }
   }

    
    public override void Reset()
    {
        Rotation = 0f;
        Origin = Vector2.Zero;
        Scale = 1f;
    }

    public void SetOriginToCenter()
    {
        Origin = new Vector2(Width / 2f, Height / 2f);
    }


}
