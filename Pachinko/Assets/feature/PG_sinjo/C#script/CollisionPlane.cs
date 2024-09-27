using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlane : MonoBehaviour
{
    [SerializeField]
    Heso heso = null;  // ゲームの状態やデータを管理するカスタムクラス

    [SerializeField]
    TextMesh[] texts = null;  // UIテキストオブジェクトの配列

    Coroutine coroutine = null;  // コルーチンの実行を管理する変数

    // 初期値設定
    int[] value = new int[3] { 1, 1, 1 };

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pachinko Ball"))
        {
            Debug.Log("BallがPlaneを通過しました");
            // コルーチンが実行されていない、かつheso.stock.Countが0ではない場合、コルーチンを開始する
            if (coroutine == null && heso.stock.Count != 0)
            {
                coroutine = StartCoroutine(RealTex());
            }
        }
    }

    // 抽選を開始するメソッド
    IEnumerator RealTex()
    {
        float time = 0.0f;
        value = heso.stock[0];
        heso.DisableStock();

        while (time <= 2.0f)
        {
            value[0]++;
            value[1]++;
            value[2]++;

            value[0] %= 10;
            value[1] %= 10;
            value[2] %= 10;

            texts[0].text = value[0].ToString();
            texts[1].text = value[1].ToString();
            texts[2].text = value[2].ToString();

            time += Time.deltaTime;
            yield return null;
        }

        texts[0].text = "";
        texts[1].text = "";
        texts[2].text = "";

        yield return new WaitForSeconds(1.0f);

        texts[0].text = heso.stock[0][0].ToString();
        yield return new WaitForSeconds(0.5f);
        texts[1].text = heso.stock[0][1].ToString();
        yield return new WaitForSeconds(0.5f);
        texts[2].text = heso.stock[0][2].ToString();

        yield return new WaitForSeconds(2.0f);

        coroutine = null;
        yield return null;
    }

}

