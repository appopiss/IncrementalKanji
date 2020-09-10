using System.Collections.Generic;
using UnityEngine;
using static BASE;
using System;

/*
public interface IMove //戻り値の型と関数名だけ
{
    int Prob(int level);
    double Value(int level);
    void Action();
    //void ActionByEnemy(ENEMY enemy);
    string ExplainText();
    //string ExplainTextByEnemy(ENEMY enemy);
    EnemyInfo enemyInfo { get; set; }
}
*/

public abstract class   MOVE //抽象クラスは抽象メソッドを定義できる　抽象メソッドは必ずオーバーライドされなければいけない
{
    public int GetLevel()
    {
        return main[thisInfo.thisKind].level;
    }
    List<BATTLE> TargetList()　//味方全員
    {
        List<BATTLE> battles = new List<BATTLE>();
        foreach(AllySlot slot in AllySlot.AvailableAllies())
        {
            battles.Add(slot.allyAttack);
        }
        return battles;
    }
    BATTLE RandomTarget()　//味方のだれか
    {
        BATTLE battle;
        int listNum = AllySlot.AvailableAllies().Count;
        if (listNum == 0)
            return new EmptyBattle();

        battle = AllySlot.AvailableAllies()[UnityEngine.Random.Range(0,listNum)].allyAttack;
        return battle;
    }
    BATTLE ChooseSelf()　//能力を発動する自分自身
    {
        int listNum = AllySlot.AvailableAllies().Count;
        if (listNum == 0)
            return new EmptyBattle();

        foreach (AllySlot slot in AllySlot.AvailableAllies())
        {
            if (slot.ThisEnemyInfo == thisInfo)
                return slot.allyAttack;
        }

        return new EmptyBattle();
    }
    public void Action()
    {
        Debug.Log("yobareteruyo");
        if (UnityEngine.Random.Range(0, 10000) <= Prob())
        {
            switch (GetTergetType())
            {
                case TargetType.self:
                    DoSomething(ChooseSelf());
                    break;
                case TargetType.random:
                    DoSomething(RandomTarget());
                    break;
                case TargetType.all_self:
                    foreach(BATTLE battle in TargetList())
                    {
                        DoSomething(battle);
                    }
                    break;
                case TargetType.all:
                    foreach (BATTLE battle in TargetList())
                    {
                        DoSomething(battle);
                    }
                    DoSomething(STAGE.CurrentEnemy);
                    break;
                case TargetType.enemy:
                    DoSomething(STAGE.CurrentEnemy);
                    break;
            }
        }
    }
    public virtual void DoSomething(BATTLE target) { }
    public virtual int Prob() { return 10000; }
    public EnemyInfo thisInfo;　//MoveInfo.thisInfo = this
    public TargetType targetType;
    public virtual string ExplainText() { return ""; }
    public int thisLevel { get => main[thisInfo.thisKind].level; }
    public double thisIdleDamage { get => main[thisInfo.thisKind].IdleDamage(); }
    public virtual TargetType GetTergetType() { return TargetType.self; }
    public virtual void Attacked(double damage, ref double hp)
    {
        hp = Math.Max(hp - damage, 0);
    }
    public virtual void Initialize() { }
    public virtual void OnDead() { }
}

public enum TargetType
{
    self,
    random,
    all_self,
    all,
    enemy
}
public class Empty : MOVE
{
    public EnemyInfo enemyInfo { get => thisInfo; set => thisInfo = value; }

    public void ActionByEnemy(ENEMY enemy)
    {
        return;
    }

    public int Prob(int level)
    {
        return 0;
    }

    public double Value(int level)
    {
        return 0;
    }
}

class Template : MOVE
{
    //漢字のレベルを取得する

    public override void DoSomething(BATTLE target)
    {
        
    }
    public override string ExplainText()
    {
        //ウインドウに表示する説明を入れます。
        return "";
    }
    public override int Prob()
    {
        //スキルが発動される確率を入れます。ex; 5000 -> 50%
        return 0;
    }
    public Template()
    {
        //コンストラクタ
    }
    public override TargetType GetTergetType()
    {
        return TargetType.self;
    }
    public EnemyInfo enemyInfo { get => thisInfo; set => thisInfo = value; }
}


