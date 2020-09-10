using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class AugmentPaging : BASE {

    PagingArea area;
    public Button rightButton, leftButton;
    int limit = 1;

    void Right()
    {
        area.Up();
        rightButton.interactable = area.currentPage.y != limit;
        leftButton.interactable = area.currentPage.y != 0;
    }

    void Left()
    {
        area.Down();
        rightButton.interactable = area.currentPage.y != limit;
        leftButton.interactable = area.currentPage.y != 0;
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    // Use this for initialization
    void Start()
    {
        area = gameObject.GetOrAddComponent<PagingArea>();
        area.UpLimit = 1;

        rightButton.onClick.AddListener(Right);
        leftButton.onClick.AddListener(Left);

        rightButton.interactable = area.currentPage.y != limit;
        leftButton.interactable = area.currentPage.y != 0;
    }
}
