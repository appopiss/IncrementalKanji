using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class POPTEXT_PU : MonoBehaviour
{
    //public GameObject window;
    //public Transform windowParent;
    //public GameObject mainCtrl;
    //public Main main;
    //public string Name;
    //public string explain;
    //public string levelString;
    //public string currentValue;
    //public string nextValue;
    //public string gold;
    //public string wood;
    //public string food;
    //public string stone;
    //public string steel;

    //public void startText()
    //{
    //    mainCtrl = GameObject.FindGameObjectWithTag("mainCtrl");
    //    main = mainCtrl.GetComponent<Main>();
    //    windowParent = mainCtrl.GetComponent<UsefulMethod>().windowTransform;
    //    window = Instantiate(main.upgradePopText,windowParent);
    //    gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
    //    EventTrigger.Entry entry = new EventTrigger.Entry();
    //    EventTrigger.Entry entry2 = new EventTrigger.Entry();
    //    entry.eventID = EventTriggerType.PointerEnter;
    //    entry2.eventID = EventTriggerType.PointerExit;
    //    entry.callback.AddListener((x) => UsefulMethod.setActive(window));
    //    entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);
    //    stone = "0";
    //    steel = "0";
    //}
    //public void updateText()
    //{
    //    if (window.activeSelf)
    //    {
    //        if (window.activeSelf)
    //        {
    //            window.transform.GetChild(0).GetComponent<Text>().text = Name;
    //            window.transform.GetChild(1).GetComponent<Text>().text = explain;
    //            window.transform.GetChild(2).GetComponent<Text>().text = levelString;
    //            window.transform.GetChild(3).GetComponent<Text>().text = "Current Value : " + currentValue;
    //            window.transform.GetChild(4).GetComponent<Text>().text = "Next Value : " + nextValue;
    //            window.transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = gold;
    //            window.transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = wood;
    //            window.transform.GetChild(7).transform.GetChild(1).GetComponent<Text>().text = food;
    //            window.transform.GetChild(8).GetChild(0).GetComponentInChildren<Text>().text = stone;
    //            window.transform.GetChild(8).GetChild(1).GetComponentInChildren<Text>().text = steel;

    //            if (gameObject.GetComponent<UPGRADE>() != null)
    //            {

    //                levelString = "Level : " + gameObject.GetComponent<UPGRADE>().level.ToString();
    //            }
    //            else
    //            {

    //                levelString = "Level : " + gameObject.GetComponent<D_UPGRADE>().level.ToString();
    //            }


    //            if (window != null)
    //            {
    //                if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
    //                {
    //                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
    //                }
    //                else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
    //                {
    //                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
    //                }
    //                else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
    //                {
    //                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
    //                }
    //                else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
    //                {
    //                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
    //                }
    //            }
    //        }
    //    }
    //}


}
