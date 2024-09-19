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
    public enum SET_DIRECTING
    {
        VALUE1,
        VALUE2,
        VALUE3,
    }

    //各Enumに対する確率
    List<float> mProbabilities = new List<float> { 50.0f/200.0f, 150f/200f, 20f/200f };

    int debugCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //各確率を%に直す
        for (int i = 0; i < mProbabilities.Count; i++)
        {
            mProbabilities[i] *= 100f;
            Debug.Log((SET_DIRECTING)i + "の確率" + mProbabilities[i] + "%");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(debugCount < 10000)
        {
            SET_DIRECTING random = CS_LotteryFunction.LotDirecting<SET_DIRECTING>(mProbabilities);
            Debug.Log("ランダムに選ばれた値: " + random);
            debugCount++;

            if(debugCount >= 10000)
            {
                Debug.Log("10000回終了");
            }
        }

    }
}
