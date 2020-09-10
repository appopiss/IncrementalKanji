using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static BASE;
using System;

public class OneToTen : MOVE
{
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます。
        return "if you set some of \"one\" to \"ten\" ATM, it multiples each status";
    }
    public static bool isDelegateRegistered;
    public static int SelfOneToTenNum()
    {

        int count = 0;
        foreach(AllySlot ally in AllySlot.AllAllies()) {
            EnemyKind kind = ally.ThisEnemyInfo.thisKind;
            if (kind == EnemyKind.一 || kind == EnemyKind.二 || kind == EnemyKind.三 || kind == EnemyKind.四 || kind == EnemyKind.五 ||
                kind == EnemyKind.六 || kind == EnemyKind.七 || kind == EnemyKind.八 || kind == EnemyKind.九 || kind == EnemyKind.十)
            {
                Debug.Log("countされてるよ");
                count++;
            }
        }
        return Math.Max(count - 1, 0);
    }
    public static bool isSelfOneToTen(EnemyKind kind)
    {
        if (kind == EnemyKind.一 || kind == EnemyKind.二 || kind == EnemyKind.三 || kind == EnemyKind.四 || kind == EnemyKind.五 ||
        kind == EnemyKind.六 || kind == EnemyKind.七 || kind == EnemyKind.八 || kind == EnemyKind.九 || kind == EnemyKind.十)
        {
            Debug.Log("数字が入ってるよ");
            return true;
        }
        return false;
    }
    //ThisInfoにアクセスできるコンストラクタ
    public override void Initialize()
    {
        thisInfo.HP.AddMulDelegate(() => 1 + SelfOneToTenNum(), false);
        thisInfo.IdleDamage.AddMulDelegate(() => 1 + SelfOneToTenNum(),false);
    }
}
