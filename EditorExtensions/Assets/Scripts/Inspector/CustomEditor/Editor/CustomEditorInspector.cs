using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WithCustomEditor))]
public class CustomEditorInspector : Editor
{
    WithCustomEditor mTarget
    {
        get { return target as WithCustomEditor; }
    }

    public override void OnInspectorGUI()
    {
        mTarget.HP = EditorGUILayout.FloatField("Hp", mTarget.HP);
        mTarget.Range = EditorGUILayout.FloatField("Range", mTarget.Range);
        
        var hpRect = GUILayoutUtility.GetRect(18,18,"TextField");
        EditorGUI.ProgressBar(hpRect, mTarget.HP,"HP");
            
        var rangeRect = GUILayoutUtility.GetRect(18,18,"TextField");
        EditorGUI.ProgressBar(rangeRect, mTarget.Range,"Range");

        EditorGUILayout.BeginHorizontal("box");
        EditorGUILayout.LabelField("角色名",GUILayout.Width(100));
        mTarget.RoleName = EditorGUILayout.TextArea(mTarget.RoleName);
        EditorGUILayout.EndHorizontal();
            
        EditorGUILayout.ObjectField(serializedObject.FindProperty("OtherObj"));
        serializedObject.ApplyModifiedProperties();
    }
}
