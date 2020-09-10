using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

//実際に敵にアタッチされるコンポーネント
//注：ここにステージの操作等が含まれてはいけない
public class ENEMY : BATTLE {

    public EnemyKind whatsKind;
	// Use this for initialization
	void Awake () {
		StartBASE();
        for(int i = 0; i < main.S.CrystalLimit.Length; i++)
        {
            main.S.CrystalLimit[i] = 100 * (i+1);
        }
        HpSlider = gameObject.transform.GetChild(0).GetComponent<Slider>();
        IntervalSlider = gameObject.transform.GetChild(1).GetComponent<Slider>();
        EnemyName = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        FlavorText = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        HpText = HpSlider.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }

    Slider HpSlider;
    TextMeshProUGUI HpText;
    Slider IntervalSlider;
    TextMeshProUGUI EnemyName;
    TextMeshProUGUI FlavorText;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Image>().sprite = thisInfo.thisImage;
        whatsKind = thisInfo.thisKind;
		BattleCor = StartCoroutine(Battle());
	}

	// Update is called once per frame
	void Update () {
		EnemyName.text = thisInfo.thisName;
		FlavorText.text = "meaning: " + thisInfo.flavorText;
		HpText.text = tDigit(Math.Max(currentHp,0));
		HpSlider.value = (float)(currentHp / hp);
		if (currentHp < 1)
        {
            Death();
        }
	}

    //死んだときの処理
    void Death()
    {
        BattleCor = null;
        STAGE.CurrentEnemy = null;
        GetExp(exp);
        Drop();
        Destroy(gameObject);
    }
    void Drop()
    {
        int prob = 10000;
        //確率
        if(UnityEngine.Random.Range(0,10000) <= prob)
        {
            //その属性のクリスタルを手に入れる
            GetCrystal();
        }
    }
    void GetCrystal()
    {
        if (main.SR.CrystalNum[(int)thisInfo.thisAttribute] < main.S.CrystalLimit[(int)thisInfo.thisAttribute])
        {
            main.SR.CrystalNum[(int)thisInfo.thisAttribute]++;
        }

    }


    void GetExp(double exp)
    {
		List<AllySlot> allies = new List<AllySlot>();
        foreach(AllySlot slot in main.allyCtrl.allySlots)
        {
			if (slot.thisEnemyId != EnemyKind.nothing)
				allies.Add(slot);
        }
		int count = allies.Count;
        foreach(AllySlot slot in allies)
        {
			main[slot.thisEnemyId].exp += exp / count;
        }
    }

    //ステータスの調整
    public void SetParameter(int difficulty, EnemyInfo thisInfo)
    {
        float rarityFactor;
        switch (thisInfo.rarity)
        {
            case Rarity.C:
                rarityFactor = 1.0f;
                break;
            case Rarity.UC:
                rarityFactor = 1.5f;
                break;
            case Rarity.R:
                rarityFactor = 2.5f;
                break;
            case Rarity.SR:
                rarityFactor = 4.6f;
                break;
            case Rarity.SSR:
                rarityFactor = 8.5f;
                break;
            default:
                rarityFactor = 1.0f;
                break;
        }
		hp = (10 + UnityEngine.Random.Range(-3,3)) * Math.Pow(1.5, difficulty-1) * rarityFactor;
		currentHp = hp;
		atk = 0.5 * Math.Pow(1.5, difficulty) * rarityFactor;
		gold = 3 * Math.Pow(1.5, difficulty) * rarityFactor;
        exp = 3 * Math.Pow(1.5, difficulty) * rarityFactor;
		this.thisInfo = thisInfo; 
        thisDifficulty = difficulty;
	}

    public override double CurrentHp { get => currentHp; set => currentHp = value; }
    public override double MaxHp { get => hp; }
    double currentHp;
    public int thisDifficulty;
	double hp;
	double gold;
	double exp;
	double atk;
	public EnemyInfo thisInfo;
    Coroutine BattleCor;

    public IEnumerator Battle()
    {
        while (true)
        {
            yield return FillGuage();
            yield return new WaitUntil(() => AllySlot.ChooseAllyRandomly() != null);
            //yield return AllySlot.ChooseAllyRandomly().gameObject.GetComponent<AllyAttack>().FillGuage();
            for (int i = 0; i < main.allyCtrl.allySlots.Length; i++)
            {
                if (!main.allyCtrl.allySlots[i].gameObject.GetComponent<AllyAttack>().CanAttack())
                {
                    continue; //continueキーワードよりあとの処理をスキップし、再び先頭からループを実行するものです。
                }
                yield return main.allyCtrl.allySlots[i].allyAttack.FillGuage();
            }
        }
    }

    public IEnumerator FillGuage()
	{   
		IntervalSlider.value = 0;
		yield return Fill(main.enemyCtrl[thisInfo.thisKind].attackInterval);
        NormalAttack();
		IntervalSlider.value = 0;
	}

	IEnumerator Fill(float interval)
	{
		//3.0fだったとする
		for (int i = 0; i < 20; i++)
		{
			IntervalSlider.value += 0.05f;
			yield return new WaitForSeconds(interval / 20);
		}
	}
    void NormalAttack()
    {
        AllySlot.ChooseAllyRandomly().allyAttack.Attacked(atk);
    }
}
