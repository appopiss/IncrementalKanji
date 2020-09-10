using System;

public class ExponentialMethod : ICalculateMethod
{
    public double Value(long level, double factor = 1)
    {
        if (level <= 0) { return A0; } //level0の時0を返す
        return A * Math.Pow(R, level) * factor;
    }
    private double Value_Sum(long end_level, double factor = 1)
    {
        if (end_level <= 0) { return A0; }
        return (A * R * (Math.Pow(R, end_level) - 1) / (R - 1)) * factor;
    }
    //(0, 3)なら0, 1, 2の和
    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        return Value_Sum(end_level - 1, factor) - Value_Sum(start_level - 1, factor);
    }
    public double Inverse(double Value, double factor = 1)
    {
        return Math.Log(Value / (A * factor), R);
    }
    public long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1)
    {
        double cal = Math.Log(((Value_Range(0, start_level + 1, factor) + Value ) * (R - 1)) / (A * R * factor) + 1, R);
        if (cal < 0) { return 0; }
        return (long)cal - start_level;
    }

    public ExponentialMethod(double A0, double A, double R)
    {
        if (A <= 0) { throw new ArgumentException("A can't be under zero."); }
        if (R <= 0) { throw new ArgumentException("R can't be under zero."); }
        this.A0 = A0;
        this.R = R;
        this.A = A;
    }
    public double A0 { get; set; }
    public double R { get; set; }
    public double A { get; set; }
}
