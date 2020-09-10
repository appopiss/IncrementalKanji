using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public class StageStarter : BASE {

	public Button[] StoryButtons;
	public Button GoStageButton;
	public RectTransform WorldMap;
	Vector2 OriginVector = new Vector2(600, 480);
	Vector2 HideVector = new Vector2(-1600, 480);
    void StartStage(GameObject game)
    {
        //インスタンスを取得
		IStage istage = game.GetComponent<IStage>();
		WorldMap.anchoredPosition = HideVector;
        //currentStageにステージの情報を代入する
		main.stageCtrl.currentStage = istage;
    }
    void InitializeButton(Button button)
    {
		button.onClick.AddListener(() => StartStage(button.gameObject));
		IPopText stage = button.gameObject.GetComponent<IPopText>();
		Plain_PopText popText = button.gameObject.AddComponent<Plain_PopText>();
		popText.text = () => stage.infoText();
    }
	// Use this for initialization
	void Awake () {
		GoStageButton.onClick.AddListener(() => WorldMap.anchoredPosition = OriginVector);
		InitializeButton(StoryButtons[0]);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
}
