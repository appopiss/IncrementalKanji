using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

//火のステージ
public class WaterStage : STAGE
{
	public override void SetEnemy()
	{
		foreach (EnemyInfo enemy in main.enemyCtrl.enemies)
		{
			if (enemy.thisAttribute == Attr.water)
			{
				enemyInfos.Add(main.enemyCtrl.enemies[(int)enemy.thisKind]);
			}
		}
	}

}
