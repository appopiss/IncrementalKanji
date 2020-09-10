using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

//辞書の情報で使うもののみ載せる
public class AllyInfo : BASE {
    public int level { get => main.SR.AllyLevel[(int)thisKind]; set => main.SR.AllyLevel[(int)thisKind] = value; }
    int Level { get => main.SR.AllyLevel[(int)thisKind]; set => main.SR.AllyLevel [(int)thisKind] = value; }
    public double exp { get => main.SR.AllyExp[(int)thisKind]; set {
            main.SR.AllyExp[(int)thisKind] = value;
            while(main.enemyCtrl.enemies[(int)thisKind].requiredExp(level) <= main.SR.AllyExp[(int)thisKind])
            {
                double HpBeforeLevelUp = main.enemyCtrl[thisKind].HP.Number;
                Level++;
                currentHp += Math.Max(main.enemyCtrl[thisKind].HP.Number - HpBeforeLevelUp, 0);
                main.SR.AllyExp[(int)thisKind] -= main.enemyCtrl.enemies[(int)thisKind].requiredExp(level-1);
            }
        } }
    public double requiredExp { get => main.enemyCtrl[thisKind].requiredExp(level); }
    public int allyNum { get => main.S.AllyNum[(int)thisKind]; set { main.S.AllyNum[(int)thisKind] = value; main.dictCtrl.info(thisKind).ReflectInfo(); } }
    public double currentHp { get => Math.Max(main.SR.AllyCurrentHp[(int)thisKind],0); set => main.SR.AllyCurrentHp[(int)thisKind] = Math.Min(value,MaxHp()); }
    public Rarity rarity { get => main.enemyCtrl[thisKind].rarity; }
    public EnemyKind thisKind;
    public AllyInfo(EnemyKind thisKind)
    {
        this.thisKind = thisKind;
    }
    public double IdleDamage()
    {
        return main.enemyCtrl[thisKind].IdleDamage.Number;
    }
    public double MaxHp()
    {
        return main.enemyCtrl[thisKind].HP.Number;
    }
}

