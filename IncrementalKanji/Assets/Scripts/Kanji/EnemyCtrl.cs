using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;
using static Rarity;
using System.Xml.XPath;

//ゲームに出てくる敵を全てここに書き込む
public class EnemyCtrl : BASE {

	//全ての敵を格納するリスト
	public List<EnemyInfo> enemies = new List<EnemyInfo>();

	public EnemyInfo this[EnemyKind id]
	{
		get => enemies[(int)id];
	}

	//敵の画像の配列
	[EnumLabel(typeof(EnemyKind))]	
	public Sprite[] enemyImages;


	// Use this for initialization
	void Awake()
	{
		StartBASE();
		
		enemies.Add(new EnemyInfo(EnemyKind.nothing, "", "", none));
		//雑漢
		enemies.Add(new EnemyInfo(EnemyKind.一, "ichi", "one", C,new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.二, "ni", "two", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.三, "san", "three", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.四, "yon", "four", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.五, "go", "five", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.六, "roku", "six", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.七, "nana", "seven", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.八, "hachi", "eight", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.九, "kyu", "nine", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.十, "ju", "ten", C, new OneToTen()));
		enemies.Add(new EnemyInfo(EnemyKind.百, "hyaku", "hundred", C));
		enemies.Add(new EnemyInfo(EnemyKind.千, "sen", "thousand", C));
		enemies.Add(new EnemyInfo(EnemyKind.上, "ue", "up", C));
		enemies.Add(new EnemyInfo(EnemyKind.下, "shita", "down", C));
		enemies.Add(new EnemyInfo(EnemyKind.子, "ko", "children", C, new MultiActionAll(3)));
		enemies.Add(new EnemyInfo(EnemyKind.口, "kuchi", "mouth", C));
		enemies.Add(new EnemyInfo(EnemyKind.土, "tsuchi", "soil", C, new MultiActionAll(3)));
		enemies.Add(new EnemyInfo(EnemyKind.弓, "yumi", "bow", C, new Rage()));
		enemies.Add(new EnemyInfo(EnemyKind.山, "yama", "mountain", C));
		enemies.Add(new EnemyInfo(EnemyKind.刀, "katana", "sword", C));
		enemies.Add(new EnemyInfo(EnemyKind.力, "chikara", "power", C));
		enemies.Add(new EnemyInfo(EnemyKind.円, "en", "japanese yen", C));
		enemies.Add(new EnemyInfo(EnemyKind.手, "te", "hand", C));
		enemies.Add(new EnemyInfo(EnemyKind.今, "ima", "now", C));
		enemies.Add(new EnemyInfo(EnemyKind.母, "haha", "mother", C));
		enemies.Add(new EnemyInfo(EnemyKind.父, "chichi", "father", C));
		enemies.Add(new EnemyInfo(EnemyKind.友, "tomo", "friend", C));
		enemies.Add(new EnemyInfo(EnemyKind.爪, "tsume", "nail", C));
		enemies.Add(new EnemyInfo(EnemyKind.己, "onore", "yourself", C));

		//fire
		enemies.Add(new EnemyInfo(EnemyKind.火, "hi", "fire", C));
		enemies.Add(new EnemyInfo(EnemyKind.炎, "honoo", "flame", UC));
		enemies.Add(new EnemyInfo(EnemyKind.灰, "hai", "ash", UC));
		enemies.Add(new EnemyInfo(EnemyKind.災, "wazawai", "disaster", UC));
		enemies.Add(new EnemyInfo(EnemyKind.炭, "sumi", "charcoal", UC));
		enemies.Add(new EnemyInfo(EnemyKind.煌, "kirameki", "glitter", SR));
		enemies.Add(new EnemyInfo(EnemyKind.灸, "yaito", "moxibustion", R, new MultiActionAll(3)));
		enemies.Add(new EnemyInfo(EnemyKind.爨, "kamado", "oven", R));
		enemies.Add(new EnemyInfo(EnemyKind.燹, "nobi", "wildfire", R));
		enemies.Add(new EnemyInfo(EnemyKind.熨, "hinoshi", "ancient iron", R));

		//water
		enemies.Add(new EnemyInfo(EnemyKind.池, "ike", "pond", C));
		enemies.Add(new EnemyInfo(EnemyKind.灣, "irie", "gulf", R));
		enemies.Add(new EnemyInfo(EnemyKind.瀛, "umi", "ocean", SR));
		enemies.Add(new EnemyInfo(EnemyKind.湫, "kute", "swamp", R));
		enemies.Add(new EnemyInfo(EnemyKind.涙, "namida", "tears", UC));
		enemies.Add(new EnemyInfo(EnemyKind.汝, "nanji", "ancient you", SR));
		enemies.Add(new EnemyInfo(EnemyKind.灘, "nada", "challenging area in the sea", R));
		enemies.Add(new EnemyInfo(EnemyKind.沖, "oki", "offshore", UC));
		enemies.Add(new EnemyInfo(EnemyKind.汁, "shiru", "sap", UC));
		enemies.Add(new EnemyInfo(EnemyKind.瀧, "taki", "waterfall", R));
		enemies.Add(new EnemyInfo(EnemyKind.渓, "tani", "valley", R));
		enemies.Add(new EnemyInfo(EnemyKind.涎, "yodare", "saliva", UC));
		enemies.Add(new EnemyInfo(EnemyKind.淀, "yodo", "backwater", R));
		enemies.Add(new EnemyInfo(EnemyKind.澤, "sawa", "moisture", R));
		enemies.Add(new EnemyInfo(EnemyKind.波, "nami", "wave", R));

		//grass
		enemies.Add(new EnemyInfo(EnemyKind.草, "kusa", "grass", C));
		enemies.Add(new EnemyInfo(EnemyKind.苔, "koke", "moss", C));
		enemies.Add(new EnemyInfo(EnemyKind.芝, "shiba", "turf", R));
		enemies.Add(new EnemyInfo(EnemyKind.花, "hana", "flower", UC));
		enemies.Add(new EnemyInfo(EnemyKind.芯, "shin", "core", UC));
		enemies.Add(new EnemyInfo(EnemyKind.芽, "me", "sprout", UC));
		enemies.Add(new EnemyInfo(EnemyKind.茎, "kuki", "stalk", UC));
		enemies.Add(new EnemyInfo(EnemyKind.苗, "nae", "young plant", UC));
		enemies.Add(new EnemyInfo(EnemyKind.茨, "ibara", "thorn", UC));
		enemies.Add(new EnemyInfo(EnemyKind.茶, "cha", "green tea", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蕾, "tsubomi", "bud", R));
		enemies.Add(new EnemyInfo(EnemyKind.箒, "houki", "broom", UC));
		enemies.Add(new EnemyInfo(EnemyKind.葱, "negi", "leek", UC));
		enemies.Add(new EnemyInfo(EnemyKind.藻, "mo", "alga", UC));
		enemies.Add(new EnemyInfo(EnemyKind.菌, "kin", "germ", SR));

		//woman
		enemies.Add(new EnemyInfo(EnemyKind.女, "onnna", "woman", C));
		enemies.Add(new EnemyInfo(EnemyKind.姉, "ane", "older sister", UC));
		enemies.Add(new EnemyInfo(EnemyKind.妹, "imouto", "younger sister", UC));
		enemies.Add(new EnemyInfo(EnemyKind.姪, "mei", "niece", UC));
		enemies.Add(new EnemyInfo(EnemyKind.姑, "syutome", "mother-in-law", R));
		enemies.Add(new EnemyInfo(EnemyKind.婆, "baba", "old woman", R));
		enemies.Add(new EnemyInfo(EnemyKind.娚, "meoto", "married couple", SR));
		enemies.Add(new EnemyInfo(EnemyKind.娘, "musume", "daughter", UC));
		enemies.Add(new EnemyInfo(EnemyKind.姫, "hime", "princess", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.嫁, "yome", "wife", UC));
		enemies.Add(new EnemyInfo(EnemyKind.媼, "ouna", "elderly woman", R));
		enemies.Add(new EnemyInfo(EnemyKind.孀, "yamome", "widow", R));
		enemies.Add(new EnemyInfo(EnemyKind.嫐, "uwanari", "second wife", SR));

		//stone
		enemies.Add(new EnemyInfo(EnemyKind.砂, "suna", "sand", C));
		enemies.Add(new EnemyInfo(EnemyKind.砿, "aragane", "mineral", UC));
		enemies.Add(new EnemyInfo(EnemyKind.砥, "toishi", "whetstone", UC));
		enemies.Add(new EnemyInfo(EnemyKind.砺, "arato", "whetstone", R));
		enemies.Add(new EnemyInfo(EnemyKind.礫, "tsubute", "stone", R));
		enemies.Add(new EnemyInfo(EnemyKind.磯, "iso", "beach", UC));
		enemies.Add(new EnemyInfo(EnemyKind.石, "ishi", "stone", C));
		enemies.Add(new EnemyInfo(EnemyKind.碇, "ikari", "anchor", SR));
		enemies.Add(new EnemyInfo(EnemyKind.硲, "hazama", "valley", R));
		enemies.Add(new EnemyInfo(EnemyKind.砦, "toride", "fort", R));
		enemies.Add(new EnemyInfo(EnemyKind.磐, "iwa", "rock", UC));

		//thread
		enemies.Add(new EnemyInfo(EnemyKind.糸, "ito", "thread", C));
		enemies.Add(new EnemyInfo(EnemyKind.繭, "mayu", "cocoon", R));
		enemies.Add(new EnemyInfo(EnemyKind.科, "shina", "division", UC));
		enemies.Add(new EnemyInfo(EnemyKind.紅, "kurenai", "deep red", SR));
		enemies.Add(new EnemyInfo(EnemyKind.紙, "kami", "paper", C));
		enemies.Add(new EnemyInfo(EnemyKind.紬, "tsumugi", "pulling thread out of cocoon ", UC));
		enemies.Add(new EnemyInfo(EnemyKind.絆, "kizuna", "bond", SR));
		enemies.Add(new EnemyInfo(EnemyKind.絵, "e", "picture", SR));
		enemies.Add(new EnemyInfo(EnemyKind.綿, "wata", "cotton", UC));
		enemies.Add(new EnemyInfo(EnemyKind.絹, "kinu", "silk", UC));
		enemies.Add(new EnemyInfo(EnemyKind.網, "ami", "web", UC));
		enemies.Add(new EnemyInfo(EnemyKind.纜, "tomozuna", "stren line", SR));
		enemies.Add(new EnemyInfo(EnemyKind.縡, "koto", "stuff", SR));
		enemies.Add(new EnemyInfo(EnemyKind.緑, "midori", "green", UC));

		//wood
		enemies.Add(new EnemyInfo(EnemyKind.木, "ki", "wood", C));
		enemies.Add(new EnemyInfo(EnemyKind.札, "huda", "amulet made of paper", R));
		enemies.Add(new EnemyInfo(EnemyKind.机, "tsukue", "desk", UC));
		enemies.Add(new EnemyInfo(EnemyKind.杉, "sugi", "cedar", UC));
		enemies.Add(new EnemyInfo(EnemyKind.村, "mura", "village", UC));
		enemies.Add(new EnemyInfo(EnemyKind.松, "matsu", "pine", UC));
		enemies.Add(new EnemyInfo(EnemyKind.枝, "eda", "branch", UC));
		enemies.Add(new EnemyInfo(EnemyKind.枕, "makura", "pillow", UC));
		enemies.Add(new EnemyInfo(EnemyKind.枠, "waku", "frame", UC));
		enemies.Add(new EnemyInfo(EnemyKind.林, "hayashi", "grove", C));
		enemies.Add(new EnemyInfo(EnemyKind.森, "mori", "forest", UC));
		enemies.Add(new EnemyInfo(EnemyKind.柊, "hiiragi", "holy", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.桁, "keta", "digit", R));
		enemies.Add(new EnemyInfo(EnemyKind.縦, "tate", "verticality", R));
		enemies.Add(new EnemyInfo(EnemyKind.檻, "ori", "cage", R));

		//fish
		enemies.Add(new EnemyInfo(EnemyKind.魚, "sakana", "fish", C));
		enemies.Add(new EnemyInfo(EnemyKind.鮎, "ayu", "sweetfish", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鯰, "namazu", "catfish", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鮫, "same", "shark", SR));
		enemies.Add(new EnemyInfo(EnemyKind.鯨, "kujira", "whale", SR));
		enemies.Add(new EnemyInfo(EnemyKind.鯛, "tai", "bream", R));
		enemies.Add(new EnemyInfo(EnemyKind.鮭, "sake", "salmon", R));
		enemies.Add(new EnemyInfo(EnemyKind.鰯, "iwashi", "sardine", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鮃, "hirame", "flounder", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鯱, "shachi", "killer whale", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.鮪, "maguro", "tuna", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鯉, "koi", "carp", C));
		enemies.Add(new EnemyInfo(EnemyKind.鱚, "kisu", "sillaginoid", R));
		enemies.Add(new EnemyInfo(EnemyKind.鰻, "unagi", "eel", SR));
		enemies.Add(new EnemyInfo(EnemyKind.鰹, "katsuo", "bonito", R));

		//bug
		enemies.Add(new EnemyInfo(EnemyKind.虫, "mushi", "bug", C));
		enemies.Add(new EnemyInfo(EnemyKind.虱, "shirami", "lice", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蚕, "kaiko", "silkworm", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蜜, "mitsu", "honey", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蛍, "hotaru", "firefly", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蝗, "inago", "locust", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蟲, "mushi", "insect", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.蟹, "kani", "crab", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蠧, "kikuimushi", "bark beetle", SR));
		enemies.Add(new EnemyInfo(EnemyKind.蛹, "sanagi", "pupa", R));
		enemies.Add(new EnemyInfo(EnemyKind.蝶, "cho", "butterfly", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蠅, "hae", "fly", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蜂, "hachi", "bee", UC));
		enemies.Add(new EnemyInfo(EnemyKind.蛩, "koorogi", "cricket", R));

		//bird
		enemies.Add(new EnemyInfo(EnemyKind.鳥, "tori", "bird", C));
		enemies.Add(new EnemyInfo(EnemyKind.鴎, "kamome", "seagull", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鴉, "karasu", "crow", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鶯, "uguisu", "bush warbler", R));
		enemies.Add(new EnemyInfo(EnemyKind.鵙, "mozu", "shrike", SR));
		enemies.Add(new EnemyInfo(EnemyKind.鷲, "washi", "eagle", R));
		enemies.Add(new EnemyInfo(EnemyKind.鷹, "taka", "hawk", R));
		enemies.Add(new EnemyInfo(EnemyKind.鳩, "hato", "pegeon", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鶏, "niwatori", "chicken", UC));
		enemies.Add(new EnemyInfo(EnemyKind.鵺, "nue", "a legendary monster named Nue", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.鷺, "sagi", "egret", R));
		enemies.Add(new EnemyInfo(EnemyKind.鸛, "kounotori", "stork", SR));
		enemies.Add(new EnemyInfo(EnemyKind.鳳, "otori", "a chinese legendary bird", SSR));

		//eye
		enemies.Add(new EnemyInfo(EnemyKind.目, "me", "eye", C));
		enemies.Add(new EnemyInfo(EnemyKind.眇, "sugame", "squint eye", UC));
		enemies.Add(new EnemyInfo(EnemyKind.眩, "memai", "dizziness", UC));
		enemies.Add(new EnemyInfo(EnemyKind.眦, "manajiri", "corner of one's eye", UC));
		enemies.Add(new EnemyInfo(EnemyKind.瞳, "hitomi", "pupil", R));
		enemies.Add(new EnemyInfo(EnemyKind.睫, "matsuge", "eyelash", UC));
		enemies.Add(new EnemyInfo(EnemyKind.瞼, "mabuta", "eyelid", R));
		enemies.Add(new EnemyInfo(EnemyKind.相, "ai", "shape", UC));
		enemies.Add(new EnemyInfo(EnemyKind.眉, "mayu", "eyebrow", UC));
		enemies.Add(new EnemyInfo(EnemyKind.真, "makoto", "true", SR));

		//beast
		enemies.Add(new EnemyInfo(EnemyKind.犬, "inu", "dog", C));
		enemies.Add(new EnemyInfo(EnemyKind.犲, "yamainu", "wild dog", UC));
		enemies.Add(new EnemyInfo(EnemyKind.狆, "chin", "the name of ethnic group in China", R));
		enemies.Add(new EnemyInfo(EnemyKind.狄, "ebisu", "the name of ethnic group in North China", R));
		enemies.Add(new EnemyInfo(EnemyKind.狛, "koma", "guardian dogs", R));
		enemies.Add(new EnemyInfo(EnemyKind.狐, "kitsune", "fox", R));
		enemies.Add(new EnemyInfo(EnemyKind.狸, "tanuki", "raccoon dog", UC));
		enemies.Add(new EnemyInfo(EnemyKind.狼, "okami", "wolf", R));
		enemies.Add(new EnemyInfo(EnemyKind.猫, "neko", "cat", UC));
		enemies.Add(new EnemyInfo(EnemyKind.猪, "inoshishi", "wild boar", UC));
		enemies.Add(new EnemyInfo(EnemyKind.獏, "baku", "tapir", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.獅, "shishi", "lion", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.猿, "saru", "monkey", UC));

		//horse
		enemies.Add(new EnemyInfo(EnemyKind.馬, "uma", "horse", R));
		enemies.Add(new EnemyInfo(EnemyKind.駱, "kawarage", "horse with black mane", SR));
		enemies.Add(new EnemyInfo(EnemyKind.駅, "eki", "station", UC));
		enemies.Add(new EnemyInfo(EnemyKind.駒, "koma", "pony", R));
		enemies.Add(new EnemyInfo(EnemyKind.騅, "ashige", "grey", SR));
		enemies.Add(new EnemyInfo(EnemyKind.驂, "soeuma", "auxiliary horse", R));
		enemies.Add(new EnemyInfo(EnemyKind.験, "shirushi", "effect", R));
		enemies.Add(new EnemyInfo(EnemyKind.驟, "shibashiba", "fast", R));
		enemies.Add(new EnemyInfo(EnemyKind.驫, "hyu", "situation that many horses gather and run around", SSR));

		//rain
		enemies.Add(new EnemyInfo(EnemyKind.雨, "ame", "rain", UC));
		enemies.Add(new EnemyInfo(EnemyKind.霊, "tama", "ghost", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.雫, "shizuku", "drop", UC));
		enemies.Add(new EnemyInfo(EnemyKind.雪, "yuki", "snow", UC));
		enemies.Add(new EnemyInfo(EnemyKind.雲, "kumo", "cloud", UC));
		enemies.Add(new EnemyInfo(EnemyKind.雷, "kaminari", "thunder", R));
		enemies.Add(new EnemyInfo(EnemyKind.電, "inazuma", "lightning", R));
		enemies.Add(new EnemyInfo(EnemyKind.雹, "hyo", "hail", R));
		enemies.Add(new EnemyInfo(EnemyKind.霆, "ikazuchi", "thunder", SR));
		enemies.Add(new EnemyInfo(EnemyKind.霙, "mizore", "sleet", R));
		enemies.Add(new EnemyInfo(EnemyKind.霖, "nagaame", "long spell of rain", R));
		enemies.Add(new EnemyInfo(EnemyKind.霞, "kasumi", "fog", R));
		enemies.Add(new EnemyInfo(EnemyKind.霸, "hatagashira", "leader", SR));
		enemies.Add(new EnemyInfo(EnemyKind.霧, "kiri", "mist", R));

		//desease
		enemies.Add(new EnemyInfo(EnemyKind.病, "yamai", "desease", UC));
		enemies.Add(new EnemyInfo(EnemyKind.疣, "ibo", "wart", UC));
		enemies.Add(new EnemyInfo(EnemyKind.疵, "kizu", "damage", UC));
		enemies.Add(new EnemyInfo(EnemyKind.癌, "gan", "cancer", SR));
		enemies.Add(new EnemyInfo(EnemyKind.痣, "aza", "blotch", UC));
		enemies.Add(new EnemyInfo(EnemyKind.瘧, "okori", "malaria", R));
		enemies.Add(new EnemyInfo(EnemyKind.瘤, "kobu", "bump", UC));
		enemies.Add(new EnemyInfo(EnemyKind.癘, "eyami", "epidemic", R));
		enemies.Add(new EnemyInfo(EnemyKind.癖, "kuse", "habit", UC));

		//death
		enemies.Add(new EnemyInfo(EnemyKind.死, "shi", "death", SR));
		enemies.Add(new EnemyInfo(EnemyKind.殀, "wakajini", "premature death", SR));
		enemies.Add(new EnemyInfo(EnemyKind.殃, "wazawai", "disaster", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.殍, "uejini", "death from hunger", R));
		enemies.Add(new EnemyInfo(EnemyKind.殯, "karimogari", "ancient way to mourn the dead", SSR));

		//demon
		enemies.Add(new EnemyInfo(EnemyKind.鬼, "oni", "demon", SR));
		enemies.Add(new EnemyInfo(EnemyKind.魂, "tamashii", "soul", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.塊, "katamari", "mass", R));
		enemies.Add(new EnemyInfo(EnemyKind.魔, "ma", "devil", SSR));
		enemies.Add(new EnemyInfo(EnemyKind.魁, "sakigake", "pioneer", SR));
		enemies.Add(new EnemyInfo(EnemyKind.魑, "sudama", "mountain demon", SR));

		//gold
		enemies.Add(new EnemyInfo(EnemyKind.金, "kane", "gold", SSR));

		//ステータスを代入する
		UpdateStatus();
		UpdateExp();
		UpdateAttribute();


	}

