using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
// BASEクラスのStaticメンバーをインポート
using static BASE;
using UnityEngine.Networking.Match;
using System.Linq;

public enum Rarity
{
    none,
    C,
    UC,
    R,
    SR,
    SSR,
}
//zokusei
public enum Attr
{
    normal,
    fire,
	water,
	grass,
	woman,
	stone,
	thread,
	wood,
	fish,
	bug,
	bird,
	eye,
	beast,
	horse,
	rain,
	desease,
	death,
	demon

}

public interface INumber<T>
{
    //ステータスの値
	T Number { get;}
}
public interface ILevelValue<T>
{
	Func<T> BaseValueByLevel { get; set; }
}
public abstract class STATUS<T> : INumber<T> 
{
    public virtual T Number { get; }
    protected  double SumAddDelegate(List<Func<double>> funcs)
    {
		double temp = 0;
        foreach(Func<double> func in funcs)
        {
			temp += func();
        }
		return temp;
    }
	protected  double SumAddDelegate(List<Func<int>> funcs)
	{
		int temp = 0;
		foreach (Func<int> func in funcs)
		{
			temp += func();
		}
		return temp;
	}
	protected  double SumMulDelegate(List<Func<double>> funcs)
    {
		double temp = 1.0;
		foreach (Func<double> func in funcs)
		{
			temp *= func();
		}
		return temp;
	}
    public  void AddAddDelegate(Func<T> func, bool isStatic)
    {
		if (!isStatic)
			AddDelegate.Add(func);
		else
			S_AddDelegate.Add(func);
    }
    public  void AddMulDelegate(Func<double> func, bool isStatic)
    {
		if (!isStatic)
			MulDelegate.Add(func);
		else
			S_MulDelegate.Add(func);
	}
	//メンバデリゲート 
	public List<Func<T>> AddDelegate = new List<Func<T>>();
	public  List<Func<double>> MulDelegate = new List<Func<double>>();
	//静的デリゲート
	public static List<Func<T>> S_AddDelegate = new List<Func<T>>();
	public static List<Func<double>> S_MulDelegate = new List<Func<double>>();
}
public class ActionNum : STATUS<int>
{
	public override int Number { get => (int)((1 + SumAddDelegate(AddDelegate) + SumAddDelegate(S_AddDelegate))
            * (SumMulDelegate(MulDelegate)*SumMulDelegate(S_MulDelegate))); }
}

public class HP : STATUS<double>, ILevelValue<double>
{
	public override double Number { get => (BaseHPbyLevel() + SumAddDelegate(AddDelegate) + SumAddDelegate(S_AddDelegate))
            * (SumMulDelegate(S_MulDelegate) *SumMulDelegate(MulDelegate)); }
    public Func<double> BaseValueByLevel { get => BaseHPbyLevel; set => BaseHPbyLevel = value; }
    Func<double> BaseHPbyLevel = () => 0;
}

public class IdleDamage : STATUS<double>, ILevelValue<double>
{
	public override double Number { get => (BaseIdleDamagebyLevel() + SumAddDelegate(AddDelegate) )* SumMulDelegate(MulDelegate); }

    public Func<double> BaseValueByLevel { get => BaseIdleDamagebyLevel; set => BaseIdleDamagebyLevel = value; }

    Func<double> BaseIdleDamagebyLevel = () => 0;
}


public class EnemyInfo {
    //コンストラクタ
    //画像、フレーバーテキスト
    public EnemyInfo(EnemyKind thisKind, string name, string flavorText, Rarity rarity, MOVE move = null)
    {
		this.thisKind = thisKind;
		main.allyCtrl.allies.Add(new AllyInfo(thisKind));
        if(main[thisKind].level == 0) { main[thisKind].level = 1; }
		this.thisName = name;
		this.flavorText = flavorText;
		this.rarity = rarity;
		this.thisImage = main.enemyCtrl.enemyImages[(int)thisKind];
        if(move != null)
        {
            moveInfo = move;
            moveInfo.thisInfo = this;
			moveInfo.Initialize();
        }
        else
        {
            moveInfo = new Empty();　//アップキャスト nullパターン
        }
    }
	//ステータス
	public string thisName;
	public string flavorText;
    //↓火とか水とかの漢字の画像
	public Sprite thisImage;
	public EnemyKind thisKind;
	public Rarity rarity;
	public Attr thisAttribute;
	public float attackInterval = 1.0f;
	public HP HP = new HP();
	public IdleDamage IdleDamage = new IdleDamage();
    public MOVE moveInfo;
	public ActionNum actionNum = new ActionNum();
	public Func<int,double> requiredExp = (x) => 0;
}

public enum EnemyKind
{
    nothing,//null
	一,二,三,四,五,六,七,八,九,十,百,千,上,下,子,口,土,弓,山,刀,力,円,手,今,母,父,友,爪,己, // normal
    火,炎,灰,災,炭,煌,灸,爨,燹,熨, //fire
	池,灣,瀛,湫,涙,汝,灘,沖,汁,瀧,渓,涎,淀,澤,波, //water
	草, 苔, 芝, 花, 芯, 芽, 茎, 苗, 茨, 茶, 蕾, 箒, 葱, 藻, 菌, //grass
	女,姉,妹,姪,姑,婆,娚,娘,姫,嫁,媼,孀,嫐, //woman
	砂,砿,砥,砺,礫,磯,石,碇,硲,砦,磐,　//stone
	糸,繭,科,紅,紙,紬,絆,絵,綿,絹,網,纜,縡,緑,//thread
	木,札,机,杉,村,松,枝,枕,枠,林,森,柊,桁,縦,檻, // wood
	魚,鮎,鯰,鮫,鯨,鯛,鮭,鰯,鮃,鯱,鮪,鯉,鱚,鰻,鰹, //fish
	虫,虱,蚕,蜜,蛍,蝗,蟲,蟹,蠧,蛹,蝶,蠅,蜂,蛩, //bug
	鳥,鴎,鴉,鶯,鵙,鷲,鷹,鳩,鶏,鵺,鷺,鸛,鳳, //bird
	目,眇,眩,眦,瞳,睫,瞼,相,眉,真, //eye
	犬,犲,狆,狄,狛,狐,狸,狼,猫,猪,獏,獅,猿, //beast
	馬,駱,駅,駒,騅,驂,験,驟,驫,//horse
	雨,霊,雫,雪,雲,雷,電,雹,霆,霙,霖,霞,霸,霧, //rain
	病,疣,疵,癌,痣,瘧,瘤,癘,癖, //desease
	死,殀,殃,殍,殯, //death
	鬼,魂,塊,魔,魁,魑, //demon
	金 //gold
}
