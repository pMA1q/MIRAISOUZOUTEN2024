using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CS_TestProbabilityStatus", menuName = "Test/CS_TestProbabilityStatus", order = 1)]

public class CS_TestProbabilityStatus : ScriptableObject
{

    [SerializeField,Header("演出名と出現確率を入力")]
    public List<ProbabilityEntry> performances; 
}

[System.Serializable]
public class ProbabilityEntry
{
    public string name;  // カスタム名を保持する
    public float value;   // 確率値（float）
    public GameObject performancePrefab;
}