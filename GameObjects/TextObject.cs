using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace CALIMOE;

public class TextObject : GameObject
{
    protected enum Alignment
    {
        None,
        Horizontal,
        Vertical,
        Both
    }

    protected Alignment _alignment = Alignment.None;
    protected SpriteFont _font = null;
    protected Color _shadowColour = Color.Black;
    protected int _shadowThickness = 5;
    protected Vector2 _textSize;


    public string Text { get; set; } = string.Empty;

    public bool Shadow { get; set; } = false;

    public Rectangle Viewport { get; set; } = Rectangle.Empty;

    public TextObject(SpriteFont font)
	{
        _font = font;
        Text = string.Empty;
    }

    public TextObject(SpriteFont font, string text)
    {
        _font = font;
        Text = text;
        UpdateBounds();
    }
    protected override void UpdateBounds()
    {
        _textSize = _font.MeasureString(Text) * Scale;
        _bounds.X = (int)Math.Round(_position.X);
        _bounds.Y = (int)Math.Round(_position.Y);
        _bounds.Width = (int)_textSize.X;
        _bounds.Height = (int)_textSize.Y;
    }


    public override void Update(GameTime gt)
    {
        base.Update(gt);
    }
    
    public override void Draw(SpriteBatch sb)
	{
        if (Viewport == Rectangle.Empty)
        {
            Viewport = sb.GraphicsDevice.Viewport.Bounds;
        }

        switch (_alignment)
        {
            case Alignment.Horizontal:
                {
                    _position.X = (Viewport.Width - _textSize.X) / 2;
                    break;
                }
            case Alignment.Vertical:
                {
                    _position.Y = (Viewport.Height - _textSize.Y) / 2;
                    break;
                }
            case Alignment.Both:
                {
                    _position.X = (Viewport.Width - _textSize.X) / 2;
                    _position.Y = (Viewport.Height - _textSize.Y) / 2;
                    break;
                }

            case Alignment.None:
            default:
                break;
        }

        if (Shadow)
        {
            var shadowPosition = new Vector2(Position.X + _shadowThickness, Position.Y + _shadowThickness);
            sb.DrawString(_font, Text, shadowPosition, _shadowColour, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
        sb.DrawString(_font, Text, Position, _colour, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0);

        base.Draw(sb);
    }



    public void CenterHorizontal(int y)
    {
        _alignment = Alignment.Horizontal;
        _position.Y = y;
    }

    public void CenterVertical(int x)
    {
        _alignment = Alignment.Vertical;
        _position.X = x;
    }

    public void CenterBoth()
    {
        _alignment = Alignment.Both;
    }

    public void ConfigureShadow(int thickness, Color colour)
    {
        Shadow = true;
        _shadowThickness = thickness;
        _shadowColour = colour;
    }
}
