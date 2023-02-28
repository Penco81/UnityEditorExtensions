using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropDownSamples : EditorWindow
{
    [MenuItem("EditorWindow/DropDownWindowSample")]
    public static void Open()
    {
        var window = GetWindow<DropDownSamples>();
        window.position = new Rect(1000, 400, 800, 600);
        window.Show();
    }

    private bool mDropDown = false;
    private Rect mButtonRect;
    private void OnGUI()
    {
        DrawGenericMenu();
        DrawPopupWindow();
    }

    private void DrawGenericMenu()
    {
        if(EditorGUILayout.DropdownButton(new GUIContent("123", "tips"), FocusType.Keyboard))
        {
            var genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("按钮1"), true, () => { Debug.Log("按钮1");});
            genericMenu.AddItem(new GUIContent("按钮2"), false, () => { Debug.Log("按钮2");});
            genericMenu.AddItem(new GUIContent("按钮合集/按钮3"), false, () => { Debug.Log("按钮3");});
            genericMenu.AddSeparator("按钮合集/");
            genericMenu.AddItem(new GUIContent("按钮合集/按钮4"),false, () => { Debug.Log("按钮4"); });

            genericMenu.ShowAsContext();
        }
        
    }

    private void DrawPopupWindow()
    {
        if (GUILayout.Button("Popup Options"))
        {
            PopupWindow.Show(mButtonRect, new PopUpDropDownWindow());
        }
        
        if (Event.current.type == EventType.Repaint) mButtonRect = GUILayoutUtility.GetLastRect();

    }
}

public class PopUpDropDownWindow : PopupWindowContent
{
    private bool mToggle1 = false;
    private bool mToggle2 = false;
    private bool mToggle3 = false;
    
    public override Vector2 GetWindowSize()
    {
        return new Vector2(200, 100);
    }
    
    public override void OnGUI(Rect rect)
    {
        GUILayout.Label("Popup Options", EditorStyles.boldLabel);
        mToggle1 = EditorGUILayout.Toggle("Toggle 1", mToggle1);
        mToggle2 = EditorGUILayout.Toggle("Toggle 2", mToggle2);
        mToggle3 = EditorGUILayout.Toggle("Toggle 3", mToggle3);
    }
    
    public override void OnOpen()
    {
        Debug.Log("On Open");
    }

    public override void OnClose()
    {
        Debug.Log("On Close");
    }
}
