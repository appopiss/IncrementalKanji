using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using static System.Math;
using static UsefulMethod;

public class doAscend : MonoBehaviour
{
    //public DateTime startTime { get{ return DateTime.FromBinary(Convert.ToInt64(Main.SR.ascendTime)); }
    //    set { Main.SR.ascendTime = value.ToBinary().ToString(); }
    //}
    //Main main;
    //public bool isAscend { get => Main.S.isAscend; set => Main.S.isAscend = value; }
    //public ConfirmDefault confirm;

    //public double calculateAscendPoint()
    //{
    //    return (Pow(Main.SR.playerRank, 1.2) - 4) * (GetMain().ascendList[2].calculateCurrentValue())
    //        * (1 + calculateTimeFactor())*(1+ calculateEnemyFactor())*(1+main.augFactor.AUG_ascend2)*(1+main.augFactor.AUG_ascend4);
    //}

    //public double calculateEnemyFactor()
    //{
    //    if(Main.SR.totalEnemyKilledR == 0)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return Log(Main.SR.totalEnemyKilledR) / Log(100);
    //    }
    //}
    //// Start is called before the first frame update
    //private void Awake()
    //{
    //    main = GetMain();
    //    gameObject.GetComponent<Button>().onClick.AddListener(confirmAscend);
    //    if (!isAscend)
    //    {
    //        startTime = DateTime.Now;
    //        isAscend = true;
    //    }
    //}

    //void Start()
    //{

    //}

    //void confirmAscend()
    //{
    //    if (Main.S.isOnAscendConfirm)
    //    {
    //        doAscension();
    //    }
    //    else
    //    {
    //        confirm.StartConfirm(doAscension, main.windowShowCanvas,
    //    "By resetting your all data except Jems and Research, you will gain AP that can be used to increase some abilitys.\n\n" +
    //    "Do you really ascend?\n");
    //    }
    //}

    //void doAscension()
    //{
        
    //    isAscend = false;
    //    main.questQuit.quiteQuest();
    //    Main.S.contestId = Main.S.tempContestId;
    //    Main.S.ascendPoint += calculateAscendPoint();
    //    Main.S.totalGainAP += calculateAscendPoint();
    //    Main.S.AscendNum++;
    //    saveCtrl.setSaveKey();
    //    PlayerPrefs.DeleteKey(keyList.resetSaveKey);
    //    SceneManager.LoadScene("wine");
    //    closeWindow();
    //}

    //double calculateTimeFactor()
    //{
    //    float timeFactor = DeltaTimeFloat(startTime);
    //    double ans = Log(UsefulMethod.ZC(timeFactor)) / Log(12 * 3600);
    //    return ans;
    //}

    //void closeWindow()
    //{
    //    UsefulMethod.setFalse(gameObject.transform.parent.gameObject);
    //}

    //private void Update()
    //{
    //    main.ascensionPointText.text = "AP : " + UsefulMethod.tDigit(Main.S.ascendPoint);
    //    if(Main.SR.playerRank >= 5)
    //    {
    //        gameObject.GetComponent<Button>().interactable = true;
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Button>().interactable = false;
    //    }


    //    //ひとつでもtoggleがtrueだったらbreak
    //    //全てfalseの場合のみContestIdを0にする。
    //    if (main.contests.Length > 0)
    //    {
    //        foreach (CONTEST contest in main.contests)
    //        {
    //            if (contest.thisToggle.isOn)
    //            {
    //                break;
    //            }
    //            Main.S.tempContestId = 0;
    //        }
    //    }
    //}
}
