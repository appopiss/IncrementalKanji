using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BASE;
using static UsefulMethod;

public class PassiveEffectContainer : MonoBehaviour
{
    public Default_EffectSingle hoge_effect_add;
    private void Awake()
    {
        //儀式
        main.passiveEffectContainer = this;
        //代入していく。
        hoge_effect_add = new Default_EffectSingle(0, (value) => { return " - Hogehoge : " + tDigit(value); });
    }

    private void Start() { StartCoroutine(LoopCoroutine()); }
    //サンプル
    private void Update() 
    {
        //全体の効果
        Debug.Log(hoge_effect_add.Detail());
        //それぞれの効果
        for (int i = 0; i < PassiveEffectSample.allies.Count; i++)
        {
            Debug.Log(PassiveEffectSample.allies[i].effects.Detail(PassiveEffectSample.allies[i].level));
        }
    }

    WaitForSecondsRealtime interval = new WaitForSecondsRealtime(1.0f);
    IEnumerator LoopCoroutine()
    {
        while (true)
        {
            yield return interval;
            //ここににリセットの処理を書いていく。
            hoge_effect_add.Reset();

            //効果の計算.サンプル
            for (int i = 0; i < PassiveEffectSample.allies.Count; i++)
            {
                PassiveEffectSample.allies[i].effects.Calculate(PassiveEffectSample.allies[i].level);
            }
        }
    }
}
