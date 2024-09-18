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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SET_DIRECTING random = CS_LotteryFunction.LotDirecting<SET_DIRECTING>();
            Debug.Log("ランダムに選ばれたENの値: " + random);
        }
    }
}
