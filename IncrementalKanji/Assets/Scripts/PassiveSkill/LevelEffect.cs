using static BASE;
using static UsefulMethod;
using System;
using System.Collections.Generic;

public interface ILevelEffect<T>
{
    void Calculate(T level, double factor);
    string Detail(T level, double factor);
    string NextDetail(T currentLevel, T nextLevel, double factor);
}

public static class LevelEffectExtension
{
    public static void Calculate<T>(this IReadOnlyList<ILevelEffect<T>> list, T level, double factor = 1)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Calculate(level, factor);
        }
    }

    public static string Detail<T>(this IReadOnlyList<ILevelEffect<T>> list, T level, string separator = "\n", double factor = 1)
    {
        var sum = optStr + "";
        for (int i = 0; i < list.Count; i++)
        {
            if (sum.Length != 0) { sum += separator; }
            sum += list[i].Detail(level, factor);
        }
        return sum;
    }
}

/// <summary>
/// Value(0)は0とする。
/// Value_Range(a, b)はaは含むがbは含まない。
/// </summary>
public interface ICalculateMethod
{
    double Value(long level, double factor = 1);
    double Value_Range(long start_level, long end_level, double factor = 1);
    double Inverse(double Value, double factor = 1); //逆関数
    long HowMuchIncreaseLevel(long start_level, double Value, double factor = 1);
}

public interface IToReset
{
    void Reset();
}

public interface IEffectSum<T> : IToReset
    where T : Enum
{
    double GetValue(T kind);
    void SetValue(T kind, double value);
    void AddValue(T kind, double value);
    void MulValue(T kind, double value);
}

public interface IEffectSingle : IToReset
{
    double Value { get; set; }
}

public interface IEffectBoolean : IToReset
{
    bool IsTrue { get; set; }
}

public interface ILevel
{
    long Level { get; set; }
}


public interface IPassiveEffect : ILevelEffect<long> { }

public abstract class Default_LevelEffect<T> : ILevelEffect<long>
    where T : Enum
{
    public void Calculate(long level, double factor)
    {
        toPlusSum.AddValue(kind, method.Value(level, factor));
    }

    public string Detail(long level, double factor)
    {
        return optStr + EffectNameToString(index_dic[kind]) + " : " +EffectValueToString(method.Value(level, factor), index_dic[kind]);
    }

    public string NextDetail(long currentLevel, long nextLevel, double factor)
    {
        return optStr + EffectNameToString(index_dic[kind]) + " : " + EffectValueToString(method.Value(currentLevel, factor), index_dic[kind])
                                                  + " => " + EffectValueToString(method.Value(nextLevel, factor), index_dic[kind]);
    }

    public Default_LevelEffect(IEffectSum<T> toPlusSum, T kind, ICalculateMethod method)
    {
        this.kind = kind;
        this.method = method;
        this.toPlusSum = toPlusSum;

        InitializeDictionary(index_dic, Enum.GetNames(typeof(T)).Length);
    }

    public abstract string EffectNameToString(int index);
    public abstract string EffectValueToString(double value, int index);

    void InitializeDictionary<_enum>(Dictionary<_enum, int> indexDic, int enum_length)
        where _enum : Enum
    {
        for (int i = 0; i < enum_length; i++)
        {
            indexDic.Add((_enum)(object)i, i); //ボックス化
        }
    }

    T kind;
    IEffectSum<T> toPlusSum;
    ICalculateMethod method;
    Dictionary<T, int> index_dic = new Dictionary<T, int>();
}

public abstract class Single_LevelEffect : ILevelEffect<long>
{
    public void Calculate(long level, double factor)
    {
        toPlusSum.Value += method.Value(level, factor);
    }

    public string Detail(long level, double factor)
    {
        return optStr + EffectNameToString() + " : " + EffectValueToString(method.Value(level, factor));
    }

    public string NextDetail(long currentLevel, long nextLevel, double factor)
    {
        return optStr + EffectNameToString() + " : " + EffectValueToString(method.Value(currentLevel, factor))
                                                  + " => " + EffectValueToString(method.Value(nextLevel, factor));
    }

    public Single_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method)
    {
        this.method = method;
        this.toPlusSum = toPlusSum;
    }

    public abstract string EffectNameToString();
    public abstract string EffectValueToString(double value);
    IEffectSingle toPlusSum;
    ICalculateMethod method;
}






//public abstract class RegenResource_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " regen";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value, main.resourceTextCtrl.points[index].regen_deal, !IsEnergy((ResourceKind)index), toShowSign:true) + "/s";
//    }

//    public RegenResource_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class MaxResource_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " max";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value, main.resourceTextCtrl.points[index].max_deal, !IsEnergy((ResourceKind)index), toShowSign: true);
//    }

//    public MaxResource_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class RegenResourceMul_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " regen";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, main.resourceTextCtrl.points[index].regen_deal, !IsEnergy((ResourceKind)index), toShowSign: true) + "%";
//    }

//    public RegenResourceMul_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class MaxResourceMul_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " max";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, main.resourceTextCtrl.points[index].max_deal, !IsEnergy((ResourceKind)index), toShowSign: true) + "%";
//    }

