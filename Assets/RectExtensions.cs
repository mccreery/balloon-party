using UnityEngine;

public static class RectExtensions
{
    public static Vector2 GetRandomPoint(this Rect rect)
    {
        return rect.position
            + Vector2.right * rect.width * Random.Range(0.0f, 1.0f)
            + Vector2.up * rect.height * Random.Range(0.0f, 1.0f);
    }

    public static Vector2 Clamp(this Rect rect, Vector2 point)
    {
        return new Vector2(Mathf.Clamp(point.x, rect.xMin, rect.xMax), Mathf.Clamp(point.y, rect.yMin, rect.yMax));
    }
}
