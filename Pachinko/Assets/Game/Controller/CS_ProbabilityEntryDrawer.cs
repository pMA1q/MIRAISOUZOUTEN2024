using UnityEngine;
using UnityEditor;

// ProbabilityEntryのカスタムPropertyDrawerを作成
[CustomPropertyDrawer(typeof(ProbabilityEntry))]
public class ProbabilityEntryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // プロパティと対応するラベルを配列にまとめる
        (SerializedProperty prop, string label)[] properties = new (SerializedProperty, string)[]
        {
            (property.FindPropertyRelative("name"), "演出名"),
            (property.FindPropertyRelative("value"), "確率"),
            (property.FindPropertyRelative("performancePrefab"), "演出プレハブ")
        };

        // 各プロパティの高さ
        float singleLineHeight = EditorGUIUtility.singleLineHeight;
        float spacing = EditorGUIUtility.standardVerticalSpacing;

        // 各プロパティを描画
        for (int i = 0; i < properties.Length; i++)
        {
            Rect fieldRect = new Rect(position.x, position.y + i * (singleLineHeight + spacing), position.width, singleLineHeight);
            EditorGUI.PropertyField(fieldRect, properties[i].prop, new GUIContent(properties[i].label));
        }

        EditorGUI.EndProperty();
    }

    // Heightをカスタマイズするために必要な関数
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // 各プロパティ分の高さを確保 (3つのプロパティ分 + スペーシング)
        return (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 3;
    }
}
