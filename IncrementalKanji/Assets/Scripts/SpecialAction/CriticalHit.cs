using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class CriticalHit : MOVE
{
    //漢字のレベルを取得する
    public override void DoSomething(BATTLE target)
    {
        //targetに特定の処理を行います。targetは使わなくてもいいです。
        target.CurrentHp -= thisIdleDamage * multiplier;
    }
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます
        string chanceText = ((float)Prob() / 100).ToString("F2");
        return chanceText + "chance to deal +" + multiplier * 100 + "% of its idle damage to the enemy";
    }
    public override int Prob()
    {
        //スキルが発動される確率を入れます。ex; 5000 -> 50%
        return prob + thisLevel * 100;
    }
    int multiplier = 1;
    int prob = 10000;
    public CriticalHit(int multiplier, int prob)
    {
        this.multiplier = multiplier;
        this.prob = prob;
    }
    public override TargetType GetTergetType()
    {
        return TargetType.enemy;
    }
    public EnemyInfo enemyInfo { get => thisInfo; set => thisInfo = value; }
}
