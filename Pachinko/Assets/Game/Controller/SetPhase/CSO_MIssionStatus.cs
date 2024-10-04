using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionTable", menuName = "Table/MissionTable", order = 1)]
public class CSO_MIssionStatus : ScriptableObject
{
    [Header("ミッション情報")]
    public List<MissionTable> infomation;

    
}


[System.Serializable]

public class MissionTable
{
    [Header("ミッション名")]
    public string name;  // カスタム名を保持する
    [Header("ミッション内容")]
    public List<Mission> mission;
}

[System.Serializable]
public class Mission
{
    [Header("演出名")]
    public string name;
    [Header("進度")]
    public float progress;

    [Header("各ミッションのテクスチャマテリアル")]
    public Material missionTextureMaterial;

    [Header("演出")]
    public GameObject performance;
}
