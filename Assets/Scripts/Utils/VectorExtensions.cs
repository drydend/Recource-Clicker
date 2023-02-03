using UnityEngine;

public static class VectorExtensions
{
    public static Vector3Int ToVectorInt(this Vector3 vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);
        var z = Mathf.RoundToInt(vector.z);

        return new Vector3Int(x, y, z);
    }

    public static Vector2Int ToVectorInt(this Vector2 vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);

        return new Vector2Int(x, y);
    }

    public static Vector2 ToVector(this Vector2Int vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);

        return new Vector2(x, y);
    }

    public static Vector3 ToVector(this Vector3Int vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);
        var z = Mathf.RoundToInt(vector.z);

        return new Vector3(x, y, z);
    }
}
