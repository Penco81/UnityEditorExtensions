using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EditorWindowSample : EditorWindow
{
    //起始位置xy，宽高
    private Rect rect1 = new Rect(20, 20, 200, 200);
    //Gui样式类，字体，颜色，背景，大小，状态
    private GUIStyle style1 = new GUIStyle();
    
    //不同的绘制API
    private GUIMode mGUIMode = new GUIMode();
    private GUILayoutMode mGUILayoutMode = new GUILayoutMode();
    private EditorGUIMode mEditorGUIMode = new EditorGUIMode();
    private EditorGUILayoutMode mEditorGUILayoutMode = new EditorGUILayoutMode();

    private bool mRotate = false;
    private bool mEnabled = true;
    private bool mScale = false;
    private Color mColor = Color.white;

    enum APIMode
    {
        GUI = 0,
        GUILayout = 1,
        EditorGUI = 2,
        EditorGUILayout = 3
    }

    private APIMode mCurrentMode = APIMode.GUI;

    [MenuItem("EditorWindow/Open")]
    public static void Open()
    {
        var window = GetWindow<EditorWindowSample>();
        window.position = new Rect(1000, 1000, 800, 600);
    }

    //在OnGUI中使用IMGUI的API进行窗口绘制
    private void OnGUI()
    {
        mCurrentMode = (APIMode)GUILayout.Toolbar((int)mCurrentMode, Enum.GetNames(typeof(APIMode)));
        GUILayout.BeginHorizontal();
        mRotate = GUILayout.Toggle(mRotate, "Rotate");
        mEnabled = GUILayout.Toggle(mEnabled, "Enable");
        mScale = GUILayout.Toggle(mScale, "Scale");
        mColor = EditorGUILayout.ColorField(mColor);
        GUILayout.EndHorizontal();
        
        if (mRotate)
        {
            GUIUtility.RotateAroundPivot(45,Vector2.one * 300);
        }

        if (mScale)
        {
            GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f,  Vector2.one * 300);
        }
        GUI.enabled = mEnabled;
        
        //GUI控件的背景颜色
        GUI.color = mColor;

        switch (mCurrentMode)
        {
            case APIMode.GUI:
                mGUIMode.Draw();
                break;
            case APIMode.GUILayout:
                mGUILayoutMode.Draw();
                break;
            case APIMode.EditorGUI:
                mEditorGUIMode.Draw();
                break;
            case APIMode.EditorGUILayout:
                mEditorGUILayoutMode.Draw();
                break;
        }
    }
}
