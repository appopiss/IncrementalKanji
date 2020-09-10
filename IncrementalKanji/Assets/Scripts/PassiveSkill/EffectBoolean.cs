using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UsefulMethod;

public class Default_EffectBoolean : IEffectBoolean
{
    public bool IsTrue { get; set; }

    public string Detail()
    {
        if (HideIfDefault && (IsTrue == DefaultValue)) { return ""; }
        return Detail_Func(IsTrue);
    }

    public void Reset()
    {
        IsTrue = DefaultValue;
    }

    /// <summary>
    /// Detail_Func ... 
    /// Return effect's explanation method. 
    /// </summary>
    public Default_EffectBoolean(bool DefaultValue, Func<bool, string> Detail_Func)
    {
        this.DefaultValue = DefaultValue;
        this.Detail_Func = Detail_Func;
        HideIfDefault = true;
    }

    public bool HideIfDefault { get; set; }
    bool DefaultValue { get; set; }
    Func<bool, string> Detail_Func { get; set; }
}