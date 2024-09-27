using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    // オブジェクトがトリガーに入った時の処理
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("オブジェクトがPlaneに入った");
    }

    // オブジェクトがトリガーから出た時の処理
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("オブジェクトがPlaneから出た");
    }
}
