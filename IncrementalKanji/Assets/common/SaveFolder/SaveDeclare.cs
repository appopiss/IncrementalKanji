using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static UsefulStatic;

/// <summary>
/// 主にsaveしたい配列の初期化を行うクラス
/// InitializeArray(ref main.SR.hoge, サイズ);
/// のようにして初期化する。アップデートなどで途中から変更することも可能。
/// 初期化はAwake()のAwakeBASE();のあとに書くことを推奨。
/// </summary>
public class SaveDeclare : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
		//配列の初期化
		InitializeArray(ref main.SR.UP_level, 100);
		InitializeArray(ref main.SR.AllyLevel, 300);
		InitializeArray(ref main.S.AllyNum, 300);
		InitializeArray(ref main.SR.enemySlotId, 20);
		InitializeArray(ref main.SR.AllyExp, 300);
		InitializeArray(ref main.SR.AllyCurrentHp, 300);
		InitializeArray(ref main.SR.CrystalNum, 18);
		InitializeArray(ref main.S.CrystalLimit, 18);
	}

	// Use this for initialization
	void Start () {

	}
}
