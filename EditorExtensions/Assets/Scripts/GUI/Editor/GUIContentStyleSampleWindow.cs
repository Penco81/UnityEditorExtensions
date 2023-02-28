using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GUIContentStyleSampleWindow : EditorWindow
{
    [MenuItem("EditorWindow/OpenGUIContentStyle")]
    static void Open()
    {
        var window = GetWindow<GUIContentStyleSampleWindow>();
        window.position = new Rect(1000, 500, 800, 600);
        window.Show();
    }
    
    enum Mode
    {
        GUIContent,
        GUIStyle
    }

    private int mToolbarIndex;
    private List<GUIContent> mGUIContentList;
    private GUIStyle mStyle1;
    private GUIStyle mStyle2;
    private GUIStyle mStyle3;
    private void OnGUI()
    {
        mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, Enum.GetNames(typeof(Mode)));
        if ((Mode)mToolbarIndex == Mode.GUIContent)
        {
            mGUIContentList = mGUIContentList ?? new List<GUIContent>()
            {
                new GUIContent("GUIContent 1"),
                new GUIContent("GUIContent 2","tips1"),
                new GUIContent("GUIContent 3",Texture2D.whiteTexture),
                new GUIContent("GUIContent 4",Texture2D.whiteTexture,"tips2"),
            };
            
            GUILayout.Label("No GUIContent");
            GUILayout.Space(100);
            for (int i = 0; i < mGUIContentList.Count; i++)
            {
                GUILayout.Label(mGUIContentList[i]);
                GUILayout.Space(100);
            }
        }
        else
        {
            mStyle1 = mStyle1 ?? new GUIStyle();
            //GUISkin 包含 GUI 设置和 GUIStyle 对象的集合，它们共同指定 GUI 皮肤。
            //通过 GUI.skin 获取和设置激活的 GUI 皮肤
            mStyle2 = mStyle2 ?? new GUIStyle(GUI.skin.button);
            //重载了操作符，赋予GUI.skin.box
            mStyle3 = mStyle3 ?? "box";
            
            mStyle1.fontSize = 30;
            mStyle1.fontStyle = FontStyle.BoldAndItalic;
            mStyle1.normal.textColor = Color.green;
            mStyle1.hover.textColor = Color.blue;
            mStyle1.focused.textColor = Color.red;
            mStyle1.active.textColor = Color.cyan;
            mStyle1.normal.background = Texture2D.whiteTexture;
            
            
            GUILayout.Label("Style Of Text", mStyle1);

            GUILayout.Space(100);

            if (GUILayout.Button("Style Of Button", mStyle2))
            {
                Debug.Log("Button");
            }

            GUILayout.Space(100);
            
            GUILayout.Label("Style Of Box", mStyle3);
        }
    }
}
