using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CALIMOE;

public class SpriteSheet
{
    protected Texture2D _texture;
    protected Rectangle _spriteRect;

    protected int _columns;
    protected int _index;
    protected int _rows;

    public Rectangle Bounds => new Rectangle(0, 0, Width, Height);
    public Vector2 Center => new Vector2(Width / 2, Height / 2);

    public int ElementsCount => _columns * _rows;
    public int Height => _texture.Height / _rows;

    public int Index
    {
        get { return _index; }
        set
        {
            if (value >= 0 && value < ElementsCount)
            {
                _index = value;
                int columnIndex = _index % _columns;
                int rowIndex = _index / _columns;
                _spriteRect = new Rectangle(columnIndex * Width, rowIndex * Height, Width, Height);
            }
        }
    }
    public int Width => _texture.Width / _columns;

    public SpriteSheet(string texturePath, int columns = 1, int rows = 1, int index = 0)
    {
        _texture = Calimoe.AssetManager.LoadTexture(texturePath);
        _columns = columns;
        _rows = rows;
        Index = index;
    }
    public void Draw(SpriteBatch sb, Vector2 position, Vector2 origin)
    {
        sb.Draw(_texture, position, _spriteRect, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
    }
}