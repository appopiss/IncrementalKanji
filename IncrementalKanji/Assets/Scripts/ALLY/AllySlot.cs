using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UsefulMethod;
using System;
using System.Linq;

public class AllySlot : BASE,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {

	Plain_PopText P_text;
	public int slotId;　//すでにinspectorで割り当てられている
	Image thisImage;
	Slider HpSlider, ExpSlider;
	bool isOver;
    public void OnPointerEnter(PointerEventData data)
    {
		isOver = true;
    }
	public void OnPointerExit(PointerEventData data)
	{
		isOver = false; 
	}
	public EnemyKind thisEnemyId　//既定値は0
	{
		get => main.SR.enemySlotId[slotId];
		set => main.SR.enemySlotId[slotId] = value;
	}
    public double thisCurrentHp { get => main[thisEnemyId].currentHp; set => main[thisEnemyId].currentHp = value; }
    public double thisMaxHp { get => main[thisEnemyId].MaxHp(); }
    //全てのパーティを取得
    public static List<AllySlot> AllAllies()
    {
		//単体攻撃1
		List<AllySlot> attackableAlly = new List<AllySlot>();
		foreach (AllySlot slot in main.allyCtrl.allySlots)
		{
		    attackableAlly.Add(slot);
		}
		return attackableAlly;
	}
    //生きている漢字を取得
    public static List<AllySlot> AvailableAllies()
    {
		//単体攻撃1
		List<AllySlot> attackableAlly = new List<AllySlot>();
		foreach (AllySlot slot in main.allyCtrl.allySlots)
		{
			if (slot.thisEnemyId != EnemyKind.nothing && slot.thisCurrentHp > 0)
				attackableAlly.Add(slot);
		}
		return attackableAlly;
	}
    //ランダムな漢字を1つ取得
    public static AllySlot ChooseAllyRandomly() 
    {
		if (AvailableAllies().Count == 0)
			return new AllySlot();
		int rand = UnityEngine.Random.Range(0,AvailableAllies().Count);
		return AvailableAllies()[rand];
    }
    //指定された漢字がパーティに存在するかどうかを返す
    public static bool isSpecificKanjiInParty(EnemyKind kind, bool isDeathAllowed)
    {
		if (isDeathAllowed)
		{
			foreach (AllySlot ally in AllAllies())
			{
				if (ally.ThisEnemyInfo.thisKind == kind)
				{
					return true;
				}
			}
		}
		else
		{
			foreach (AllySlot ally in AvailableAllies())
			{
				if (ally.ThisEnemyInfo.thisKind == kind)
				{
					return true;
				}
			}
		}
		return false;
	}
    //特定のクラ巣を持っている漢字が何個あるかを返す。
    public static int TypeNumInParty(Type type, bool isDeathAllowed)
    {
		int count = 0;
        if (isDeathAllowed)
        {
            foreach(AllySlot ally in AllAllies())
            {
                if (ally.ThisEnemyInfo.moveInfo.GetType().Name == type.Name)
                {
					count++;
                }
            }
        }
        else
        {
			foreach (AllySlot ally in AvailableAllies())
			{
				if (ally.ThisEnemyInfo.moveInfo.GetType().Name == type.Name)
				{
					count++;
				}
			}
		}
		return count;
    }
	public AllyAttack allyAttack;
	// Use this for initialization
	void Awake () {
		StartBASE();
		thisImage = gameObject.transform.GetChild(0).GetComponent<Image>(); //コンポーネントが戻り値 コンポーネントはインスタンス
		P_text = gameObject.AddComponent<Plain_PopText>();
		P_text.text =  () => allyInfoText();
		P_text.ActiveCondition = () => thisEnemyId != EnemyKind.nothing;
		HpSlider = gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>();
		ExpSlider = gameObject.transform.GetChild(3).gameObject.GetComponent<Slider>();
		gameObject.AddComponent<AllyAttack>();
		allyAttack = gameObject.GetComponent<AllyAttack>();
	}
	// Use this for initialization
	void Start () {
        if(thisEnemyId != EnemyKind.nothing) 
        {
			Set(thisEnemyId);
        }
	}
    string allyInfoText()
    {
		if (!P_text.window.activeSelf) //Gameobject.activeSelf
			return "";

		StringBuilder text = new StringBuilder();
		text.Append("Rarity - " + ThisEnemyInfo.rarity);
		text.Append("\n\nLEVEL - " + tDigit(main[thisEnemyId].level));
		text.Append("\nEXP - " + tDigit(main[thisEnemyId].exp) + "/ " + tDigit(main.enemyCtrl[thisEnemyId].requiredExp(main[thisEnemyId].level)));
		text.Append("\nHP - " + tDigit(main[thisEnemyId].currentHp) + " / " + tDigit(main[thisEnemyId].MaxHp()));
		text.Append("\nIdle Damage - " + tDigit(main[thisEnemyId].IdleDamage(),1));
		text.Append("\nSpecial Effect - " + main.enemyCtrl[thisEnemyId].moveInfo.ExplainText());
		return text.ToString();
    }
    /*
    public EnemyInfo ThisEnemyInfo()
    {
		return main.enemyCtrl.enemies[(int)thisEnemyId];
	}
    */
    public EnemyInfo ThisEnemyInfo { get => main.enemyCtrl.enemies[(int)thisEnemyId]; }

    // Update is called once per frame
	void Update () {
		SliderUpdate();
	}

    void SliderUpdate()
    {
        if(thisEnemyId == EnemyKind.nothing)
        {
			setFalse(HpSlider.gameObject);
			setFalse(ExpSlider.gameObject);
        }
        else
        {
			setActive(HpSlider.gameObject);
			setActive(ExpSlider.gameObject);
			HpSlider.value = (float)(thisCurrentHp / thisMaxHp);
            ExpSlider.value = (float)(main[thisEnemyId].exp / main.enemyCtrl[thisEnemyId].requiredExp(main[thisEnemyId].level));
		}
    }

    //仲間をセットする関数
    public void Set(EnemyKind enemy)
    {
		thisEnemyId = enemy;
		thisImage.sprite = main.enemyCtrl.GetImage(enemy);
    }

	//仲間をデリートする関数
	public void OnPointerDown(PointerEventData eventData)
	{
		if(eventData.pointerId == -2)
        {
			thisEnemyId = EnemyKind.nothing;
			thisImage.sprite = null;
        }
	}

	//ドラッグされた時に呼び、セットする
	public void SetByDrug(EnemyKind enemy)
    {
		if (!isOver)
			return;

		if (isAllySame(enemy))
			return;

		Set(enemy);
    }

    static bool isAllySame(EnemyKind enemy)
    {
        for (int i = 0; i < main.allyCtrl.allySlots.Length; i++)
        {
			if(main.allyCtrl.allySlots[i].thisEnemyId == enemy)
            {
				return true;
            }
        }
		return false;
    }

}



