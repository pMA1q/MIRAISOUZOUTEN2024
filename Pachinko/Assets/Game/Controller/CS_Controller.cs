//---------------------------------
//司令塔（）
//担当者：中島
//---------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Controller : MonoBehaviour
{
    //パチンコの状態
    public enum PACHINKO_PHESE
    {
        SET,    //準備フェーズ
        BOSS,   //ボスフェーズ       
        RUSH    //ラッシュフェーズ
    }

    private PACHINKO_PHESE mNowPhese = PACHINKO_PHESE.SET;//現在のフェーズ
    private PACHINKO_PHESE mPrevPhese = PACHINKO_PHESE.SET;//前ののフェーズ

    private int mStock = 0;//保留玉数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //現在のフェーズ取得
    public PACHINKO_PHESE GetPhese()
    {
        return mNowPhese;
    }

    //保留玉を増やす
    public void AddStock()
    {
        mStock++;
    }
}
