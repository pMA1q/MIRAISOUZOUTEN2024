//---------------------------------
//準備フェーズ司令塔
//担当者：中島
//---------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SetPheseController : MonoBehaviour
{
    //準備フェーズの演出を列挙
    public enum SET_PERFORMANCE
    {
        VALUE1,
        VALUE2,
        VALUE3,
    }

    //各Enumに対する確率
    [SerializeField]
    List<float> mProbabilities = new List<float> { 50.0f/200.0f, 150f/200f, 20f/200f };

    //演出が終わったか否か
    private bool mPerformanceFinish = false;
    
//-------------------------------イベントハンドラ----------------
    public delegate void Performance(SET_PERFORMANCE _performance);

    //演出を流すトリガーイベント
    public static event Performance OnPlayPerformance;
//-------------------------------------------------------------

    int debugCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //各確率を%に直す
        for (int i = 0; i < mProbabilities.Count; i++)
        {
            mProbabilities[i] *= 100f;
            Debug.Log((SET_PERFORMANCE)i + "の確率" + mProbabilities[i] + "%");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //演出が終わっていないなら終了
        if (!mPerformanceFinish) { return; }

        //保留玉を使用

        //演出抽選
        SET_PERFORMANCE randomNumber = CS_LotteryFunction.LotPerformance<SET_PERFORMANCE>(mProbabilities);
        mPerformanceFinish = false;
        //演出開始トリガーをON
        OnPlayPerformance(randomNumber);

    }

    private void CheckLottery()
    {
        if (debugCount < 10000)
        {
            SET_PERFORMANCE random = CS_LotteryFunction.LotPerformance<SET_PERFORMANCE>(mProbabilities);
            Debug.Log("ランダムに選ばれた値: " + random);
            debugCount++;

            if (debugCount >= 10000)
            {
                Debug.Log("10000回終了");
            }
        }

    }

    //演出終了関数
    public void PerformanceFinish()
    {
        mPerformanceFinish = true;
    }
}
