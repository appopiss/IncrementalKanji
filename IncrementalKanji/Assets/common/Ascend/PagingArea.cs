using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アタッチされているGameObjectを、自身の大きさ分スライドさせるコンポーネント
/// 
/// ・Limitを設定することで、それ以上動かないようにできる。
/// ・InitSlideをインスペクターから設定することでインスタンス化直後から移動した状態で始まる。
/// 
/// NOTE : 現在一度に数ページ移動させた場合、Limitを越えてしまう仕様。どうするか未定。
/// </summary>
public class PagingArea : MonoBehaviour {

    [NonSerialized]
    public bool moving;

    public bool LimitedFlg;
    [SerializeField]
    private int upLimit, downLimit, rightLimit, leftLimit;
    public int UpLimit { get { return upLimit; } set { LimitedFlg = true; upLimit = value; } }
    public int DownLimit { get { return downLimit; } set { LimitedFlg = true; downLimit = value; } }
    public int RightLimit { get { return rightLimit; } set { LimitedFlg = true; rightLimit = value; } }
    public int LeftLimit { get { return leftLimit; } set { LimitedFlg = true; leftLimit = value; } }

    //インスタンス化直後から移動している設定。インスペクターからのみ設定できる。
    [SerializeField]
    private bool InitSlideFlg;
    [SerializeField]
    private int InitVerticalSlide, InitHorizontalSlide;

    public (int x, int y) currentPage;
    RectTransform rectTransform;
    Vector2 tempVec2 = new Vector2();
    Vector2 initPos;
    Vector2 DesPos = new Vector2();

    // Use this for initialization
    void Awake() {
        rectTransform = this.GetComponent<RectTransform>();
        initPos = rectTransform.anchoredPosition;

        if (InitSlideFlg)
        {
            if (InitVerticalSlide > 0)
            {
                Up(InitVerticalSlide);
            }
            else
            {
                Down(-InitVerticalSlide);
            }

            if(InitHorizontalSlide > 0)
            {
                Right(InitHorizontalSlide);
            }
            else
            {
                Left(-InitHorizontalSlide);
            }
        }
    }



    public void Right()
    {
        if (LimitedFlg)
        {
            if (currentPage.x >= RightLimit) { return; }
            currentPage.x++;
        }
        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.x += rectTransform.sizeDelta.x;
        rectTransform.anchoredPosition = tempVec2;
    }

    public void Right(int Page)
    {
        if (LimitedFlg)
        {
            if (currentPage.x >= RightLimit) { return; }
            currentPage.x += Page;
        }
        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.x += rectTransform.sizeDelta.x * Page;
        rectTransform.anchoredPosition = tempVec2;
    }

    public IEnumerator RightCor(int Page = 1, float Time = 0.2f)
    {
        if (moving) { yield break; }
        if (LimitedFlg)
        {
            if (currentPage.x >= RightLimit) { yield break; }
            currentPage.x += Page;
        }
        moving = true;

        

        tempVec2 = rectTransform.anchoredPosition;
        DesPos = tempVec2;
        DesPos.x = tempVec2.x + rectTransform.sizeDelta.x * Page; //　正解の座標を保存
        for (int i = 0; i < 5; i++)
        {
            tempVec2.x += rectTransform.sizeDelta.x * Page / 5.0f;
            rectTransform.anchoredPosition = tempVec2;
            yield return new WaitForSeconds(Time / 5.0f);
        }
        rectTransform.anchoredPosition = DesPos; //正解の座標
        moving = false;
    }




