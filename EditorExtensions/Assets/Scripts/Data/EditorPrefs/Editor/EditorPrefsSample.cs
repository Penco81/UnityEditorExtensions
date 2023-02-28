using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorPrefsSample
{
    private static string key = "123";
    private static string value = "321";
    
    [MenuItem("EditorExtension/Editor/EditorPrefs Save")]
    static void SaveTime()
    {
        EditorPrefs.SetString(key, value);
    }

    [MenuItem("EditorExtension/Editor/EditorPrefs Get")]
    static void ReadTime()
    {
        Debug.Log(EditorPrefs.GetString(key));
    }
}
