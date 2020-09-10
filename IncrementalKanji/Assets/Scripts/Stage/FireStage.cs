using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

//火のステージ
public class FireStage : STAGE {
    public override void SetEnemy()
    {
		foreach (EnemyInfo enemy in main.enemyCtrl.enemies)
		{
			if (enemy.thisAttribute == Attr.normal && enemy.rarity == Rarity.C)
			{
				enemyInfos.Add(main.enemyCtrl.enemies[(int)enemy.thisKind]);
			}
		}
	}
	public override int difficulty => 3;
	public override int enemyDefeatedRequired => 10;
    public override string infoText()
    {
		return optStr +
			"1-1" + "\n------------ \n \n"
			+ "Difficulty --- 100 \n \n"
			+ "Required enemies defeated --- " + enemyDefeatedRequired + "\n"
			+ "<First Reward> \n"
			+ "-EXP 100 \n"
			+ "-Normal Crystal \n \n"
			+ "<Regular Reward> \n"
			+ "-EXP 10 \n \n"
			+ "You cleared this area XX times";
	}
    private void Awake()
    {
		AwakeStage();
    }
}
