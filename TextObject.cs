﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CALIMOE;

public class TextObject
{
    public enum CenterText
    {
        None,
        Horizontal,
        Vertical,
        Both
    }

    protected SpriteFont _font = null;
	protected string _text = "";
	protected Vector2 _position = Vector2.Zero;
    protected CenterText _centerMode = CenterText.None;
    protected int _otherAxis = 0;
    protected Color _colour = Color.White;

    public TextObject(SpriteFont font, string text, Vector2 pos, Color colour = default)
	{
		_font = font;
		_text = text;
        _position = pos;
        _colour = (colour == default) ? _colour : colour;
	}

    public TextObject(SpriteFont font)
	{
        _font = font;
    }

    public void DrawText(SpriteBatch sb, string text, CenterText centerMode = CenterText.None, int otherAxis = 0)
    {
        _text = text;
        _centerMode = centerMode;
        _otherAxis = otherAxis;
        AdjustPositionForCentering(sb);

        Draw(sb);
    }
    public void Draw(SpriteBatch sb)
	{
        AdjustPositionForCentering(sb);
        sb.DrawString(_font, _text, _position, _colour);
	}

    protected void AdjustPositionForCentering(SpriteBatch sb)
    {
        Rectangle viewport = sb.GraphicsDevice.Viewport.Bounds;
        Vector2 stringSize = _font.MeasureString(_text);

        switch (_centerMode)
        {
            case CenterText.Horizontal:
                {
                    CenterHorizontal(viewport, stringSize);
                    break;
                }

            case CenterText.Vertical:
                {
                    CenterVertical(viewport, stringSize);
                    break;
                }

            case CenterText.Both:
                {
                    CenterBoth(viewport, stringSize);
                    break;
                }

            case CenterText.None:
            default:
                {
                    break;
                }
        }
    }

    protected void CenterHorizontal(Rectangle viewport, Vector2 stringSize)
    {
        _position.X = (viewport.Width - stringSize.X) / 2;
        _position.Y = _otherAxis;
    }

    protected void CenterVertical(Rectangle viewport, Vector2 stringSize)
    {
        _position.Y = (viewport.Height - stringSize.Y) / 2;
        _position.X = _otherAxis;
    }

    protected void CenterBoth(Rectangle viewport, Vector2 stringSize)
    {
        _position.X = (viewport.Width - stringSize.X) / 2;
        _position.Y = (viewport.Height - stringSize.Y) / 2;
    }
}
