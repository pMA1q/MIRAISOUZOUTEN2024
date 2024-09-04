using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_RenderTexture : MonoBehaviour
{
    [SerializeField, Header("サブカメラ")]
    private Camera mSubCamera;

    private Renderer mRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<Renderer>();

        // カメラのアスペクト比を取得
        float cameraAspect = mSubCamera.aspect;

        // オブジェクトのスケールをカメラのアスペクト比に合わせて調整
        Vector3 screenScale = transform.localScale;
        screenScale.y = screenScale.x / cameraAspect; // アスペクト比に基づいて高さを調整
        transform.localScale = screenScale;

        // RenderTextureの設定
        RenderTexture rTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mSubCamera.targetTexture = rTexture;

        // マテリアルのメインテクスチャをRenderTextureに設定
        mRenderer.material.mainTexture = rTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
        //RenderTexture rTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //mSubCamera.targetTexture = rTexture;

        //マテリアルとしてオブジェクトに投影
        mRenderer.material.mainTexture = mSubCamera.targetTexture;
    }
}
