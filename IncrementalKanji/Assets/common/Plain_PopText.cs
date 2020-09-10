using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static BASE;
using System;

public class Plain_PopText : MonoBehaviour
{
    public GameObject window;
    //[TextAreaAttribute(10,100)]//height:10,width:100
    public Func<string> text = () => "";
    public Func<bool> ActiveCondition = () => true;

    private void Start()
    {
        startText();
    }

    private void Update()
    {
        updateText();
    }

    public void startText()
    {
        window = Instantiate(main.PopTexts[0], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window, ActiveCondition));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }
    public void updateText()
    {
        if (!window.activeSelf)
            return;

        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text();
        if (window != null)
        {
            if (Input.mousePosition.y >= 400 && Input.mousePosition.x >= 600) //(600,400)は真ん中
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(600, 400) + new Vector3(-250.0f, -100.0f);
            }
            else if (Input.mousePosition.y >= 400 && Input.mousePosition.x < 600)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(600, 400) + new Vector3(50.0f, -100.0f);
            }
            else if (Input.mousePosition.y < 400 && Input.mousePosition.x >= 600)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(600, 400) + new Vector3(-250.0f, 0.0f);
            }
            else if (Input.mousePosition.y < 400 && Input.mousePosition.x < 600)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(600, 400) + new Vector3(50.0f, 150.0f);
            }
        }
    }


}
