using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    //"sampletext"のGameObjectを取得
    GameObject sampletext;

    // Start is called before the first frame update
    void Start()
    {

        //"sampletext"のtext内容を「あいうえお」に更新
        sampletext.GetComponent<TextMesh>().text = "あいうえお";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
