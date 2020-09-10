using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class Main : MonoBehaviour
{
    public double allTime { get => S.allTime; set => S.allTime = value; }
    public DateTime birthTime
    {
        get { return DateTime.FromBinary(Convert.ToInt64(S.birthDate)); } //longはint64のエイリアス　戻り値はDateTime
        set { S.birthDate = value.ToBinary().ToString(); }
    }
    [NonSerialized]
    public DateTime ReleaseTime = DateTime.Parse("8/21/2019 7:00:00 AM");
    public DateTime lastTime//最後にプレイした時間。
    {
        get { return DateTime.FromBinary(Convert.ToInt64(S.lastTime)); }
        set { S.lastTime = value.ToBinary().ToString(); }
    }
    [Range(0.05f,10.0f)]
    public float tick=1.0f;
    public IdleActionCtrl idleActionCtrl;

    [SerializeField]
    public SaveR SR;　//参照型なので既定値はnull
    [SerializeField]
    public Save S;
    public SaveDeclare SD;
    

    public AudioSource SoundEffectSource;
    public Sound sound;
    public GameObject plainPopText;
    public Transform WindowShowCanvas;
    public GameObject[] PopTexts;
    public TextMeshProUGUI WaveText;

    public EnemyStatusInfo enemyStatusInfo;
    public EnemyCtrl enemyCtrl;

    public AllyCtrl allyCtrl;
    public AllyInfo[] allyInfo;
    public StageCtrl stageCtrl;
    public DictCtrl dictCtrl;
    public Gacha gacha;
    [NonSerialized] public PassiveEffectContainer passiveEffectContainer;

    public TextMeshProUGUI goldText;
    
    /* Libraryここまで */

    private void Awake()
    {
        BASE.main = this;
        SoundEffectSource = gameObject.GetOrAddComponent<AudioSource>();
    }


    void Start()
    {
        //初めてのプレイだったら現在の値を代入
        if (!S.isContinuePlay) //boolの初期値はfalse
        {
            birthTime = DateTime.Now;
            lastTime = DateTime.Now;
            S.isContinuePlay = true;
        }
        //不正な時間が入っていたら現在の値を代入
        if(lastTime < ReleaseTime || lastTime > DateTime.Now)
        {
            lastTime = DateTime.Now;
        }
        StartCoroutine(plusTime());
    }


    IEnumerator plusTime()
    {
        while (true)
        {
            allTime++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public AllyInfo this[EnemyKind id]　//インデクサ
    {
        get => allyCtrl.allies[(int)id];
    }
}
