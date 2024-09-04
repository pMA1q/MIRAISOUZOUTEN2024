using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_QuadAdjuster : MonoBehaviour
{
    [SerializeField,Header("サブカメラ")]
    private Camera mSubCamera; 
    // Start is called before the first frame update
    void Start()
    {
        // カメラの距離
        float distance = mSubCamera.transform.position.z;

        // カメラの視野角
        float fov = mSubCamera.fieldOfView;
        float aspect = mSubCamera.aspect;

        // カメラの高さのハーフサイズ
        float height = 2.0f * Mathf.Tan(Mathf.Deg2Rad * fov / 2.0f) * Mathf.Abs(distance);
        // カメラの幅のハーフサイズ
        float width = height * aspect;

        // Quadのサイズを設定
        transform.localScale = new Vector3(width, height, 1.0f);

        // Quadの位置をカメラの前方に設定
        transform.position = mSubCamera.transform.position + mSubCamera.transform.forward * Mathf.Abs(distance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
