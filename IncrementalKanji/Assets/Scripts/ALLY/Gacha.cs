using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static BASE;
using static Rarity;

public class Gacha : BASE
{
    public Image HatenaObject;
    public Transform allyPlace;
    public Button CgachaButton;
    public Button SgachaButton;
    GachaInfo Cgacha; //NormalGacha
    GachaInfo Sgacha; //SuperGacha
    public GachaInfo FirstFireGacha;
    public GachaInfo FirstWaterGacha;
    public GachaInfo FirstWoodGacha;
    // Use this for initialization
    void Awake()
    {
        StartBASE();
        Cgacha = new GachaInfo(new int[] { 5000,3000,1500,400,100}, main.enemyCtrl.enemies);
        Sgacha = new GachaInfo(new int[] { 0,0,0,8000,2000}, main.enemyCtrl.enemies.Where(x => x.rarity == SR || x.rarity == SSR));
        FirstFireGacha = new GachaInfo(new int[] { 5000, 3000, 1500, 400, 100 }, main.enemyCtrl.enemies.Where(x => x.thisAttribute == Attr.fire));
        FirstWaterGacha = new GachaInfo(new int[] { 5000, 3000, 1500, 400, 100 }, main.enemyCtrl.enemies.Where(x => x.thisAttribute == Attr.water));
        FirstWoodGacha = new GachaInfo(new int[] { 5000, 3000, 1500, 400, 100 }, main.enemyCtrl.enemies.Where(x => x.thisAttribute == Attr.grass));
        CgachaButton.onClick.AddListener(() => C_gacha());
        SgachaButton.onClick.AddListener(() => S_gacha());
    }

    //C : 5000
    //UC : 3000
    //R : 1500
    //SR : 400
    //SSR : 100
    public void C_gacha()
    {
        Cgacha.Gacha();
    }

    public void S_gacha()
    {
        Sgacha.Gacha();
    }
    public void FirstGacha(GachaInfo gacha)
    {
        AllyInfo getAlly = gacha.Gacha();
        gacha.SetToSlot(getAlly);
    }
}

public class GachaInfo
{
    public int[] probs = new int[5];
    List<EnemyInfo> CandList = new List<EnemyInfo>();
    List<EnemyInfo> C_enemies = new List<EnemyInfo>();
    List<EnemyInfo> UC_enemies = new List<EnemyInfo>();
    List<EnemyInfo> R_enemies = new List<EnemyInfo>();
    List<EnemyInfo> SR_enemies = new List<EnemyInfo>();
    List<EnemyInfo> SSR_enemies = new List<EnemyInfo>();
    List<EnemyInfo> FinalList = new List<EnemyInfo>();
    void AddKanjiToList(IEnumerable<EnemyInfo> enemyInfo)
    {
        foreach (EnemyInfo enemy in enemyInfo)
        {
            switch (enemy.rarity)
            {
                case C:
                    C_enemies.Add(enemy);
                    break;
                case UC:
                    UC_enemies.Add(enemy);
                    break;
                case R:
                    R_enemies.Add(enemy);
                    break;
                case SR:
                    SR_enemies.Add(enemy);
                    break;
                case SSR:
                    SSR_enemies.Add(enemy);
                    break;
                case none:
                    break;
            }
        }
    }
    List<EnemyInfo> ChooseFinalList()
    {
        int rand = UnityEngine.Random.Range(0, 10000); //0から9999
        if (rand < probs[0])
        {
            FinalList = C_enemies;
        }
        else if (rand < probs[1])
        {
            FinalList = UC_enemies;
        }
        else if (rand < probs[2])
        {
            FinalList = R_enemies;
        }
        else if (rand < probs[3])
        {
            FinalList = SR_enemies;
        }
        else  
        {
            FinalList = SSR_enemies;
        }

        return FinalList;
    }
    AllyInfo ChooseFinalKanji()
    {
        if (FinalList.Count == 0)
            return null;

        int rand2 = UnityEngine.Random.Range(0, FinalList.Count);
        EnemyKind chosenKind = FinalList[rand2].thisKind;
        main[chosenKind].allyNum++;
        main[chosenKind].currentHp = main.enemyCtrl[chosenKind].HP.Number;
        //Image allypre = UnityEngine.Object.Instantiate(main.gacha.AllyPre, main.gacha.allyPlace);
        main.gacha.HatenaObject.sprite = main.enemyCtrl[chosenKind].thisImage;
        return main[FinalList[rand2].thisKind];
    }
    public GachaInfo(int[] probs, IEnumerable<EnemyInfo> enemyInfos)
    {
        this.probs = probs;
        this.CandList = enemyInfos.ToList<EnemyInfo>();
        this.probs = AdjustProb();
        AddKanjiToList(CandList);
    }
    int[] AdjustProb()
    {
        int[] newProb = new int[5];
        int temp = 0;
        //(5000,3000,1000,700,300)
        for (int i = 0; i < probs.Length; i++)
        {
            newProb[i] = probs[i] + temp;
            temp += probs[i];
        }
        //(5000,8000.9000,9700,10000)
        return newProb;
    }
    public AllyInfo Gacha()
    {
        ChooseFinalList();
        return ChooseFinalKanji();
    }
    public void SetToSlot(AllyInfo info)
    {
        main.allyCtrl.allySlots[0].Set(info.thisKind);
    }
}