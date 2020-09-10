using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public class FirstChoose : BASE {

    public Button FirstFireButton;
    public Button FirstWaterButton;
    public Button FirstWoodButton;
    // Use this for initialization
    void Awake () {
        StartBASE();
    }

	// Use this for initialization
	void Start () {
        FirstFireButton.onClick.AddListener(() => main.gacha.FirstGacha(main.gacha.FirstFireGacha));
        FirstWaterButton.onClick.AddListener(() => main.gacha.FirstGacha(main.gacha.FirstWaterGacha));
        FirstWoodButton.onClick.AddListener(() => main.gacha.FirstGacha(main.gacha.FirstWoodGacha));
        FirstFireButton.onClick.AddListener(DeleteTitle);
        FirstWaterButton.onClick.AddListener(DeleteTitle);
        FirstWoodButton.onClick.AddListener(DeleteTitle);
    }
    void DeleteTitle()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
