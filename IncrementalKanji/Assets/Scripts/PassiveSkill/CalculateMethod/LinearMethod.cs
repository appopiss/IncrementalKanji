using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;

public class LinearMethod : ICalculateMethod
{
    public double Value(long level, double factor = 1)
    {
        if (level <= 0) { return A0; }
        return (A + (R * level)) * factor;
    }
    private double Value_Sum(long end_level, double factor = 1)
    {
        if (end_level <= 0) { return A0; }
        return ((0.5 * R * end_level * end_level)
            + (((0.5 * R) + A) * end_level)) * factor;
    }
    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        return Value_Sum(end_level - 1, factor) - Value_Sum(start_level - 1, factor);
    }
    public double Inverse(double Value, double factor = 1)
    {
        return (Value / (factor * R)) - (A / R);
    }
    public long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1)
    {
        double cal = MathUtility.QuadractiFormulaPlus(0.5 * factor * R, (0.5 * factor * R) + A * factor, -factor * Value_Range(0, start_level + 1) - Value);
        if (cal < 0) { return 0; }
        return (long)cal - start_level;
    }

    public LinearMethod(double A0, double A, double R)
    {
        this.A0 = A0;
        this.A = A; 
        this.R = R;
    }
    public double R { get; set; }
    public double A { get; set; }
    public double A0 { get; set; }
}