	//ステータスの追加
    void UpdateStatus()
    {
        //指数関数確定か？
        foreach(EnemyInfo enemy in enemies)
        {
			double HP_initial = 0;
			double HP_base = 0;
			double ID_initial = 0; //ID = idle
			double ID_base = 0;
			Action<double, double> Set =
			(a,b) =>
			{
				HP_initial = a;
				ID_initial = b;
			};
			HP_base = 1.12;
			ID_base = 1.03;
			if (enemy.rarity == C) { Set(20, 2.0); }
			else if (enemy.rarity == UC) { Set(30, 4.0); }
			else if (enemy.rarity == R) { Set(40, 7.0); }

			//SR
			else if (enemy.thisKind == EnemyKind.煌) { Set(90, 0.3); }
			else if (enemy.thisKind == EnemyKind.瀛) { Set(30, 0.3); }
			else if (enemy.thisKind == EnemyKind.汝) { Set(30, 0.3); }

			AllyInfo thisAlly = main[enemy.thisKind];
            /*
			else if (enemy.thisKind == EnemyKind.娚)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.嫐)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.碇)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.紅)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.絆)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.絵)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.纜)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.縡)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.菌)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鮫)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鯨)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鰻)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.蠧)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鵙)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鸛)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.真)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.騅)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.霆)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.霸)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.癌)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.死)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.殀)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.鬼)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.魁)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}
			else if (enemy.thisKind == EnemyKind.魑)
			{
				enemy.HP = () => 30 * Math.Pow(enemy.level, 2.35);
				enemy.IdleDamage = () => 0.3 * Math.Pow(enemy.level, 2.35);
			}


			//SSR
			else if (enemy.thisKind == EnemyKind.柊)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.姫)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.鯱)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.蟲)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.鵺)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.鳳)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.獏)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.獅)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.驫)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.霊)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.殃)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.殯)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.魂)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
			else if (enemy.thisKind == EnemyKind.魔)
			{
				enemy.HP = () => 300 * Math.Pow(enemy.level, 2.45);
				enemy.IdleDamage = () => 30 * Math.Pow(enemy.level, 2.45);
			}
            */

			//hpとidleDamageに代入
			enemy.HP.BaseValueByLevel = () => HP_initial * Math.Pow(HP_base, main.SR.AllyLevel[(int)enemy.thisKind]) * HpUpbyDuplication(enemy);
			enemy.IdleDamage.BaseValueByLevel = () => ID_initial * Math.Pow(ID_base, main.SR.AllyLevel[(int)enemy.thisKind]) * IdleDamageUpByCrystalNum();
		}
    }

