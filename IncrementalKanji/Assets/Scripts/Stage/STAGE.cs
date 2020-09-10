using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public interface IStage
{
    //倒すのに必要な数
    int enemyDefeatedRequired { get; }
    //難易度（いらないかも？）
    int difficulty { get; }
	//敵を出現させる処理
	ENEMY InstantiateEnemy();
	//クリア条件
	bool ClearCondition(int defeatedNum);
	IEnumerator ShowResultScene(bool isWin);
}
public interface IPopText
{
	string infoText();
}
public class STAGE : BASE, IStage,IPopText
{

	static BATTLE currentEnemy;
    public static BATTLE CurrentEnemy { get
		{
			if (currentEnemy == null)
				return new EmptyBattle();

			return currentEnemy;
		} set => currentEnemy = value; }
	//public int enemyDefeated;
	public virtual int enemyDefeatedRequired { get; }
	public virtual int difficulty { get; }
    //ステージごとのエネミーリスト
    protected List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
    public virtual void SetEnemy() { }
    public virtual bool ClearCondition(int defeatedNum)
    {
		return defeatedNum >= enemyDefeatedRequired;
    }
	//敵を出現させる処理
	public ENEMY InstantiateEnemy()
	{
		int rand = UnityEngine.Random.Range(0, enemyInfos.Count); //int
		ENEMY enemy = Instantiate(main.stageCtrl.enemyPre, main.stageCtrl.enemyPanel);
		enemy.SetParameter(difficulty, enemyInfos[rand]);
		currentEnemy = enemy;
		return enemy;
	}
    protected void AwakeStage()
    {
		SetEnemy();
    }
    public IEnumerator ShowResultScene(bool isWin)
    {
		GameObject DeathPanel = Instantiate(main.stageCtrl.DeathPanel, main.WindowShowCanvas);
		main.stageCtrl.DeathPanelText.text = isWin ? "You Cleared this area!" : "You failed this area ...";
		StartCoroutine(ReturnPanel(DeathPanel));
		yield return new WaitForSecondsRealtime(3.0f);
		StartCoroutine(FadeAwayPanel(DeathPanel));
		yield return new WaitForSecondsRealtime(3.0f);
	}
    public virtual string infoText() { return ""; }
	public IEnumerator FadeAwayPanel(GameObject gamegame)
	{
		foreach (GameObject game in GetAllChildren.GetAllImage(gamegame))
		{
			if (game.GetComponent<Image>() != null)
			{
				while (game.GetComponent<Image>().color.a > 0)
				{
					game.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
					yield return new WaitForSecondsRealtime(0.01f);
				}
			}
			else
			{
				while (game.GetComponent<TextMeshProUGUI>().color.a > 0)
				{
					game.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 0.01f);
					yield return new WaitForSecondsRealtime(0.01f);
				}
			}
		}
	}
	public IEnumerator ReturnPanel(GameObject gamegame)
	{
		foreach (GameObject game in GetAllChildren.GetAllImage(gamegame))
		{
			if (game.GetComponent<Image>() != null)
			{
				while (game.GetComponent<Image>().color.a < 0.99)
				{
					game.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
					yield return new WaitForSecondsRealtime(0.01f);
				}
			}
			else
			{
				while (game.GetComponent<TextMeshProUGUI>().color.a < 0.99)
				{
					game.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 0.01f);
					yield return new WaitForSecondsRealtime(0.01f);
				}
			}
		}
	}
}

