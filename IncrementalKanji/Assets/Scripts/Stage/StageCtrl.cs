using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public enum StageCondition
{
	start,
	battle,
	reward,
	end,
}
public class StageCtrl : BASE {

	//プレハブ
	public ENEMY enemyPre;
	public Transform enemyPanel;
	public GameObject DeathPanel;
	public TextMeshProUGUI DeathPanelText;
	// Use this for initialization
	void Awake () {
		StartBASE();
		DeathPanelText = DeathPanel.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(UpdateStage());
	}
    private void Update()
    {
        
    }

    void UpdateStageInfo()
    {

    }
    //ここにバトルの情報が全て詰まっている？
    public IStage currentStage;
	public int currentDefeatedNum;
	public StageCondition stageCondition;
	public bool isWin;
	public void Initialize()
	{
        //敵を全部消す
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
		{
			Destroy(enemy.gameObject);
		}
        //味方を全回復する
		for (int i = 0; i < main.allyCtrl.allySlots.Length; i++)
		{
			main.allyCtrl.allySlots[i].allyAttack.Initialize();
		}
        //敵を倒した数をリセットする。
		main.stageCtrl.currentDefeatedNum = 0;
	}
	IEnumerator UpdateStage()
    {
        while (true)
        {
            //ステージに何か情報が入るまでまつ
			yield return new WaitUntil(() => currentStage != null);
				switch (stageCondition)
				{
					case StageCondition.start:
					    Initialize();
						stageCondition = StageCondition.battle;
					    currentStage.InstantiateEnemy();
					    break;
					case StageCondition.battle:
						//味方が全員死んだらendにする
						if (AllyIsAllDeath())
						{
							stageCondition = StageCondition.end;
						    isWin = false;
						}
						if(GameObject.FindGameObjectsWithTag("enemy").Length == 0)
						{
							currentDefeatedNum++;
						    if (currentStage.ClearCondition(currentDefeatedNum))
                            {
							    stageCondition = StageCondition.reward;
							    isWin = true;
							    break;
						    }
							yield return new WaitForSecondsRealtime(0.5f);
							currentStage.InstantiateEnemy();
						}
						break;
					case StageCondition.reward:
						yield return currentStage.ShowResultScene(isWin);
						stageCondition = StageCondition.end;
						break;
					case StageCondition.end:
                    //画面を初期化する
                    //ステージをnullにする
                    if (!isLoop)
					    currentStage = null;

					    isWin = false;
					    stageCondition = StageCondition.start;
						break;
				}
			yield return new WaitForSecondsRealtime(0.1f);
        }
    }
	bool isLoop = true;
	bool AllyIsAllDeath()
	{
		if (main.allyCtrl.allySlots.Length == 0)
			return false;
		for (int i = 0; i < main.allyCtrl.allySlots.Length; i++)
		{
			if (main.allyCtrl.allySlots[i].thisCurrentHp > 0)
			{
				return false;
			}
		}
		return true;
	}
}