	//経験値の追加
	void UpdateExp()
	{

		foreach (EnemyInfo enemy in enemies)
		{
			if (enemy.rarity == C)
			{
                enemy.requiredExp = (x) => Math.Pow(x, 3) * 1.07;
			}
			if (enemy.rarity == UC)
			{
				enemy.requiredExp = (x) => Math.Pow(x, 3.3) * 1.08;
            }
			if (enemy.rarity == R)
			{
				enemy.requiredExp = (x) => Math.Pow(x, 3.7) * 1.09;
            }
			if (enemy.rarity == SR)
			{
				enemy.requiredExp = (x) => Math.Pow(x, 4.2) * 1.1;
            }
			if (enemy.rarity == SSR)
			{
				enemy.requiredExp = (x) => Math.Pow(x, 4.5) * 1.11;
            }


		}
	}

	//属性の追加
    void UpdateAttribute()
    {
        //EnemyKind 1 ~ 29 のときはnormal ...
		foreach(EnemyInfo enemy in enemies)
		{
			if (0 <= (int)enemy.thisKind && (int)enemy.thisKind <= 29)
			{
				enemy.thisAttribute = Attr.normal;
				enemy.attackInterval = 1.0f;
			}
			else if((int)enemy.thisKind <= 39)
			{
				enemy.thisAttribute = Attr.fire;
				enemy.attackInterval = 3.0f;
			}
			else if (40 <= (int)enemy.thisKind && (int)enemy.thisKind <= 54)
			{
				enemy.thisAttribute = Attr.water;
				enemy.attackInterval = 0.5f;
			}
			else if (55 <= (int)enemy.thisKind && (int)enemy.thisKind <= 69)
			{
				enemy.thisAttribute = Attr.grass;
			}
			else if (67 <= (int)enemy.thisKind && (int)enemy.thisKind <= 82)
			{
				enemy.thisAttribute = Attr.woman;
				enemy.attackInterval = 10f;
			}
			else if (79 <= (int)enemy.thisKind && (int)enemy.thisKind <= 93)
			{
				enemy.thisAttribute = Attr.stone;
			}
			else if (93 <= (int)enemy.thisKind && (int)enemy.thisKind <= 107)
			{
				enemy.thisAttribute = Attr.thread;
			}
			else if (108 <= (int)enemy.thisKind && (int)enemy.thisKind <= 122)
			{
				enemy.thisAttribute = Attr.wood;
			}
			else if (123 <= (int)enemy.thisKind && (int)enemy.thisKind <= 137)
			{
				enemy.thisAttribute = Attr.fish;
			}
			else if (138 <= (int)enemy.thisKind && (int)enemy.thisKind <= 151)
			{
				enemy.thisAttribute = Attr.bug;
			}
			else if (152 <= (int)enemy.thisKind && (int)enemy.thisKind <= 164)
			{
				enemy.thisAttribute = Attr.bird;
			}
			else if (165 <= (int)enemy.thisKind && (int)enemy.thisKind <= 174)
			{
				enemy.thisAttribute = Attr.eye;
			}
			else if (175 <= (int)enemy.thisKind && (int)enemy.thisKind <= 187)
			{
				enemy.thisAttribute = Attr.beast;
			}
			else if (188 <= (int)enemy.thisKind && (int)enemy.thisKind <= 196)
			{
				enemy.thisAttribute = Attr.horse;
			}
			else if (197 <= (int)enemy.thisKind && (int)enemy.thisKind <= 219)
			{
				enemy.thisAttribute = Attr.desease;
			}
			else if (220 <= (int)enemy.thisKind && (int)enemy.thisKind <= 224)
			{
				enemy.thisAttribute = Attr.death;
			}
			else if (225 <= (int)enemy.thisKind && (int)enemy.thisKind <= 230)
			{
				enemy.thisAttribute = Attr.demon;
			}
		}
    }

	public int AllCrystalNum()
	{
		int temp = 0;
		for (int i=0; i<main.SR.CrystalNum.Length; i++)
		{
			temp += main.SR.CrystalNum[i];
		}

		return temp;
	}

	public double IdleDamageUpByCrystalNum()
	{
		return 1 + AllCrystalNum() / 1000;
	}

	//重複数によるhpアップ
	public double HpUpbyDuplication(EnemyInfo info)
	{
		double result = 0;
		int temp = main.S.AllyNum[(int)info.thisKind];
		switch (info.rarity)
		{
			case Rarity.C:
				result = Math.Pow(temp, 1.25);
				break;
			case Rarity.UC:
				result = Math.Pow(temp, 1.4);
				break;
			case Rarity.R:
				result = Math.Pow(temp, 1.7);
				break;
			case Rarity.SR:
				result = Math.Pow(temp, 2.5);
				break;
			case Rarity.SSR:
				result = Math.Pow(temp, 3.3);
				break;
		}
		return result;
	}
    public Sprite GetImage(EnemyKind enemy)
    {
		return enemies[(int)enemy].thisImage;
    }


}
