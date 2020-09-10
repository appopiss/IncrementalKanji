using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class POPTEXT_AC : MonoBehaviour
{
    //public GameObject window;
    //public Transform windowParent;
    //public GameObject mainCtrl;
    //public Main main;
    //public string Name;
    //public string explain;
    //public string levelString;
    //public string currentValue;
    //public string NextValue;
    //public string ap;
    //public string wood;
    //public string food;
    //public void startText()
    //{
    //    mainCtrl = GameObject.FindGameObjectWithTag("mainCtrl");
    //    main = mainCtrl.GetComponent<Main>();
    //    windowParent = mainCtrl.GetComponent<UsefulMethod>().windowTransform;
    //    window = Instantiate(main.ascendPopText, windowParent);
    //    gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
    //    EventTrigger.Entry entry = new EventTrigger.Entry();
    //    EventTrigger.Entry entry2 = new EventTrigger.Entry();
    //    entry.eventID = EventTriggerType.PointerEnter;
    //    entry2.eventID = EventTriggerType.PointerExit;
    //    entry.callback.AddListener((x) => UsefulMethod.setActive(window));
    //    entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);
    //}
    //public void updateText()
    //{
    //    window.transform.GetChild(0).GetComponent<Text>().text = Name;
    //    window.transform.GetChild(1).GetComponent<Text>().text = explain;
    //    window.transform.GetChild(2).GetComponent<Text>().text = levelString;
    //    window.transform.GetChild(3).GetComponent<Text>().text = "Current Value : " + currentValue;
    //    window.transform.GetChild(4).GetComponent<Text>().text = "Next Value : " + NextValue;
    //    window.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = "AP Required : " + ap;
    //    levelString = "Level : " + gameObject.GetComponent<A_UPGRADE>().level.ToString();


    //    if (window != null)
    //    {
    //        if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
    //        {
    //            window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
    //        }
    //        else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
    //        {
    //            window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
    //        }
    //        else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
    //        {
    //            window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
    //        }
    //        else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
    //        {
    //            window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50.0f);
    //        }
    //    }
    //}


}
