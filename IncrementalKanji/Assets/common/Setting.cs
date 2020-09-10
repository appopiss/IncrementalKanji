using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Setting : BASE {

    public float SEVolume
    {
        get { return main.S.SEVolume; }
        set
        {
            main.S.SEVolume = value;
            main.sound.ChangeSEVolume(value);
        }
    }
    public float BGMVolume
    {
        get { return main.S.BGMVolume; }
        set
        {
            main.S.BGMVolume = value;
            main.sound.ChangeBGMVolume(value);
        }
    }

    public Slider SESlider, BGMSlider;

    // Use this for initialization
    void Awake () {
		StartBASE();
    }

    private void Start()
    {
        //SESlider.value = SEVolume;
        //BGMSlider.value = BGMVolume;

        StartCoroutine(FixedUpdateCor());
    }

    IEnumerator FixedUpdateCor()
    {
        while (true)
        {
            //SEVolume = SESlider.value;
            //BGMVolume = BGMSlider.value;
            yield return new WaitForSeconds(main.tick);
        }
    }
}
