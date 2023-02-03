public static class BoolExtentions
{
    public static int ToInt(this bool value)
    {
        return value ? 1 : -1;
    }
}