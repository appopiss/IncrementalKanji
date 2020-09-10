using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_UPGRADE : POPTEXT_PU
{
    ////LevelはSaveするよ
    //public virtual int level { get; set; }
    //protected int[][] upgradeId;
    //protected double initValue; 
    //protected double initCost;
    //public double initCost2;
    //protected double plusValue;
    //public double bottom;
    //public double bottom2;
    //double[] costArray;
    //public int Aug1;
    //Button thisButton;

    // public void awake()
    //{
    //   // startText();
    //}

    //public void startUpgrade(double initValue, double initCost, double initCost2,double plus, double bottom,double bottom2)
    //{
    //    startText();
    //    costArray = new double[2];
    //    this.initValue = initValue;
    //    this.initCost = initCost;
    //    this.initCost2 = initCost2;
    //    this.bottom = bottom;
    //    this.bottom2 = bottom2;
    //    plusValue = plus;
    //    thisButton = gameObject.GetComponent<Button>();
    //    thisButton.onClick.AddListener(upgrade);
    //}
    //virtual public void upgrade() { }
    //public double[] calcurateCurrentCost()
    //{
    //  //  costArray[0] = initCost * Math.Pow(bottom, level); 
    //  //  costArray[1] = initCost2 * Math.Pow(bottom2, level);
    //  //  return costArray;

    //    switch (Main.SR.buyMode)
    //    {

    //        case UPGRADE.buyMode.mode1:
    //            costArray[0] = initCost * Math.Pow(CorrectBottom()[0], level);
    //            costArray[1] = initCost2 * Math.Pow(CorrectBottom()[1], level);
    //            return costArray;
    //        case UPGRADE.buyMode.mode10:
    //            return calculateSumCost(level, 10);
    //        case UPGRADE.buyMode.mode25:
    //            return calculateSumCost(level, 25);
    //        case UPGRADE.buyMode.modeMax:
    //            costArray[0] = initCost * Math.Pow(CorrectBottom()[0], level);
    //            costArray[1] = initCost2 * Math.Pow(CorrectBottom()[1], level);
    //            return calculateMaxSumCost(level).x == 0 || calculateMaxSumCost(level).y == 0 ? 
    //                costArray: new double[2] { calculateMaxSumCost(level).x, calculateMaxSumCost(level).y};
    //        case UPGRADE.buyMode.nothing:
    //            return null;
    //        default:
    //            return null;
    //    }
    //}

    //public double[] calculateSumCost(int currentLevel, int plusLevel)
    //{
    //    int tempLevel = currentLevel;
    //    double[] sumCost = new double[2];

    //    for (int i = 0; i < plusLevel; i++)
    //    {
    //        sumCost[0] += calculateCurrentCost(tempLevel)[0];
    //        sumCost[1] += calculateCurrentCost(tempLevel)[1];
    //        tempLevel++;
    //    }

    //    return sumCost;
    //}

    //public double[] calculateCurrentCost(int level)
    //{
    //    costArray[0] = initCost * Math.Pow(CorrectBottom()[0], level);
    //    costArray[1] = initCost2 * Math.Pow(CorrectBottom()[1], level);
    //    return costArray;
    //}

    //public double[] CorrectBottom()
    //{
    //    double[] ans = new double[2];
    //    ans[0] = 1 + (bottom - 1) * Math.Pow(0.995, main.ascendList[11].level);
    //    ans[1] = 1 + (bottom2 - 1) * Math.Pow(0.995, main.ascendList[11].level);
    //    return ans;
    //}


    //public (double x, double y, int z) calculateMaxSumCost(int currentLevel)
    //{
    //    int tempLevel = currentLevel;
    //    double[] sumCost = new double[2] { 0, 0 };

    //    while (true)
    //    {
    //        if (Main.SR.money < sumCost[0]|| Main.SR.wood < sumCost[1])
    //        {
    //            if (Main.SR.money < sumCost[0])
    //            {
    //                sumCost[0] -= calculateCurrentCost(tempLevel - 1)[0];
    //            }

    //            if(Main.SR.wood < sumCost[1])
    //            {
    //                sumCost[1] -= calculateCurrentCost(tempLevel - 1)[1];
    //            }

    //            return (sumCost[0], sumCost[1], tempLevel - currentLevel - 1);
    //        }
    //        else
    //        {
    //            sumCost[0] += calculateCurrentCost(tempLevel)[0];
    //            sumCost[1] += calculateCurrentCost(tempLevel)[1];
    //        }
            


    //        tempLevel++;
    //    }
    //}

    //public void calculate(ref double resources, ref double resources2)
    //{
    //    //resources -= calcurateCurrentCost()[0];
    //    //resources2 -= calcurateCurrentCost()[1];
    //    //level++;

    //    double tempX = 0;
    //    double tempY = 0;
    //    int tempZ = 0;

    //    switch (Main.SR.buyMode)
    //    {

    //        case UPGRADE.buyMode.mode1:
    //            resources -= calcurateCurrentCost()[0];
    //            resources2 -= calcurateCurrentCost()[1];
    //            level++;
    //            break;
    //        case UPGRADE.buyMode.mode10:
    //            resources -= calcurateCurrentCost()[0];
    //            resources2 -= calcurateCurrentCost()[1];
    //            level++;
    //            break;
    //        case UPGRADE.buyMode.mode25:
    //            resources -= calcurateCurrentCost()[0];
    //            resources2 -= calcurateCurrentCost()[1];
    //            level++;
    //            break;
    //        case UPGRADE.buyMode.modeMax:
    //            (tempX, tempY, tempZ) = calculateMaxSumCost(level);
    //            resources -= tempX;
    //            resources2 -= tempY;
    //            level += tempZ;
    //            break;
    //        case UPGRADE.buyMode.nothing:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public double calculateCurrentValue()
    //{

    //    return initValue + level * (plusValue + Aug1);
    //}

    //public double calculateCurrentValue(int level)
    //{

    //    return initValue + level * (plusValue + Aug1);
    //}
    //public double calculateNextValue()
    //{
    //  //  level++;
    //  //  double ans = calculateCurrentValue();
    //  //  level--;
    //  //  return ans;

    //    int tempLevel = level;

    //    switch (Main.SR.buyMode)
    //    {

    //        case UPGRADE.buyMode.mode1:
    //            tempLevel++;
    //            double ans = calculateCurrentValue(tempLevel);
    //            return ans;
    //        case UPGRADE.buyMode.mode10:
    //            tempLevel+=10 ;
    //            double ans10 = calculateCurrentValue(tempLevel);
    //            return ans10;
    //        case UPGRADE.buyMode.mode25:
    //            tempLevel+=25;
    //            double ans25 = calculateCurrentValue(tempLevel);
    //            return ans25;
    //        case UPGRADE.buyMode.modeMax:
    //            tempLevel += calculateMaxSumCost(level).z;
    //            double ansMax = calculateCurrentValue(tempLevel);
    //            return ansMax;
    //        case UPGRADE.buyMode.nothing:
    //            return 0;
    //        default:
    //            return 0;
    //    }

    //}
    //public double calculateNextSub()
    //{
    //    return calculateNextValue() - calculateCurrentValue();
    //}
    //public void checkButton(double Resources, double Resources2)
    //{
    //    if (Main.SR.buyMode == UPGRADE.buyMode.modeMax)
    //    {
    //        if ( calculateMaxSumCost(level).x == 0 || calculateMaxSumCost(level).y == 0)
    //        {
    //            thisButton.interactable = false;
    //        }
    //        else
    //        {
    //            thisButton.interactable = true;
    //        }
    //    }
    //    else
    //    {

    //        if (calcurateCurrentCost()[0] > Resources || calcurateCurrentCost()[1] > Resources2)
    //        {
    //            thisButton.interactable = false;
    //        }
    //        else
    //        {
    //            thisButton.interactable = true;
    //        }
    //    }
    //}

}
