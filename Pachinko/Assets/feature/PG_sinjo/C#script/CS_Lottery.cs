using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    public GameObject plane;   // Planeオブジェクト
    public GameObject ball;    // Ballオブジェクト

    private const int TotalValues = 65536;   // 全体の値
    private const int WinningValues = 656;   // 当たりの範囲

    void Start()
    {
        // PlaneとBallが設定されていない場合、コンポーネントを自動取得
        if (plane == null)
            plane = GameObject.Find("Plane");
        if (ball == null)
            ball = GameObject.Find("Ball");
    }

    // BallがPlaneと衝突したときの処理
    void OnCollisionEnter(Collision collision)
    {
        // BallとPlaneが衝突した場合
        if (collision.gameObject == ball)
        {
            StartLottery();
        }
    }

    // 抽選を開始するメソッド
    void StartLottery()
    {
        // ランダムな値を生成
        int randomValue = Random.Range(0, TotalValues);

        // 抽選結果を出力
        if (randomValue < WinningValues)
        {
            Debug.Log("当たり！ (1/99.9)");
        }
        else
        {
            Debug.Log("ハズレ");
        }
    }
}

