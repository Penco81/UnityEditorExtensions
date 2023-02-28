using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class EditorEventAtrribute
{
    static EditorEventAtrribute()
    {
        Debug.Log("EditorEventAtrribute");
    }

    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        Debug.Log("InitializeOnLoadMethod");
    }

    [DidReloadScripts()]
    static void OnScriptReload()
    {
        Debug.Log("脚本加载完毕");
    }

    //场景启动后调用
    [PostProcessScene]
    public static void OnPostProcessScene()
    {
        Debug.Log("OnPostProcessScene");
    }

    //build后调用
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("OnPostProcessBuild");
    }

    [OnOpenAsset(1)]
    public static bool OpenAsset(int instanceID, int line)
    {
        var name = EditorUtility.InstanceIDToObject(instanceID).name;
        Debug.Log("Open Asset step:1 (" + name + ")");
        return false;
    }
        
    [OnOpenAsset(2)]
    public static bool OpenAsset2(int instanceID, int line)
    {
        var name = EditorUtility.InstanceIDToObject(instanceID).name;
        Debug.Log("Open Asset step:2 (" + name + ")");
        return false;
    }
}
