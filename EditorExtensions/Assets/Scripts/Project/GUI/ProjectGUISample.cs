using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ProjectGUISample : MonoBehaviour
{
    private const string PATH = "EditorExtension/Enable Project GUI";

    private static bool mCustomProjectEnabled = false;
    
    static ProjectGUISample()
    {
        Menu.SetChecked(PATH, mCustomProjectEnabled);
    }
    
    [MenuItem(PATH)]
    static void Enable()
    {
        if (mCustomProjectEnabled)
        {
            mCustomProjectEnabled = false;
            UnRegisterProject();
        }
        else
        {
            mCustomProjectEnabled = true;
            RegisterProject();
        }

        Menu.SetChecked(PATH, mCustomProjectEnabled);
            
        EditorApplication.RepaintProjectWindow();
    }
    
    static void RegisterProject()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectGUI;
        EditorApplication.projectChanged += OnProjectChanged;
    }
    
    private static void OnProjectChanged()
    {
        Debug.Log("project changed");
    }

    private static void OnProjectGUI(string guid, Rect selectionrect)
    {
        try
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var files = Directory.GetFiles(assetPath);
            var countLabelRect = selectionrect;
            countLabelRect.x += 150;
            GUI.Label(countLabelRect, files.Length.ToString());
        }
        catch (Exception e)
        {
                
        }
    }
    
    static void UnRegisterProject()
    {
        EditorApplication.projectWindowItemOnGUI -= OnProjectGUI;
        EditorApplication.projectChanged -= OnProjectChanged;
    }
}
