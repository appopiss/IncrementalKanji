using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMethod : ICalculateMethod
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
        if (level <= threshold) { return firstMethod.Value(level, factor); }
        else return secondMethod.Value(level);
    }

    public double Value_Range(long start_level, long end_level, double factor = 1)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 単純に閾値から二つ目の関数に切り替わる関数
    /// </summary>
    public ChangeMethod(ICalculateMethod firstMethod, ICalculateMethod secondMethod, long threshold)
    {
        this.firstMethod = firstMethod;
        this.secondMethod = secondMethod;
        this.threshold = threshold;
    }
    ICalculateMethod firstMethod;
    ICalculateMethod secondMethod;
    long threshold;
}
