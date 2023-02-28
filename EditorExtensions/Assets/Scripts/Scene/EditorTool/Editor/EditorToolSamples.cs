using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("EditorTool1")]
public class EditorTool1 : EditorTool
{
    private bool mShow = false;
    public override void OnToolGUI(EditorWindow window)
    {
        Handles.BeginGUI();
        if (GUILayout.Button("Editor Tool1 Button"))
        {
            mShow = !mShow;
            if (mShow)
            {
                window.ShowNotification(new GUIContent("EditorTool1"));
            }
            else
            {
                window.RemoveNotification();
            }
        }
        Handles.EndGUI();
    }
}

//只有一个移动箭头的Scene操作工具
[EditorTool("EditorTool2")]
public class EditorTool2 : EditorTool
{
    public override void OnToolGUI(EditorWindow window)
    {
        EditorGUI.BeginChangeCheck();
        Vector3 position = Tools.handlePosition;

        using (new Handles.DrawingScope(Color.green))
        {
            position = Handles.Slider(position, Vector3.right);
        }

        if (EditorGUI.EndChangeCheck())
        {
            Vector3 delta = position - Tools.handlePosition;
                
            Undo.RecordObjects(Selection.transforms,"Move Platforms");

            foreach (var transform in Selection.transforms)
            {
                transform.position += delta;
            }
        }
            
    }
}
