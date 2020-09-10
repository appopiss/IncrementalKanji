using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

class Block : MOVE
{
    public override void Attacked(double damage, ref double hp)
    {
        if(UnityEngine.Random.Range(0,10000) <= Prob())
        {
            //ブロックした！の演出
            Debug.Log("Blocked!");
        }
        else
        {
            base.Attacked(damage,ref hp);
        }
    }
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます。
        return (Prob() * 0.01).ToString() + "% chance to block enemy's attack so that you take no damage";
    }

    int prob = 10000;
    public override int Prob()
    {
        //スキルが発動される確率を入れます。ex; 5000 -> 50%
        return prob + thisLevel * 100;
    }

    public Block(int prob)
    {
        this.prob = prob;
    }

    public EnemyInfo enemyInfo { get => thisInfo; set => thisInfo = value; }
}