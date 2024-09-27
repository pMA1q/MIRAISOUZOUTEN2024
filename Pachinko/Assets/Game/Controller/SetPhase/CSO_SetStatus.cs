using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetPhaseStatus", menuName = "PhaseStatus/SetPhaseStatus", order = 1)]
public class CSO_SetPhaseStatus : ScriptableObject
{
    [SerializeField, Header("演出名と出現確率を入力")]
    public List<ProbabilityEntry> performances;
}


[System.Serializable]
public class ProbabilityEntry
{
    public string name;  // カスタム名を保持する
    public float value=1;   // 確率値（float）
    public GameObject performancePrefab;
}