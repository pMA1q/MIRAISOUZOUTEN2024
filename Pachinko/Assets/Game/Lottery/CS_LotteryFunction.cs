//---------------------------------
//抽選関数
//担当者：中島
//---------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CS_LotteryFunction : MonoBehaviour
{
    // 確率抽選関数: 分母を引数にとり、1/分母の確率で当たりを返す
    public static　bool LotJackpot(int _denominator)
    {
        if (_denominator <= 0)
        {
            Debug.LogError("分母は1以上である必要があります。");
            return false;
        }

        // 0から(denominator - 1)までのランダムな整数を生成し、その値が0なら「当たり」
        int randomValue = UnityEngine.Random.Range(0, _denominator);
        return randomValue == 0;
    }

  
    //ノーマル抽選 int型の番号を返す。
    //範囲：0~
    public static int LotNormalInt(int _max)
    {
        return UnityEngine.Random.Range(0, _max);
    }

    //累積計算を使った確率抽選
    public static int LotPerformance(List<float> _probabilities)
    {
        //確率の合計を取得
        float totalProbability = 0f;
        foreach (float probability in _probabilities)
        {
            totalProbability += probability;
        }

        //totalProbability が0のときはエラーを返す
        if (totalProbability == 0f)
        {
            Debug.LogError("確率の合計が0です。");
            return -1; // エラーとして -1 を返す
        }

        //ランダムな値を生成 (0～totalProbabilityの範囲)
        float randomValue = UnityEngine.Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;

        //確率に従って抽選
        for (int i = 0; i < _probabilities.Count; i++)
        {
            cumulativeProbability += _probabilities[i];
            if (randomValue < cumulativeProbability)
            {
                return i; // 確率に従って選ばれたリストのインデックスを返す
            }
        }

        //フォールバックとして、最後のインデックスを返す
        return _probabilities.Count - 1;
    }

/*
    public static T LotPerformance<T>() where T : Enum
    {
        T[] enumValues = (T[])Enum.GetValues(typeof(T)); //Enumの全ての値を配列で取得
        int randomIndex = UnityEngine.Random.Range(0, enumValues.Length); //ランダムインデックス
        return enumValues[randomIndex]; //ランダムに選ばれたEnumの値を返す
    }

    public static T LotPerformance<T>(List<float> _probabilities) where T : Enum
    {
        // Enumの全ての値を配列で取得
        T[] enumValues = (T[])Enum.GetValues(typeof(T));

        // 確率の数とEnumの数が一致しているか確認
        if (_probabilities.Count != enumValues.Length)
        {
            Debug.LogError("確率の数とEnumの数が一致していません。");
            return default(T);
        }

        //確率の合算値を設定
        float totalProbability = 0f;
        foreach (float probability in _probabilities)
        {
            totalProbability += probability;
        }
        // ランダムな値を生成 (0～の範囲)
        float randomValue = UnityEngine.Random.Range(0f, totalProbability);


        float cumulativeProbability = 0f;

        //Debug.Log("randomValue" + randomValue);

        //確率に従って抽選
        for (int i = 0; i < _probabilities.Count; i++)
        {
            cumulativeProbability += _probabilities[i];
            if (randomValue < cumulativeProbability)
            {
                return enumValues[i]; // 確率に従って選ばれたEnumの値を返す
            }
        }

        // フォールバックとして、最後のEnum値を返す
        return default(T);
    }
*/

}
