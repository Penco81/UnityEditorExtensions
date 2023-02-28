using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HandlesSample))]
public class HandlesSampleEditor : Editor
{
    private void OnSceneGUI()
    {
        var t = target as HandlesSample;
        Handles.color = new Color(1, 0.8f, 0.4f, 1);
        Handles.DrawWireDisc(t.transform.position, t.transform.up, t.Radius);
        Handles.Label(t.transform.position, t.Radius.ToString("F1"));
            
        // Handles.Button()
        Handles.BeginGUI();
        if (GUILayout.Button("Hello"))
        {
            Debug.Log("Hello");
        }
            
        Handles.EndGUI();
    }
}
