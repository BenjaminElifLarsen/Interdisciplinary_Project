namespace SharedImplementation.BinaryFlag;
public class BinaryFlag
{
    private long _flag;

    public BinaryFlag()
    {
        _flag = 0;
    }

    private void AddFlag(long flag)
    {
        if ((_flag & flag) == 0)
            _flag += flag;
    }

    private void RemoveFlag(long flag)
    {
        if ((_flag & flag) != 0)
            _flag -= flag;
    }

    private bool IsFlagPresent(long flag)
    {
        return (_flag & flag) != 0;
    }

    public static BinaryFlag operator +(BinaryFlag left, long right)
    {
        left.AddFlag(right);
        return left;
    }

    public static BinaryFlag operator -(BinaryFlag left, long right)
    {
        left.RemoveFlag(right);
        return left;
    }

    public static bool operator ==(BinaryFlag left, long right)
    {
        return left.IsFlagPresent(right);
    }

    public static bool operator !=(BinaryFlag left, long right)
    {
        return !(left == right);
    }

    public static BinaryFlag operator +(BinaryFlag left, Enum right)
    {
        left.AddFlag(EnumConversion.EnumToLong(right));
        return left;
    }

    public static BinaryFlag operator -(BinaryFlag left, Enum right)
    {
        left.RemoveFlag(EnumConversion.EnumToLong(right));
        return left;
    }

    public static bool operator ==(BinaryFlag left, Enum right)
    {
        return left.IsFlagPresent(EnumConversion.EnumToLong(right));
    }

    public static bool operator !=(BinaryFlag left, Enum right)
    {
        return !(left == right);
    }

    public static implicit operator long(BinaryFlag flag) => flag is not null ? flag._flag : 0;
    /// <summary>
    /// Returns true if the flag is not null and 0
    /// </summary>
    /// <param name="flag"></param>
    public static implicit operator bool(BinaryFlag flag) => flag is not null && flag._flag == 0;
}

internal class EnumConversion
{
    internal static long EnumToLong(Enum e)
    {
        var value = Convert.ChangeType(e, Enum.GetUnderlyingType(e.GetType()));
        return Convert.ToInt64(value);
    }
}