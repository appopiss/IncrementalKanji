using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public string lastTime;
    public string birthDate;
    public bool isContinuePlay;
    public double allTime;

    public float SEVolume;
    public float BGMVolume;

    public long ascendPoint;
    /* libraryここまで */
    /* ここから永久に保存したい変数をpublicで宣言していく */
    /* 初期化はSave */
    public int[] AllyNum; //辞書、所持数
    public int[] CrystalLimit; //各属性のクリスタル所持数のキャパ

}