//    public MaxResourceMul_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class InstantActionEffectMul_LevelEffect : Default_LevelEffect<InstantKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.instantActions[index].Name() + " effect";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, toShowSign: true) + "%";
//    }
//    public InstantActionEffectMul_LevelEffect(IEffectSum<InstantKind> toPlusSum, InstantKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class LoopActionEffectMul_LevelEffect : Default_LevelEffect<LoopKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.loopActions[index].Name() + " effect";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, toShowSign: true) + "%";
//    }
//    public LoopActionEffectMul_LevelEffect(IEffectSum<LoopKind> toPlusSum, LoopKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class UpgradeActionEffectMul_LevelEffect : Default_LevelEffect<UpgradeKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.upgradeActions[index].Name() + " effect";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, toShowSign: true) + "%";
//    }
//    public UpgradeActionEffectMul_LevelEffect(IEffectSum<UpgradeKind> toPlusSum, UpgradeKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class StatusAdd_LevelEffect : Default_LevelEffect<StatusKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.status[index].Name();
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value, 2, true, toShowSign: true);
//    }

//    public StatusAdd_LevelEffect(IEffectSum<StatusKind> toPlusSum, StatusKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class StatusMul_LevelEffect : Default_LevelEffect<StatusKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.status[index].Name();
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }
//    public StatusMul_LevelEffect(IEffectSum<StatusKind> toPlusSum, StatusKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class AbilityEffectMul_LevelEffect : Default_LevelEffect<AbilityKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.abilitys[index].Name() + " Effect";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public AbilityEffectMul_LevelEffect(IEffectSum<AbilityKind> toPlusSum, AbilityKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class AbilitySpeedMul_LevelEffect : Default_LevelEffect<AbilityKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.abilitys[index].Name() + " Speed";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public AbilitySpeedMul_LevelEffect(IEffectSum<AbilityKind> toPlusSum, AbilityKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class SacredRitualMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return optStr + "Sacred Ritual";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public SacredRitualMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class DarkRitualMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return optStr + "Dark Ritual";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr +tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public DarkRitualMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class ResearchDropAmountMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return optStr + "Research drop amount";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public ResearchDropAmountMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class LuckAdd_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return optStr + "Luck";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value, toShowSign: true);
//    }

//    public LuckAdd_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class DropChanceMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return optStr + "Drop chance";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value * 100, 3, true, toShowSign: true) + "%";
//    }

//    public DropChanceMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class DropAmountAdd_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " drop amount";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value, 1, true, toShowSign: true);
//    }

//    public DropAmountAdd_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class DropAmountMul_LevelEffect : Default_LevelEffect<ResourceKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + main.enumCtrl.resources[index].Name() + " drop amount";
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public DropAmountMul_LevelEffect(IEffectSum<ResourceKind> toPlusSum, ResourceKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class DamageTakenMul_LevelEffect : Default_LevelEffect<NeedKind>
//{
//    public override string EffectNameToString(int index)
//    {
//        return optStr + "Damage taken by " + main.enumCtrl.needs[index].Name();
//    }

//    public override string EffectValueToString(double value, int index)
//    {
//        return optStr + tDigit(value * 100, 1, true) + "%";
//    }

//    public DamageTakenMul_LevelEffect(IEffectSum<NeedKind> toPlusSum, NeedKind kind, ICalculateMethod method) : base(toPlusSum, kind, method) { }
//}

//public abstract class StatusMulByAttr_LevelEffect : Double_LevelEffect<StatusKind, NeedKind>
//{
//    public override string EffectNameToString(int t_index, int s_index)
//    {
//        return optStr + main.enumCtrl.status[t_index].Name() + " of " + main.enumCtrl.needs[s_index].Name() + " unit";
//    }

//    public override string EffectValueToString(double value, int t_index, int s_index)
//    {
//        return optStr + tDigit(value * 100, 1, true) + "%";
//    }

//    public StatusMulByAttr_LevelEffect(IEffectSum<StatusKind, NeedKind> toPlusSum, StatusKind statusKind, NeedKind needKind, ICalculateMethod method) : base(toPlusSum, statusKind, needKind, method) { }
//}

//public abstract class HabitEfficiencyMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return "Habit efficiency";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public HabitEfficiencyMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class HabitEfficiencyAdd_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return "Habit efficiency";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value, 2, true, toShowSign: true);
//    }

//    public HabitEfficiencyAdd_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

//public abstract class ChestDropChanceMul_LevelEffect : Single_LevelEffect
//{
//    public override string EffectNameToString()
//    {
//        return "Chest drop chance";
//    }

//    public override string EffectValueToString(double value)
//    {
//        return optStr + tDigit(value * 100, 1, true, toShowSign: true) + "%";
//    }

//    public ChestDropChanceMul_LevelEffect(IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method) { }
//}

public abstract class AnonymousAddSingle_LevelEffect : Single_LevelEffect
{
    public override string EffectNameToString()
    {
        return effectName;
    }

    public override string EffectValueToString(double value)
    {
        return optStr + tDigit(value, decimal_point);
    }

    //加算であげる対象が1つ。
    public AnonymousAddSingle_LevelEffect(string effectName, int decimal_point, IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method)
    {
        this.effectName = effectName;
        this.decimal_point = decimal_point;
    }
    string effectName;
    int decimal_point;
}

public abstract class AnonymousMulSingle_LevelEffect : Single_LevelEffect
{
    public override string EffectNameToString()
    {
        return effectName;
    }

    public override string EffectValueToString(double value)
    {
        return optStr + tDigit(value * 100, 3) + "%";
    }

    public AnonymousMulSingle_LevelEffect(string effectName, IEffectSingle toPlusSum, ICalculateMethod method) : base(toPlusSum, method)
    {
        this.effectName = effectName;
    }
    string effectName;
}