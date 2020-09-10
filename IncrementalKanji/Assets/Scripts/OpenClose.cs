using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public class OpenClose : BASE {

	RectTransform thisCanvas;
	public Button CloseButton;
	public Button OpenButton;
	bool isOpen;
	public bool isOpenFirst;
    void Open()
    {
		if (isOpen)
			return;
		thisCanvas.anchoredPosition += new Vector2(1200, 0);
		isOpen = true;
    }
    void Close()
    {
		if (!isOpen)
			return;
		thisCanvas.anchoredPosition += new Vector2(-1200, 0);
		isOpen = false;
	}
	// Use this for initialization
	void Awake () {
		StartBASE();
		thisCanvas = gameObject.GetComponent<RectTransform>();
		OpenButton.onClick.AddListener(Open);
		CloseButton.onClick.AddListener(Close);
	}

	// Use this for initialization
	void Start () {
		if (isOpenFirst)
			isOpen = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
