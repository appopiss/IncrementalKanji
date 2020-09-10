using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using System;
using PlayFab.ClientModels;

//ステージごとのメッセージを管理するクラス
public class MessageCtrl : MonoBehaviour
{
    public TextMeshProUGUI MessageText;
    bool isRunning;
    int stopRequiremet; //コルーチンが停止する条件　10のとき停止する

    List<string> fireMessage = new List<string>
    {
        "one of the most dangerous thing in your house is fire.",
        "The sun seems to be on fire, but actully its not."
    };

    List<string> waterMessage = new List<string>
    {
        "water is like a paper"
    };

    private void Start()
    {
        StartCoroutine(MessageIndicate(fireMessage));
    }


    /* void Update() コルーチンが停止する条件
     {
         if ()
         {
             stopRequiremet = 10;
         }
         else
         {
             stopRequiremet = 0;
         }
         StartCoroutine(MessageIndicate(fireMessage));
     }
     */

    IEnumerator MessageIndicate(List<string> messgePattern)
    {
        if (isRunning)
            yield break;
        isRunning = true;

        while (stopRequiremet == 0) //10の時、停止
        {
            int MessageIndex = UnityEngine.Random.Range(0, messgePattern.Count); // UnityEngineつけないとエラー
            string message = messgePattern[MessageIndex];
            MessageText.text = message;
            yield return new WaitForSecondsRealtime(8.0f);
        }

        isRunning = false;
    }
}
