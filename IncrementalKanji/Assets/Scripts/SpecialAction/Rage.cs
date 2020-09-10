using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

class Rage : MOVE
{
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます。
        return "All your allies will deal 2x damage in next attack";
    }
    public override void DoSomething(BATTLE target)
    {
        target.gameObject.AddComponent<RageAttack>();
    }
    public override TargetType GetTergetType()
    {
        return TargetType.all_self;
    }
}

class RageAttack :MonoBehaviour, INormalAttack
{
    public void Attack(BATTLE ally, BATTLE enemy)
    {
        enemy.CurrentHp -= ally.Atk * 2;
        Destroy(this);
    }
}
