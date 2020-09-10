using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heal : MOVE
{
    public override void DoSomething(BATTLE target)
    {
        target.CurrentHp += target.MaxHp * Value();
    }
    public override string ExplainText()
    {
        string chanceText = ((float)Prob() / 100).ToString("F2");
        switch (GetTergetType())
        {
            case TargetType.self:
                return chanceText + "% chance to heal your allies when you attack by " + (Value() * 100).ToString("f2");
            case TargetType.random:
                return chanceText + "% chance to heal your random ally when you attack by " + (Value() * 100).ToString("f2");
            case TargetType.all_self:
                return chanceText + "% chance to heal your all allies when you attack by " + (Value() * 100).ToString("f2");
            default:
                return "";
        }
       
    }
    protected int init_prob;
    protected double init_value;
    protected TargetType target;
    public override int Prob()
    {
        return init_prob;
    }
    public double Value()
    {
        return init_value;
    }
    public Heal(int init_prob, float init_value, TargetType target)
    {
        this.init_prob = init_prob;
        this.init_value = init_value;
        this.target = target;
    }
    public override TargetType GetTergetType()
    {
        return target;
    }
    public EnemyInfo enemyInfo { get => thisInfo; set => thisInfo = value; }
}
