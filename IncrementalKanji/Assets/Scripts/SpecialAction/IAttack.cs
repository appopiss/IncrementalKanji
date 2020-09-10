using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public interface INormalAttack
{
    void Attack(BATTLE ally, BATTLE enemy);
}

class NormalAttack : INormalAttack
{
    public void Attack(BATTLE ally, BATTLE enemy)
    {
        enemy.CurrentHp -= ally.Atk;
    }
}

class DoubleAttack : INormalAttack
{
    public void Attack(BATTLE ally, BATTLE enemy)
    {
        enemy.CurrentHp -= ally.Atk * 2;
    }
}

class Paralyze : INormalAttack
{
    public void Attack(BATTLE ally, BATTLE enemy)
    {
        Debug.Log("mahidesu");
    }
}