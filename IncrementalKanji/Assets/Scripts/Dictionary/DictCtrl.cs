using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using TMPro;
using static BASE;

public class DictCtrl : BASE {

	public TextMeshProUGUI[] CrystalNumTexts;
	public TextMeshProUGUI numberText, levelText, hpText, damageText, effectText;
	public Image InfoImage;
	public Image AllyImage;
    public Sprite[] RankImages;
    Image RankImage;
	public Transform NormalCanvas, FireCanvas, WaterCanvas, GrassCanvas;
    public Info[] infos;
	// Use this for initialization
	void Awake () {
		StartBASE();
        infos = new Info[240];
        RankImage = AllyImage.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
	}
    //Infoを返す関数
    public Info info(EnemyKind kind)
    {
		return infos[(int)kind];
    }

	void Start () {
		foreach(EnemyInfo enemy in main.enemyCtrl.enemies)
        {
			Image aaa = null;
            switch (enemy.thisAttribute)
            {
				case Attr.normal:
					aaa = Instantiate(InfoImage, NormalCanvas);
					break;
				case Attr.fire:
					aaa = Instantiate(InfoImage, FireCanvas);
					break;
				case Attr.water:
					aaa = Instantiate(InfoImage, WaterCanvas);
					break;
                case Attr.grass:
                    aaa = Instantiate(InfoImage, GrassCanvas);
                    break;
			}
			if (aaa != null)
			{
				aaa.gameObject.AddComponent<Info>();
				//infos.Add(aaa.GetComponent<Info>());
                infos[(int)enemy.thisKind] = aaa.GetComponent<Info>();
				aaa.GetComponent<Info>().thisInfo = enemy;
				aaa.GetComponent<Info>().hatena = aaa.gameObject.transform.GetChild(0).gameObject;
			}
		}
	}

	private void Update()
	{
		for (int i=0; i<CrystalNumTexts.Length; i++)
		{
			CrystalNumTexts[i].text = main.SR.CrystalNum[i].ToString();
		}
	}

	public class Info : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
    {
		public EnemyInfo thisInfo;
		public Image thisImage;
		Image TempImage;
		public GameObject hatena;
		public Button thisButton;
		bool isUnlocked;
		static EnemyKind InputEnemyId;

		private void Awake()
		{
			thisImage = gameObject.GetComponent<Image>(); //プレハブのInfoImage
			thisButton = gameObject.GetComponent<Button>();
			thisButton.onClick.AddListener(ShowInfoOnTheRight);
		}

		private void Start()
		{
			if (main[thisInfo.thisKind].allyNum > 0)
				Destroy(hatena.gameObject);

			ReflectInfo();
		}
		private void Update()
		{
			if (hatena.gameObject == null)
				isUnlocked = true;
			else
				isUnlocked = false;
		}
		public void OnBeginDrag(PointerEventData eventData) //ドラッグを始めたとき
        {
			TempImage = Instantiate(thisImage, main.WindowShowCanvas);
			TempImage.GetComponent<Info>().enabled = false;
			TempImage.raycastTarget = false; //マウスが貫通する
			TempImage.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
			TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
			InputEnemyId = thisInfo.thisKind;
		}
		public void OnDrag(PointerEventData eventData) //ドラッグしているとき
		{
			TempImage.GetComponent<RectTransform>().anchoredPosition = eventData.position;
		}
		public void OnEndDrag(PointerEventData eventData)　//ドラッグを終了するとき
		{
            for (int i = 0; i < main.allyCtrl.allySlots.Length; i++)
            {
				main.allyCtrl.allySlots[i].SetByDrug(InputEnemyId);
            }
			Destroy(TempImage.gameObject);
			InputEnemyId = EnemyKind.nothing;
		}
		

        public void ReflectInfo()
        {
			thisImage.sprite = thisInfo.thisImage;
			if (hatena != null && main[thisInfo.thisKind].allyNum > 0)
				Destroy(hatena.gameObject);
        }

        float ExpBonus()
        {
			return main[thisInfo.thisKind].allyNum * 0.1f;
		}

        void ShowInfoOnTheRight()
        {
			if (!isUnlocked)
				return;
			main.dictCtrl.AllyImage.sprite = thisImage.sprite;
            main.dictCtrl.RankImage.sprite = main.dictCtrl.RankImages[(int)main[thisInfo.thisKind].rarity-1];
			main.dictCtrl.numberText.text = "- NoP  "+tDigit(main[thisInfo.thisKind].allyNum)+
                "   (EXP bonus + "+ExpBonus().ToString("F1")+"%)";
			main.dictCtrl.levelText.text = "- LEVEL  "+
				tDigit(main[thisInfo.thisKind].level) +
                "    (EXP : "+
				tDigit(main[thisInfo.thisKind].exp) +"/"+
                tDigit(main[thisInfo.thisKind].requiredExp)
                +")";
			main.dictCtrl.hpText.text = "- HP    " + tDigit(main[thisInfo.thisKind].currentHp) + "/" + tDigit(main[thisInfo.thisKind].MaxHp());
			main.dictCtrl.damageText.text = "- Idle Attack    " + tDigit(main[thisInfo.thisKind].IdleDamage(),1) + " / s";
			main.dictCtrl.effectText.text = "junbityuu";
		}

       
    }
}
