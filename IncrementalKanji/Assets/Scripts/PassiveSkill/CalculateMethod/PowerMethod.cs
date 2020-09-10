    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// y = A * x^B + C
/// </summary>
public class PowerMethod : ICalculateMethod
{
    public double Value(long level, double factor = 1)
    {
        if(level <= 0) { return 0; }
        return (A * Math.Pow(level, B) + C) * factor;
    }

    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    public double Inverse(double Value, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    public long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// return A * Math.Pow(level, B) + C;
    /// </summary>
    public PowerMethod(double A, double B, double C)
    {
        this.A = A;
        this.B = B;
        this.C = C;
    }
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
}
