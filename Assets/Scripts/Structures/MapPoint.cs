using System;
using UnityEngine;

[Serializable]
public struct MapPoint
{
    public int X { get; private set; }
    public int Y { get; private set; }

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

    public static MapPoint CreateMapPoint(Vector2Int vector2Int)
    {
        return new MapPoint(vector2Int.x, vector2Int.y);
    }
}