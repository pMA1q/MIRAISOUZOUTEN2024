//---------------------------------
//準備フェーズのミッションを抽選して表示
//担当者：中島
//---------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_LotMission: MonoBehaviour
{
    [SerializeField, Header("ミッションテーブル")]
    private CSO_SetPhaseTable mMissionStatus;

    [SerializeField, Header("ステータスミッション表示オブジェクト")]
    private MeshRenderer mStatusMission;

    [SerializeField, Header("イベントミッション表示オブジェクト")]
    private MeshRenderer mEventMission;

    [SerializeField, Header("アイテムミッション表示オブジェクト")]
    private MeshRenderer mItemMission;

    private List<MeshRenderer> mTextureMaterials = new List<MeshRenderer>();

    private int mNowMissionSelect = 0;//抽選決定するミッション番号(0~2)

    Coroutine coroutine = null;  // コルーチンの実行を管理する変数
    // Start is called before the first frame update
    void Start()
    {
        mTextureMaterials.Add(mStatusMission);
        mTextureMaterials.Add(mEventMission);
        mTextureMaterials.Add(mItemMission);

        CS_SetPheseController.OnPlayPerformance += DecisionMission;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ミッション決定
    private void DecisionMission(int _num)
    {
        if(coroutine == null) { coroutine = StartCoroutine(ChangeMaterial(_num)); }
    }

    //マテリアルを変更
    private IEnumerator ChangeMaterial(int _num)
    {
        yield return new WaitForSeconds(2f);

        Material[] materials = mTextureMaterials[mNowMissionSelect].materials;//materialsを取得
        //0番目をミッション情報に設定したマテリアルに変更
        materials[0] = mMissionStatus.infomation[mNowMissionSelect].mission[_num].missionTextureMaterial;
        //変更した配列を再度設定
        mTextureMaterials[mNowMissionSelect].materials = materials;

        mNowMissionSelect++;//ミッション番号をインクリメント

        //テスト用
        if (mNowMissionSelect == 3)
        {
            mNowMissionSelect = 0;
        }

        //演出終了用スクリプトを生成
        CS_SetPerformanceFinish spcFinish = this.gameObject.AddComponent<CS_SetPerformanceFinish>();
        spcFinish.Timer = 2f;//終了までの時間を1秒に変更

        coroutine = null;
        yield return null;
    }
}
