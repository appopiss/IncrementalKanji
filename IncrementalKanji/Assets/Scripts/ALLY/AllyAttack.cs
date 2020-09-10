using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class BATTLE : BASE
{
	public virtual bool CanAttack() { return false; }
	protected Image AttackGuage; 
    public virtual double CurrentHp { get; set; }
    public virtual double MaxHp { get; }
    public virtual double Atk { get; }
    public virtual float AttackInterval { get; }
    public virtual void IdleAttack() { }
    public virtual void SpecialAction() { }
    public virtual void Attacked(double damage) { }
    public virtual void Initialize() { }
}

public class AllyAttack : BATTLE
{
	AllySlot thisSlot;
	private void Awake()
	{
		thisSlot = gameObject.GetComponent<AllySlot>();
		AttackGuage = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
	}
	public override double CurrentHp { get => main[thisSlot.thisEnemyId].currentHp; set => main[thisSlot.thisEnemyId].currentHp = value; }
    public override double MaxHp { get => main[thisSlot.thisEnemyId].MaxHp(); }
	public override bool CanAttack()
    {
		return thisSlot.thisEnemyId != EnemyKind.nothing && thisSlot.thisCurrentHp > 0;
	}
    public override double Atk => main[thisSlot.thisEnemyId].IdleDamage();
	public override float AttackInterval => main.enemyCtrl[thisSlot.thisEnemyId].attackInterval;
    public override void IdleAttack()
    {
		STAGE.CurrentEnemy.CurrentHp -= main[thisSlot.thisEnemyId].IdleDamage();
		//StageのCurrentEnemyのはBattleを継承したEnemy型のインスタンスが入っているため、EnemyのCurrentHpプロパティをを利用できる
	}
	public IEnumerator FillGuage()
	{
		for (int i = 0; i < main.enemyCtrl[thisSlot.thisEnemyId].actionNum.Number; i++) {
			AttackGuage.fillAmount = 0;
			yield return new WaitUntil(CanAttack);
			//ゲージをためていく。
			yield return Fill(AttackInterval); //コルーチンの中でコルーチンを呼び出
			//↓通常攻撃
			NormalAttack();
			//↓特別攻撃
			SpecialAction();
			AttackGuage.fillAmount = 0;
		}
	}
    void NormalAttack()
    {
		INormalAttack attack;
        if(gameObject.GetComponent<INormalAttack>() == null)
        {
			attack = new NormalAttack();
			attack.Attack(this,STAGE.CurrentEnemy);
        }
        else
        {
            foreach(INormalAttack attacks in gameObject.GetComponents<INormalAttack>())
            {
				attacks.Attack(this, STAGE.CurrentEnemy);
            }
        }
    }
	IEnumerator Fill(float interval)
	{
		//3.0fだったとする
		for (int i = 0; i < 20; i++)
		{
			AttackGuage.fillAmount += 0.05f;
			yield return new WaitForSeconds(interval / 20);
		}
	}
	public override void SpecialAction()
	{
		main.enemyCtrl[thisSlot.thisEnemyId].moveInfo.Action();
	}
	public override void Attacked(double damage)
	{
		main.enemyCtrl[thisSlot.thisEnemyId].moveInfo.Attacked(damage, ref main.SR.AllyCurrentHp[(int)thisSlot.thisEnemyId]);
	}
    public override void Initialize()
    {
        //復活したときの初期化
		CurrentHp = MaxHp;   
    }
}

public class EmptyBattle : BATTLE
{

}