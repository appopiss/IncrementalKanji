using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UsefulMethod;

public class Default_EffectSingle : IEffectSingle
{
    public double Value { get; set; }

    public string Detail()
    {
        if (HideIfDefault && Value.Equals(DefaultValue)) { return ""; }
        return Detail_Func(Value - DefaultValue);
    }

    public void Reset()
    {
        Value = DefaultValue;
    }

    /// <summary>
    /// Detail_Func ... 
    /// Return effect's explanation method. double is interval value.
    /// </summary>
    public Default_EffectSingle(double DefaultValue, Func<double, string> Detail_Func)
    {
        this.DefaultValue = DefaultValue;
        this.Detail_Func = Detail_Func;
        HideIfDefault = true;
    }

    public bool HideIfDefault { get; set; }
    double DefaultValue { get; set; }
    Func<double, string> Detail_Func { get; set; }
}

//public class DropChanceMul_EffectSingle : IEffectSingle
//{
//    public double Value { get; set; }

//    public string Detail()
//    {
//        if (HideIfDefault && Value.Equals(DefaultValue)) { return ""; }
//        return " - Drop chance : +" + tDigit((Value - DefaultValue) * 100, 3, true) + "%";
//    }

//    public void Reset()
//    {
//        Value = DefaultValue;
//    }

//    public DropChanceMul_EffectSingle()
//    {
//        DefaultValue = 1;
//        HideIfDefault = true;
//    }
//    double DefaultValue { get; set; }
//    public bool HideIfDefault { get; set; }
//}

//public class ResearchDropAmountMul_EffectSingle : IEffectSingle
//{
//    public double Value { get; set; }

//    public string Detail()
//    {
//        if (HideIfDefault && Value.Equals(DefaultValue)) { return ""; }
//        return " - Research drop amount : +" + tDigit((Value - DefaultValue) * 100, 3, true) + "%";
//    }

//    public void Reset()
//    {
//        Value = DefaultValue;
//    }

//    public ResearchDropAmountMul_EffectSingle()
//    {
//        DefaultValue = 1;
//        HideIfDefault = true;
//    }
//    double DefaultValue { get; set; }
//    public bool HideIfDefault { get; set; }
//}

//public class LuckSum_EffectSingle : IEffectSingle
//{
//    public double Value { get; set; }

//    public string Detail()
//    {
//        if(HideIfDefault && Value.Equals(DefaultValue)) { return ""; }
//        return " - Luck : +" + tDigit((Value - DefaultValue));
//    }

//    public void Reset()
//    {
//        Value = DefaultValue;
//    }

//    public LuckSum_EffectSingle()
//    {
//        DefaultValue = 0;
//        HideIfDefault = true;
//    }
//    double DefaultValue { get; set; }
//    public bool HideIfDefault { get; set; }
//}

//public class SacredRitualMul_EffectSingle : IEffectSingle
//{
//    public double Value { get; set; }

//    public string Detail()
//    {
//        if (HideIfDefault && Value.Equals(DefaultValue)) { return ""; }
//        return " - Sacred Ritual : +" + tDigit((Value - DefaultValue) * 100, 1, true) + "%";
//    }

//    public void Reset()
//    {
//        Value = DefaultValue;
//    }

//    public SacredRitualMul_EffectSingle()
//    {
//        DefaultValue = 1;
//        HideIfDefault = true;
//    }
//    double DefaultValue { get; set; }
//    public bool HideIfDefault { get; set; }
//}