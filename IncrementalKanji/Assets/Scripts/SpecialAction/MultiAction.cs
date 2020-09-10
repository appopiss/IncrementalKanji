using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

class MultiActionAll : MOVE
{
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます。
        return "Your All Kanji can move " + thisInfo.actionNum.Number + " times";
    }
    public int ActionNum = 2;
    public MultiActionAll(int ActionNum)
    {
        this.ActionNum = ActionNum;
    }
    public override void Initialize()
    {
        thisInfo.actionNum.AddMulDelegate(() =>
        {
            if (!AllySlot.isSpecificKanjiInParty(thisInfo.thisKind, false))
            {
                return 1.0;
            }
            return AllySlot.TypeNumInParty(typeof(MultiActionAll), false) * ActionNum;
        }, true);
    }
}
