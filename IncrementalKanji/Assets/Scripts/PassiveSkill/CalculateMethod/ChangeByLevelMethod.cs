using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeByLevelMethod : ICalculateMethod
{
    public long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    public double Inverse(double Value, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    public double Value(long level, double factor = 1)
    {
        if (level <= threshold.Level) { return firstMethod.Value(level, factor); }
        return firstMethod.Value(threshold.Level) + secondMethod.Value(level - threshold.Level);
    }

    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    public ChangeByLevelMethod(ICalculateMethod firstMethod, ICalculateMethod secondMethod, ILevel threshold)
    {
        this.firstMethod = firstMethod;
        this.secondMethod = secondMethod;
        this.threshold = threshold;
    }
    ICalculateMethod firstMethod;
    ICalculateMethod secondMethod;
    ILevel threshold;
}
