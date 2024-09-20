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
    public static　bool LotMain(int _denominator)
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

    //演出抽選
    //ジェネリック関数で任意のEnum型からランダムに値を抽選
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
}
