using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public class EnemyStatusInfo : BASE {

	public TextMeshProUGUI hpText, nameText, flavorText;
	public Slider HpGuage,AttackIntervalSlider;
	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	
}