    public void Left()
    {
        if (LimitedFlg)
        {
            if (currentPage.x <= LeftLimit * (-1)) { return; }
            currentPage.x--;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.x -= rectTransform.sizeDelta.x;
        rectTransform.anchoredPosition = tempVec2;
    }

    public void Left(int Page)
    {
        if (LimitedFlg)
        {
            if (currentPage.x <= LeftLimit * (-1)) { return; }
            currentPage.x -= Page;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.x -= rectTransform.sizeDelta.x * Page;
        rectTransform.anchoredPosition = tempVec2;
    }

    public IEnumerator LeftCor(int Page = 1, float Time = 0.2f)
    {
        if (moving) { yield break; }
        if (LimitedFlg)
        {
            if (currentPage.x <= LeftLimit * (-1)) { yield break; }
            currentPage.x -= Page;
        }
        moving = true;

        

        tempVec2 = rectTransform.anchoredPosition;
        DesPos = tempVec2;
        DesPos.x = tempVec2.x - rectTransform.sizeDelta.x * Page; //　正解の座標を保存
        for (int i = 0; i < 5; i++)
        {
            tempVec2.x -= rectTransform.sizeDelta.x * Page / 5.0f;
            rectTransform.anchoredPosition = tempVec2;
            yield return new WaitForSeconds(Time / 5.0f);
        }
        rectTransform.anchoredPosition = DesPos; //正解の座標
        moving = false;
    }





    public void Up() {
        if (LimitedFlg)
        {
            if (currentPage.y >= UpLimit) { return; }
            currentPage.y++;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.y += rectTransform.sizeDelta.y;
        rectTransform.anchoredPosition = tempVec2;
    }

    public void Up(int Page)
    {
        if (LimitedFlg)
        {
            if (currentPage.y >= UpLimit) { return; }
            currentPage.y += Page;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.y += rectTransform.sizeDelta.y * Page;
        rectTransform.anchoredPosition = tempVec2;
    }

    public IEnumerator UpCor(int Page = 1, float Time = 0.2f)
    {
        if (moving) { yield break; }
        if (LimitedFlg)
        {
            if (currentPage.y >= UpLimit) { yield break; }
            currentPage.y += Page;
        }
        moving = true;

        tempVec2 = rectTransform.anchoredPosition;
        DesPos = tempVec2;
        DesPos.y = tempVec2.y + rectTransform.sizeDelta.y * Page; //　正解の座標を保存
        for (int i = 0; i < 5; i++)
        {
            tempVec2.y += rectTransform.sizeDelta.y * Page / 5.0f;
            rectTransform.anchoredPosition = tempVec2;
            yield return new WaitForSeconds(Time / 5.0f);
        }
        rectTransform.anchoredPosition = DesPos; //正解の座標
        moving = false;
    }




    public void Down()
    {
        if (LimitedFlg)
        {
            if (currentPage.y <= DownLimit * (-1)) { return; }
            currentPage.y--;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.y -= rectTransform.sizeDelta.y;
        rectTransform.anchoredPosition = tempVec2;
    }

    public void Down(int Page)
    {
        if (LimitedFlg)
        {
            if (currentPage.y <= DownLimit * (-1)) { return; }
            currentPage.y -= Page;
        }

        tempVec2 = rectTransform.anchoredPosition;
        tempVec2.y -= rectTransform.sizeDelta.y * Page;
        rectTransform.anchoredPosition = tempVec2;
    }

    public IEnumerator DownCor(int Page = 1, float Time = 0.2f)
    {
        if (moving) { yield break; }
        if (LimitedFlg)
        {
            if (currentPage.y <= DownLimit * (-1)) { yield break; }
            currentPage.y -= Page;
        }
        moving = true;

        tempVec2 = rectTransform.anchoredPosition;
        DesPos = tempVec2;
        DesPos.y = tempVec2.y - rectTransform.sizeDelta.y * Page; //　正解の座標を保存
        for (int i = 0; i < 5; i++)
        {
            tempVec2.y -= rectTransform.sizeDelta.y * Page / 5.0f;
            rectTransform.anchoredPosition = tempVec2;
            yield return new WaitForSeconds(Time / 5.0f);
        }
        rectTransform.anchoredPosition = DesPos; //正解の座標
        moving = false;
    }




    public void Reset()
    {
        rectTransform.anchoredPosition = initPos;
        StopAllCoroutines();
        moving = false;
        if (LimitedFlg) { currentPage = (0, 0); }
    }
}
