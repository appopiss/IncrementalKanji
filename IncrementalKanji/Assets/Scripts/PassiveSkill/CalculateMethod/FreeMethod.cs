using System;

public class FreeMethod : ICalculateMethod
{
    public long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1)
    {
        return HowMuchIncreaseLevelFunc(start_level, Value, factor);
    }

    public double Inverse(double Value, double factor = 1)
    {
        return InverseFunc(Value, factor);
    }

    public double Value(long level, double factor = 1)
    {
        return ValueFunc(level, factor);
    }

    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        return Value_RangeFunc(start_level, end_level, factor);
    }

    /// <summary>
    /// long ... level, double .. factor
    /// </summary>
    public FreeMethod(Func<long, double, double> ValueFunc)
    {
        this.ValueFunc = ValueFunc;
    }

    /// <summary>
    /// long ... start_level, double1 ... Value, double2 ... factor
    /// </summary>
    public Func<long, double, double, long> HowMuchIncreaseLevelFunc;
    /// <summary>
    /// double1 ... Value, double2 ... factor
    /// </summary>
    public Func<double, double, double> InverseFunc;
    /// <summary>
    /// long ... level, double .. factor
    /// </summary>
    public Func<long, double, double> ValueFunc;
    /// <summary>
    /// long1 ... start_level, long2 ... end_level, double ... factor
    /// </summary>
    public Func<long, long, double, double> Value_RangeFunc;
}
