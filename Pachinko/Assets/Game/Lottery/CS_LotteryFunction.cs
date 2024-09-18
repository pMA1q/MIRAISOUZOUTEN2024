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
    public static T LotDirecting<T>() where T : Enum
    {
        T[] enumValues = (T[])Enum.GetValues(typeof(T)); // Enumの全ての値を配列で取得
        int randomIndex = UnityEngine.Random.Range(0, enumValues.Length); // ランダムインデックス
        return enumValues[randomIndex]; // ランダムに選ばれたEnumの値を返す
    }
}
