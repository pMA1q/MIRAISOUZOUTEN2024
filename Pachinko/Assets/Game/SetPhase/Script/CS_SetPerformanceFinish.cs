//---------------------------------
//準備フェーズの演出終了報告
//担当者：中島
//---------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SetPerformanceFinish : MonoBehaviour
{
    [SerializeField, Header("演出終了までの時間")]
    private float mTimer = 1f;

    //終了報告までのタイマー
    public float Timer
    {
        set
        {
            mTimer = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FinishWait());
    }

  

    private IEnumerator FinishWait()
    {
        //指定した秒数待つ
        yield return new WaitForSeconds(mTimer);

        //準備フェーズ司令塔を取得
        CS_SetPheseController spc = CS_SetPheseController.GetCtrl();
        if(spc == null) { Debug.LogError("準備フェーズ司令塔が見つからない");}

        spc.PerformanceFinish();
        Destroy(this);
    }
}
