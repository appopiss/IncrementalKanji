using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using static UsefulMethod;

public class A_UPGRADE : POPTEXT_AC
{
    ////LevelはSaveするよ
    //public virtual int level { get; set; }
    //protected int[][] upgradeId;
    //protected double initValue;
    //protected double initCost;
    //protected double plusValue;
    //public double bottom;
    //public double Aug1, AugM1;
    //public double Jem1, Jem3, WineAdd1, WineMul1;
    //public bool isLinear;
    //public calWay cal;
    //public enum calWay
    //{
    //    exp,
    //    fib
    //}

    //public void startUpgrade(double initValue, double initCost, double plus, double bottom,calWay cal,bool isLinear)
    //{
    //    this.initValue = initValue;
    //    this.initCost = initCost;
    //    this.bottom = bottom;
    //    this.cal = cal;
    //    this.isLinear = isLinear;
    //    plusValue = plus;
    //    gameObject.GetComponent<Button>().onClick.AddListener(upgrade);
    //    startText();
    //}
    //virtual public void upgrade() {
    //    calculate(ref Main.S.ascendPoint);
    //}
    //public double calculateCurrentCost()
    //{
    //    if (cal == calWay.exp)
    //    {
    //        return initCost * Math.Pow(bottom, level);
    //    }
    //    else
    //    {
    //        return fibonacci(level + 2);
    //    }
    //}
    //public void calculate(ref double resources)
    //{
    //    resources -= calculateCurrentCost();
    //    level++;
    //}

    //public double calculateCurrentValue()
    //{
    //    if (isLinear)
    //    {
    //        return (initValue + level * (plusValue));
    //    }
    //    else
    //    {
    //        return (initValue * Pow(plusValue, level));
    //    }
    //}
    //public double calculateNextValue()
    //{
    //    level++;
    //    double ans = calculateCurrentValue();
    //    level--;
    //    return ans;
    //}
    //public double calculateNextSub()
    //{
    //    return calculateNextValue() - calculateCurrentValue();
    //}
    //public void checkButton()
    //{
    //    if (calculateCurrentCost() > Main.S.ascendPoint)
    //    {
    //        gameObject.GetComponent<Button>().interactable = false;
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Button>().interactable = true;
    //    }

    //    updateText();
    //}

    //public double fibonacci(int n)
    //{
    //    double factor = 1 / Sqrt(5);
    //    double phi = (1 + Sqrt(5)) / 2;
    //    double phi2 = (1 - Sqrt(5)) / 2;

    //    return factor * (Pow(phi, n) - Pow(phi2, n));
    //}

    //public string percent(double d)
    //{
    //    return tDigit((d - 1) * 100,2) + " % ";
    //}
}
