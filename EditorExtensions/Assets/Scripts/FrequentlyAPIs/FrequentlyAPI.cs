using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FrequentlyAPI
{
    [MenuItem("FrequentlyUnityAPI/Selection")]
    public static void SelectionAPI()
    {
        Debug.Log("Selected Transform is on " + Selection.activeObject.name);    
    }
    
    [MenuItem("FrequentlyUnityAPI/OpenURL")]
    public static void OpenURLAPI()
    {
        //打开文件
        Application.OpenURL("file://"+Application.dataPath); 
        //打开网页
        Application.OpenURL("http://baidu.com");  
    }
    
    [MenuItem("FrequentlyUnityAPI/Beep")]
    public static void BeepApi()
    {
        EditorApplication.Beep();
    }
    
    [MenuItem("FrequentlyUnityAPI/EnterPlayMode")]
    public static void EnterPlayModeApi()
    {
        EditorApplication.EnterPlaymode();
    }
    
    [MenuItem("FrequentlyUnityAPI/ExitPlayMode")]
    public static void ExitPlayModeApi()
    {
        EditorApplication.ExitPlaymode();
    }
    

    [MenuItem("FrequentlyUnityAPI/Step")]
    public static void StepApi()
    {
        EditorApplication.Step();
    }
}
