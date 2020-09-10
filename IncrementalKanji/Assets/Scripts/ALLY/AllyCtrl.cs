using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;
using UnityEditorInternal;

public class AllyCtrl : BASE {

	public Button closeButton;
	public Button openButton;
	public GameObject window;
	public AllySlot[] allySlots;
	public List<AllyInfo> allies = new List<AllyInfo>();
	// Use this for initialization
	void Awake () {
		StartBASE();
		openButton.onClick.AddListener(() => Open());
		closeButton.onClick.AddListener(() => Close());
	}

	void Open()
	{
		window.SetActive(true);
		openButton.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(true);
	}
	void Close()
	{
		window.SetActive(false);
		closeButton.gameObject.SetActive(false);
		openButton.gameObject.SetActive(true);
	}
}
