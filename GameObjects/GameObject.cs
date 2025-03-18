using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace CALIMOE;

public abstract class GameObject
{
    public abstract void Update(GameTime gt);
    public abstract void Draw(SpriteBatch sb);
}
