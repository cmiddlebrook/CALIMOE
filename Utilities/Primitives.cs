using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CALIMOE;

public static class Primitives
{
    private static Texture2D _pixel;

    private static void CreatePixel(SpriteBatch sb)
    {
        _pixel = new Texture2D(sb.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
        _pixel.SetData(new[] { Color.White });
    }

    public static void DrawLine(SpriteBatch sb, Vector2 point1, Vector2 point2, Color colour, int thickness)
    {
        float distance = Vector2.Distance(point1, point2);
        float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
        DrawLine(sb, point1, distance, angle, colour, thickness);
    }

    public static void DrawLine(SpriteBatch sb, Vector2 point, float length, float angle, Color colour, int thickness)
    {
        if (_pixel == null) CreatePixel(sb);

        sb.Draw(_pixel, point, null, colour, angle, Vector2.Zero, new Vector2(length, thickness), SpriteEffects.None, 0f);
    }

    public static void DrawRectangle(SpriteBatch sb, Rectangle rect, Color colour, int thickness)
    {
        DrawLine(sb, new Vector2(rect.Left, rect.Top), new Vector2(rect.Right, rect.Top), colour, thickness); // top
        DrawLine(sb, new Vector2(rect.Left, rect.Top), new Vector2(rect.Left, rect.Bottom), colour, thickness); // left
        DrawLine(sb, new Vector2(rect.Left, rect.Bottom), new Vector2(rect.Right, rect.Bottom), colour, thickness); // bottom
        DrawLine(sb, new Vector2(rect.Right, rect.Top), new Vector2(rect.Right, rect.Bottom), colour, thickness); // right
    }
}
