using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    byte r = 0;
    
    // Start is called before the first frame update
    void Start()
    {    
        //オブジェクトの色をRGBA値を用いて変更する
        GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //徐々に赤くする
        for(int i=0;i<254;i++)
        {
            r++;
        }
        //オブジェクトの色をRGBA値を用いて変更する
        GetComponent<Renderer>().material.color = new Color32(r, 0, 0, 1);
    }
}
