//---------------------------------
//準備フェーズ司令塔
//担当者：中島
//---------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;  // LINQを使うために必要


public class CS_SetPheseController : MonoBehaviour
{
   
    //[SerializeField]
    //CSO_SetPhaseStatus mProbabilityStatus;
    //List<float> mProbabilities = new List<float>();

    [SerializeField,Header("ミッション情報")]
    private CSO_MIssionStatus mMissionStatus;

    [SerializeField, Header("ミッション選択プレハブ")]
    private GameObject mMisstionSelect;

    //演出が終わったか否か
    private bool mPerformanceFinish = true;


    private int mPrizesNum = 0;//入賞数

    private CS_Controller mBigController;//司令塔大

 //-----------------------イベントハンドラ-----------------------
    public delegate void Performance(int _performance);

    //演出を流すトリガーイベント
    public static event Performance OnPlayPerformance;
 //-------------------------------------------------------------



    int debugCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //パフォーマンスリストから確率をコピー
        //for (int i = 0; i < mProbabilityStatus.performances.Count; i++)
        //{
        //    mProbabilities.Add(mProbabilityStatus.performances[i].value);
        //    Debug.Log(mProbabilityStatus.performances[i].name + "の確率" + mProbabilities[i] + "%");
        //}

       

        mBigController = GameObject.Find("BigController").GetComponent<CS_Controller>();//司令塔（大）を取得
        Instantiate(mMisstionSelect, mMisstionSelect.transform.position, mMisstionSelect.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        //CheckLottery();
      
        //変動終了フラグを取得
        CS_Controller ctrl = GameObject.Find("BigController").GetComponent<CS_Controller>();

        //次の変動が開始できるか
        bool variationStart = ctrl.CanVariationStart();
        if (!variationStart) { return; }


        //残り入賞数が0？
        if(mPrizesNum == 3)
        {
            mPrizesNum = 0;//テスト用
            //ミッション選択の処理を書く
            return;
        }

        // サブスクライブ確認のログ出力
        if (OnPlayPerformance == null) { return; }

        //保留玉数が0なら終了
        if(mBigController.GetStock() == 0) { return; }

        //保留玉を使用
        mBigController.UseStock();

        //ミッション抽選
        int randomNumber = CS_LotteryFunction.LotNormalInt(mMissionStatus.infomation[mPrizesNum].mission.Count -1);
        mPerformanceFinish = false;//演出終了フラグをfalse

        mPrizesNum++;//入賞数を増やす


        if (OnPlayPerformance != null)
        {
            //演出開始トリガーをON
            OnPlayPerformance(randomNumber);
        }
           
    }



    private void CheckLottery()
    {
        if (debugCount < 10000)
        {
            //int randomNumber = CS_LotteryFunction.LotPerformance(mProbabilities);
            //Debug.Log("ランダムに選ばれた演出: " + mProbabilityStatus.performances[randomNumber].name);
            //debugCount++;

            //if (debugCount >= 10000)
            //{
            //    Debug.Log("10000回終了");
            //}
        }

    }

    //シーン内にあるオブジェクトからCS_SetPheseControllerを見つけて返す
    public static CS_SetPheseController GetCtrl()
    {
        //シーン内の全てのGameObjectを取得して、名前にmPrefabNameを含むオブジェクトを検索
        GameObject targetObject = FindObjectsOfType<GameObject>()
            .FirstOrDefault(obj => obj.name.Contains("SetPhaseCtrl"));
        if (targetObject != null)
        {
            Debug.Log("準備フェーズ司令塔が見つかった");
            return targetObject.GetComponent<CS_SetPheseController>();
        }
        return null;
    }

    //演出終了関数
    public void PerformanceFinish()
    {
        mPerformanceFinish = true;
    }
    
    //登録されているイベントハンドラをすべて削除
    public static void RemoveAllHandlers()
    {
        // OnPlayPerformance に何かしらのハンドラが登録されている場合
        if (OnPlayPerformance != null)
        {
            // OnPlayPerformance に登録されている全てのハンドラを取得
            Delegate[] handlers = OnPlayPerformance.GetInvocationList();

            // すべてのハンドラを解除
            foreach (Delegate handler in handlers)
            {
                OnPlayPerformance -= (Performance)handler;
            }
        }
    }

   
}
