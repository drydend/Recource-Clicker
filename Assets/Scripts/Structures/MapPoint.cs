using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct MapPoint
{
    public int X;
    public int Y;

    public MapPoint(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }

    public Vector2Int ToVector2Int()
    {
        return new Vector2Int(X, Y);
    }

    public Vector2 ToVector()
    {
        return new Vector2(X, Y);
    }

    public static MapPoint GetEmpty()
    {
        return new MapPoint(0, 0);
    }

    public static bool operator ==(MapPoint a, MapPoint b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(MapPoint a, MapPoint b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    public static MapPoint CreateMapPoint(Vector2Int vector2Int)
    {
        return new MapPoint(vector2Int.x, vector2Int.y);
    }

    public override bool Equals(object obj)
    {
        return obj is MapPoint point &&
               X == point.X &&
               Y == point.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}