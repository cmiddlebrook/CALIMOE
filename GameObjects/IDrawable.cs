using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CALIMOE;

interface IDrawable
{
    public void Draw(SpriteBatch sb);
    public void HandleInput(InputHelper ih);
    public void Update(GameTime gt);
    public void Reset();
}

