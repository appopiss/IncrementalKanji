using System;
using System.Collections.Generic;
using static UsefulMethod;
using static BASE;

public class Default_EffectSum<T> : IEffectSum<T>
    where T : Enum
{
    public void Reset()
    {
        if (Value == null) { return; }
        ArrayToDefault(Value, DefaultValue);
    }

    public string Detail()
    {
        if (Value == null) { return ""; }
        var sum = optStr + "";
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i].Equals(DefaultValue)) { continue; }
            if (sum.Length != 0) { sum += separator; }
            sum += Detail_Func(Value[i] - DefaultValue, i);
        }
        return sum;
    }

    double[] Value { get; set; }
    public double GetValue(T kind)
    {
        if (Value == null) { return DefaultValue; }
        return Value[indexDic[kind]];
    }
    public void SetValue(T kind, double value)
    {
        if (Value == null) { Initialize(); }
        Value[indexDic[kind]] = value;
    }
    public void AddValue(T kind, double value)
    {
        if (Value == null) { Initialize(); }
        Value[indexDic[kind]] += value;
    }
    public void MulValue(T kind, double value)
    {
        if (Value == null) { Initialize(); }
        Value[indexDic[kind]] *= value;
    }

    /// <summary>
    /// Detail_Func ... 
    /// Return effect's explanation method. double is interval value. int is enum_index.
    /// </summary>
    public Default_EffectSum(double DefaultValue, Func<double, int, string> Detail_Func, string separator = "\n")
    {
        this.DefaultValue = DefaultValue;
        this.Detail_Func = Detail_Func;
        this.separator = separator;
    }

    void Initialize()
    {
        Value = new double[Enum.GetNames(typeof(T)).Length];
        ArrayToDefault(Value, DefaultValue);
        InitializeDictionary(indexDic, Value.Length);
    }

    void InitializeDictionary<_enum>(Dictionary<_enum, int> indexDic, int enum_length)
        where _enum : Enum
    {
        for (int i = 0; i < enum_length; i++)
        {
            indexDic.Add((_enum)(object)i, i); //ボックス化
        }
    }

    double DefaultValue { get; set; }
    Func<double, int, string> Detail_Func { get; set; }
    string separator;
    Dictionary<T, int> indexDic = new Dictionary<T, int>();
}
