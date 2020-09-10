using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using static UsefulMethod;

//このクラスはボタンにだけつけてね♡
public class AUGMENT : MonoBehaviour
{
    //public GameObject window;
    //public Transform windowParent;
    //public virtual bool isGet { get; set; }
    //public virtual bool isUnlocked { get; set; }
    //protected int[][] upgradeId;
    //bool isEffect;
    //public bool isEffected;
        
    //protected double cost;
    //public string Name;
    //public string explain;
    //public string condition;
    //public string currentCondition;
    //public string gold;
    //public string wood;
    //public string food;
    //public string unlockText;
    //public string isGetText;
    //public GameObject mainCtrl;
    //public Main main;
    //GameObject augLock;
    //SpriteState press = new SpriteState();

    //public void startAug(double cost , int spriteIndex)
    //{
    //    mainCtrl = GameObject.FindGameObjectWithTag("mainCtrl");
    //    main = mainCtrl.GetComponent<Main>();
    //    //Augmentの処理
    //    this.cost = cost;
    //    gameObject.GetComponent<Button>().onClick.AddListener(upgrade);
    //    //テキストの処理
    //    windowParent = mainCtrl.GetComponent<UsefulMethod>().windowTransform;
    //    window = Instantiate(mainCtrl.GetComponent<UsefulMethod>().windowPre, windowParent);
    //    //window.GetComponent<Image>().sprite = main.BackGroundImage[3];
    //    gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
    //    EventTrigger.Entry entry = new EventTrigger.Entry();
    //    EventTrigger.Entry entry2 = new EventTrigger.Entry();
    //    entry.eventID = EventTriggerType.PointerEnter;
    //    entry2.eventID = EventTriggerType.PointerExit;
    //    entry.callback.AddListener((x) => UsefulMethod.setActive(window,unlock()||isUnlocked));
    //    entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    //    gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);
    //    gameObject.GetComponent<Image>().sprite = main.AUG_image[spriteIndex];
    //    press.pressedSprite = main.AUG_image[spriteIndex];
    //    press.disabledSprite = main.AUG_image[spriteIndex];
    //    gameObject.GetComponent<Button>().spriteState = press;
    //    augLock = Instantiate(main.augLock, gameObject.transform);
    //    startEffect();
    //    //Debug.Log("augmentスタート呼んでるよ");
    //}

    //virtual public void upgrade() { }
    //virtual public bool unlock() { return false; }
    //virtual public void effect() { }
    //void startEffect()
    //{
    //    if (isGet)
    //    {
    //        if (!isEffect)
    //        {
    //            effect();
    //            isEffect = true;
    //        }
    //        isGetText = " (Purchased)";
    //    }
    //    else
    //    {
    //        isGetText = "";
    //    }
    //}
    //public void get(ref double resources)
    //{
    //    resources -= cost;
    //    getReward();
    //    isGet = true;
    //    canPurchase = false;
    //}

    //public virtual void getReward()
    //{

    //}
    //public bool canPurchase;
    //public void checkButton(double Resources)
    //{
    //    if (!isGet)
    //    {
    //        //条件が解禁されたときの処理
    //        if (unlock()||isUnlocked)
    //        {
    //            if (augLock != null)
    //            {
    //                Destroy(augLock);
    //            }

    //            if (gameObject.GetComponent<Button>().enabled == false)
    //            {
    //                gameObject.GetComponent<Button>().enabled = true;
    //            }
    //        }
    //        else
    //        {
    //            if (gameObject.GetComponent<Button>().enabled == true)
    //            {
    //                gameObject.GetComponent<Button>().enabled = false;
    //            }
    //        }

    //        if (cost > Resources)
    //        {
    //            gameObject.GetComponent<Button>().interactable = false;
    //            canPurchase = false;
    //        }
    //        else
    //        {
    //            gameObject.GetComponent<Button>().interactable = true;
    //            canPurchase = true && unlock();
    //        }
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Button>().interactable = false;
    //        if(augLock != null)
    //        {
    //            Destroy(augLock);
    //        }

    //        setActive(gameObject.transform.GetChild(1).gameObject);
    //    }
    //}
    //public void update()
    //{
    //    if (window.activeSelf)
    //    {
    //        window.transform.GetChild(0).GetComponent<Text>().text = Name + isGetText;
    //        window.transform.GetChild(1).GetComponent<Text>().text = "";
    //        window.transform.GetChild(2).GetComponent<Text>().text = explain;
    //        window.transform.GetChild(3).GetComponent<Text>().text = condition + unlockText;
    //        window.transform.GetChild(4).GetComponent<Text>().text = "Current Progress : " + currentCondition;
    //        window.transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = gold;
    //        window.transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = wood;
    //        window.transform.GetChild(7).transform.GetChild(1).GetComponent<Text>().text = food;

    //        if (window != null)
    //        {
    //            if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
    //            {
    //                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
    //            }
    //            else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
    //            {
    //                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
    //            }
    //            else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
    //            {
    //                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
    //            }
    //            else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
    //            {
    //                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50.0f);
    //            }
    //        }
    //    }

    //        //isGetのときの処理
    //        if (isGet)
    //        {
    //            if (!isEffect)
    //            {
    //                effect();
    //                isEffect = true;
    //            }
    //            isGetText = " (Purchased)";
    //        }
    //        else
    //        {
    //            isGetText = "";
    //        }

    //        if (unlock())
    //        {
    //            unlockText = " (unlocked !)";
    //        }
    //        else
    //        {
    //            unlockText = "";
    //        }
        
    //}

}
